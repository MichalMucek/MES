using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using MathNet.Numerics.LinearAlgebra;
using Newtonsoft.Json.Linq;
using org.mariuszgromada.math.mxparser;

namespace MES
{
    static class Program
    {
        private static Vector<double> xFEPsVector = Vector<double>.Build.Dense(new double[] { 0.0, 0.025, 0.025, 0.0 }); //FEPs - Finite Element Points
        private static Vector<double> yFEPsVector = Vector<double>.Build.Dense(new double[] { 0.0, 0.0, 0.025, 0.025 }); //FEPs - Finite Element Points
        private static Vector<double> ksiVector = Vector<double>.Build.Dense(4);
        private static Vector<double> etaVector = Vector<double>.Build.Dense(4);
        private static Matrix<double> shapeFunctionsNMatrix = Matrix<double>.Build.Dense(4, 4);
        private static Vector<double> xFEIntgPsVector = Vector<double>.Build.Dense(4); //FEIntgPs - Finite Element Integration Points
        private static Vector<double> yFEIntgPsVector = Vector<double>.Build.Dense(4); //FEIntgPs - Finite Element Integration Points

        //Transformation Jacobian
        private static Vector<double> dydetaVector = Vector<double>.Build.Dense(4); //   {   dy/d(eta)               }
        private static Vector<double> dydksiVector = Vector<double>.Build.Dense(4); //   {   -//-        dy/d(ksi)   }
        private static Vector<double> dxdetaVector = Vector<double>.Build.Dense(4); //   {   dx/d(eta)   -//-        }
        private static Vector<double> dxdksiVector = Vector<double>.Build.Dense(4); //   {   -//-        dx/d(ksi)   }
        //*************************************************************************************************************//
        private static Matrix<double> dNdksiMatrix = Matrix<double>.Build.Dense(4, 4); //   {   dN/d(ksi)   }
        private static Matrix<double> dNdetaMatrix = Matrix<double>.Build.Dense(4, 4); //   {   dN/d(eta)   }

        private static Matrix<double> JacobianMatrix = Matrix<double>.Build.Dense(4, 4);
        private static Matrix<double> inverseJacobianMatrix = Matrix<double>.Build.Dense(4, 4);

        /*  INVERS JACOBIAN MATRIX                                  JACOBIAN MATRIX    
        
                    pkt. całk.                                              pkt. całk.
            pochodne----------  dy/deta dy/dksi dx/deta dx/dksi     pochodne----------  dx/dksi dy/dksi dx/deta dy/deta
                    1           J-1_2_2 J-1_1_2 J-1_2_1 J-1_1_1             1           J_1_1   J_1_2   J_2_1   J_2_2
                    2           J-1_2_2 J-1_1_2 J-1_2_1 J-1_1_1             2           J_1_1   J_1_2   J_2_1   J_2_2
                    3           J-1_2_2 J-1_1_2 J-1_2_1 J-1_1_1             3           J_1_1   J_1_2   J_2_1   J_2_2
                    4           J-1_2_2 J-1_1_2 J-1_2_1 J-1_1_1             4           J_1_1   J_1_2   J_2_1   J_2_2
        */

        static void Main(string[] args)
        {
            JObject dataSetJObject = JObject.Parse(File.ReadAllText(@"..\..\dataSet.json"));
            DataSet dataSet = dataSetJObject.ToObject<DataSet>();

            Grid grid = new Grid();
            grid.Generate(dataSet);

            ReadKsiEta();
            CalculateShapeFunctions4X4();
            CalculateIntegrationPoints();
            CalculatePD_dNdKsi_dNdEta();
            CalculateInverseJacobianMatrix();

            /*Console.WriteLine(m1.Column(3));
            Console.WriteLine(v1);
            Console.WriteLine(v1.ToRowMatrix());
            Console.WriteLine(m1.Transpose());*/

            //Console.WriteLine(grid);
            Console.WriteLine(shapeFunctionsNMatrix);
            Console.WriteLine(xFEIntgPsVector);
            Console.WriteLine(yFEIntgPsVector);
            Console.WriteLine(dNdksiMatrix);
            Console.WriteLine(dNdetaMatrix);
            Console.WriteLine(dydetaVector);
            Console.WriteLine(dydksiVector);
            Console.WriteLine(dxdetaVector);
            Console.WriteLine(dxdksiVector);
            Console.WriteLine(inverseJacobianMatrix);
            Console.ReadKey();
        }

