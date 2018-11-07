using System;
using System.IO;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using Newtonsoft.Json.Linq;
using org.mariuszgromada.math.mxparser;

namespace MES_CP
{
    static class Program
    {
        private const double K = 30.0;

        private static Vector<double> xFEPsVector = Vector<double>.Build.Dense(new double[] { 0.001, 0.025, 0.025, 0.0 }); //FEPs - Finite Element Points
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
        //*************************************************************************************************************//
        private static Matrix<double> jacobianMatrix = Matrix<double>.Build.Dense(4, 4);
        private static Vector<double> jacobianDeterminantVector = Vector<double>.Build.Dense(4);
        private static Matrix<double> inverseJacobianMatrix = Matrix<double>.Build.Dense(4, 4);

        /*  >> od lewej do prawej, z góry na dół <<

            INVERS JACOBIAN MATRIX                                  JACOBIAN MATRIX    
        
                    pkt. całk.                                              pkt. całk.
            pochodne----------  dy/deta dy/dksi dx/deta dx/dksi     pochodne----------  dx/dksi dy/dksi dx/deta dy/deta
                    1           J-1_2_2 J-1_1_2 J-1_2_1 J-1_1_1             1           J_1_1   J_1_2   J_2_1   J_2_2
                    2           J-1_2_2 J-1_1_2 J-1_2_1 J-1_1_1             2           J_1_1   J_1_2   J_2_1   J_2_2
                    3           J-1_2_2 J-1_1_2 J-1_2_1 J-1_1_1             3           J_1_1   J_1_2   J_2_1   J_2_2
                    4           J-1_2_2 J-1_1_2 J-1_2_1 J-1_1_1             4           J_1_1   J_1_2   J_2_1   J_2_2

        */

