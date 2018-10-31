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
        private static Vector<double> dydetaMatrix = Vector<double>.Build.Dense(4); //   {   dy/d(eta)               }
        private static Vector<double> dydksiMatrix = Vector<double>.Build.Dense(4); //   {   -//-        dy/d(ksi)   }
        private static Vector<double> dxdetaMatrix = Vector<double>.Build.Dense(4); //   {   dx/d(eta)   -//-        }
        private static Vector<double> dxdksiMatrix = Vector<double>.Build.Dense(4); //   {   -//-        dx/d(ksi)   }
        //*************************************************************************************************************//
        private static Matrix<double> dNdksiMatrix = Matrix<double>.Build.Dense(4, 4); //   {   dN/d(ksi)   }
        private static Matrix<double> dNdetaMatrix = Matrix<double>.Build.Dense(4, 4); //   {   dN/d(eta)   }

        private static Matrix<double> inverseJacobianMatrix = Matrix<double>.Build.Dense(4, 4);

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

        private static void CalculateInverseJacobian()
        {
            
        }
    }
}