        private static void ReadKsiEta()
        {
            JObject ksiEtaJObject = JObject.Parse(File.ReadAllText(@"..\..\ksi_eta.json"));
            string[] ksiStrings = ((JArray) ksiEtaJObject["ksi"]).Select(jv => (string) jv).ToArray();
            string[] etaStrings = ((JArray) ksiEtaJObject["eta"]).Select(jv => (string) jv).ToArray();

            Expression ksiExpression = new Expression();
            Expression etaExpression = new Expression();

            for (int i = 0; i < 4; i++)
            {
                ksiExpression.setExpressionString(ksiStrings[i]);
                etaExpression.setExpressionString(etaStrings[i]);

                ksiVector[i] = ksiExpression.calculate();
                etaVector[i] = etaExpression.calculate();
            }
        }

        private static void CalculateShapeFunctions4X4()
        {
            for (int i = 0; i < 4; i++)
            {
                shapeFunctionsNMatrix[i, 0] = 0.25 * (1 - ksiVector[i]) * (1 - etaVector[i]);
                shapeFunctionsNMatrix[i, 1] = 0.25 * (1 + ksiVector[i]) * (1 - etaVector[i]);
                shapeFunctionsNMatrix[i, 2] = 0.25 * (1 + ksiVector[i]) * (1 + etaVector[i]);
                shapeFunctionsNMatrix[i, 3] = 0.25 * (1 - ksiVector[i]) * (1 + etaVector[i]);
            }
        }

        private static void CalculateIntegrationPoints()
        {
            xFEIntgPsVector = shapeFunctionsNMatrix * xFEPsVector;
            yFEIntgPsVector = shapeFunctionsNMatrix * yFEPsVector;
        }

        private static void CalculatePD_dNdKsi_dNdEta() // dN/d(ksi)  dN/d(eta)
        {
            for (int i = 0; i < 4; i++)
            {
                dNdksiMatrix[i, 0] = -0.25 * (1 - etaVector[i]);
                dNdksiMatrix[i, 1] = 0.25 * (1 - etaVector[i]);
                dNdksiMatrix[i, 2] = 0.25 * (1 + etaVector[i]);
                dNdksiMatrix[i, 3] = -0.25 * (1 + etaVector[i]);

                dNdetaMatrix[i, 0] = -0.25 * (1 - ksiVector[i]);
                dNdetaMatrix[i, 1] = -0.25 * (1 + ksiVector[i]);
                dNdetaMatrix[i, 2] = 0.25 * (1 + ksiVector[i]);
                dNdetaMatrix[i, 3] = 0.25 * (1 - ksiVector[i]);
            }
        }

        private static void CalculateJacobianMatrxi()
        {
            for (int i = 0; i < 4; i++)
            {
                dydetaVector[i] = dNdetaMatrix.Row(i) * yFEPsVector;
                dydksiVector[i] = dNdksiMatrix.Row(i) * yFEPsVector;
                dxdetaVector[i] = dNdetaMatrix.Row(i) * xFEPsVector;
                dxdksiVector[i] = dNdksiMatrix.Row(i) * xFEPsVector;
            }

            JacobianMatrix.SetColumn(0, dxdksiVector);
            JacobianMatrix.SetColumn(1, dydksiVector);
            JacobianMatrix.SetColumn(2, dxdetaVector);
            JacobianMatrix.SetColumn(3, dydetaVector);
        }

        private static void CalculateInverseJacobianMatrix()
        {
            Vector<double> jacobianDeterminantVector = Vector<double>.Build.Dense(4);

            inverseJacobianMatrix.SetColumn(0, dydetaVector);
            inverseJacobianMatrix.SetColumn(1, dydksiVector * -1);
            inverseJacobianMatrix.SetColumn(2, dxdetaVector * -1);
            inverseJacobianMatrix.SetColumn(3, dxdksiVector);

            /*double[] tmpJDetArray = {}
            Matrix<double> tmpJDetMatrix = Matrix<double>.Build.Dense(2, 2, new double[] { 1, 2, 3, 4 });
            Console.WriteLine(tmpJDet);*/

            for (int i = 0; i < 4; i++)
            {
                
            }
        }
    }
}