        private static Matrix<double> dNdxMatrix = Matrix<double>.Build.Dense(4, 4);
        private static Matrix<double> dNdyMatrix = Matrix<double>.Build.Dense(4, 4);
        private static Matrix<double>[] dNdxdNdxTMatrices = new Matrix<double>[4]
        {
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4)
        };
        private static Matrix<double>[] dNdydNdyTMatrices = new Matrix<double>[4]
        {
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4)
        };

        private static Matrix<double> hMatrix = Matrix<double>.Build.Dense(4, 4);

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
            CalculateJacobianMatrix();
            CalculateInverseJacobianMatrix();
            Calculate_dNdx_dNdy();
            Calculate_dNdxdNdxT_dNdydNdyT();
            CalculateH();

            Console.WriteLine($@"x -> {xFEPsVector}");
            Console.WriteLine($@"y -> {yFEPsVector}");
            Console.WriteLine($@"ksi -> {ksiVector}");
            Console.WriteLine($@"eta -> {etaVector}");
            Console.WriteLine($@"Funkcje ksztaltu -> {shapeFunctionsNMatrix}");
            Console.WriteLine($@"Punkty calkowania (x) -> {xFEIntgPsVector}");
            Console.WriteLine($@"Punkty calkowania (y) -> {yFEIntgPsVector}");
            Console.WriteLine($@"dy/deta -> {dydetaVector}");
            Console.WriteLine($@"dy/dksi -> {dydksiVector}");
            Console.WriteLine($@"dx/deta -> {dxdetaVector}");
            Console.WriteLine($@"dx/dksi -> {dxdksiVector}");
            Console.WriteLine($@"dN/dksi -> {dNdksiMatrix}");
            Console.WriteLine($@"dN/deta -> {dNdksiMatrix}");
            Console.WriteLine($@"Macierz Jacobiego -> {jacobianMatrix.Transpose()}");
            Console.WriteLine($@"Jakobian -> {jacobianDeterminantVector}");
            Console.WriteLine($@"Odwrocona macierz Jacobiego -> {inverseJacobianMatrix.Transpose()}");
            Console.WriteLine($@"dN/dx -> {dNdxMatrix}");
            Console.WriteLine($@"dN/dy -> {dNdyMatrix}");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($@"(dN/dx)*(dN/dx)^T [{i}] -> {dNdxdNdxTMatrices[i]}");
                Console.WriteLine($@"(dN/dy)*(dN/dy)^T [{i}] -> {dNdydNdyTMatrices[i]}");
            }
            Console.WriteLine($@"Macierz H -> {hMatrix}");
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

        private static void CalculateJacobianMatrix()
        {
            for (int i = 0; i < 4; i++)
            {
                dydetaVector[i] = dNdetaMatrix.Row(i) * yFEPsVector;
                dydksiVector[i] = dNdksiMatrix.Row(i) * yFEPsVector;
                dxdetaVector[i] = dNdetaMatrix.Row(i) * xFEPsVector;
                dxdksiVector[i] = dNdksiMatrix.Row(i) * xFEPsVector;
            }

            jacobianMatrix.SetColumn(0, dxdksiVector);
            jacobianMatrix.SetColumn(1, dydksiVector);
            jacobianMatrix.SetColumn(2, dxdetaVector);
            jacobianMatrix.SetColumn(3, dydetaVector);
        }

        private static void CalculateInverseJacobianMatrix()
        {
            inverseJacobianMatrix.SetColumn(0, dydetaVector);
            inverseJacobianMatrix.SetColumn(1, -dydksiVector);
            inverseJacobianMatrix.SetColumn(2, -dxdetaVector);
            inverseJacobianMatrix.SetColumn(3, dxdksiVector);

            double[] actualJacobianArray = new double[4];
            Matrix<double> actualJacobianMatrix = Matrix<double>.Build.Dense(2, 2, actualJacobianArray); //Macierz jest powiązana z tablicą, wczytywana kolumnami

            for (int i = 0; i < 4; i++)
            {
                actualJacobianArray[0] = dxdksiVector[i];
                actualJacobianArray[1] = dxdetaVector[i];
                actualJacobianArray[2] = dydksiVector[i];
                actualJacobianArray[3] = dydetaVector[i];

                jacobianDeterminantVector[i] = actualJacobianMatrix.Determinant();
                inverseJacobianMatrix.SetRow(i, (1.0 / jacobianDeterminantVector[i]) * inverseJacobianMatrix.Row(i));
            }
        }

        private static void Calculate_dNdx_dNdy()
        {
            double[] actualInverseJacobianArray = new double[4];
            double[] actualdNdKsidNdEtaArray = new double[2];
            Matrix<double> actualInverseJacobianMatrix = Matrix<double>.Build.Dense(2, 2, actualInverseJacobianArray);
            Matrix<double> actualdNdKsidNdEtaMatrix = Matrix<double>.Build.Dense(2, 1, actualdNdKsidNdEtaArray);
            Matrix<double> actualdNdxdNdyMatrix = Matrix<double>.Build.Dense(2, 2, actualInverseJacobianArray);

            for (int i = 0; i < 4; i++) //i <- punkt całkowania / integration point
            {
                actualInverseJacobianArray[0] = inverseJacobianMatrix[i, 0];
                actualInverseJacobianArray[1] = inverseJacobianMatrix[i, 2];
                actualInverseJacobianArray[2] = inverseJacobianMatrix[i, 1];
                actualInverseJacobianArray[3] = inverseJacobianMatrix[i, 3];

                for (int j = 0; j < 4; j++) //j <- funkcja kształtu / shape function
                {
                    actualdNdKsidNdEtaArray[0] = dNdksiMatrix[i, j];
                    actualdNdKsidNdEtaArray[1] = dNdetaMatrix[i, j];

                    actualdNdxdNdyMatrix = actualInverseJacobianMatrix * actualdNdKsidNdEtaMatrix;

                    dNdxMatrix[i, j] = actualdNdxdNdyMatrix[0, 0];
                    dNdyMatrix[i, j] = actualdNdxdNdyMatrix[1, 0];
                }
            }
        }

        private static void Calculate_dNdxdNdxT_dNdydNdyT()
        {
            for (int i = 0; i < 4; i++)
            {
                dNdxdNdxTMatrices[i] = dNdxMatrix.Row(i).ToColumnMatrix() * dNdxMatrix.Row(i).ToRowMatrix();
                dNdydNdyTMatrices[i] = dNdyMatrix.Row(i).ToColumnMatrix() * dNdyMatrix.Row(i).ToRowMatrix();
            }
        }

        private static void CalculateH()
        {
            Matrix<double>[] dNdxdNdxTPlusdNdydNdyTMatrices = new Matrix<double>[4];

            for (int i = 0; i < 4; i++)
            {
                dNdxdNdxTPlusdNdydNdyTMatrices[i] =
                    ((dNdxdNdxTMatrices[i] + dNdydNdyTMatrices[i]) * jacobianDeterminantVector[i]) * K;

                hMatrix += dNdxdNdxTPlusdNdydNdyTMatrices[i];
            }
        }
    }
}