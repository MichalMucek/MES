using System.IO;
using MathNet.Numerics.LinearAlgebra;
using Newtonsoft.Json.Linq;
using org.mariuszgromada.math.mxparser;

namespace MES_CP.Calculations
{
    internal static class HMatricBC
    {
        private static Vector<double>[] ksiVectors =
        {
            Vector<double>.Build.Dense(2),
            Vector<double>.Build.Dense(2),
            Vector<double>.Build.Dense(2),
            Vector<double>.Build.Dense(2)
        };

        private static Vector<double>[] etaVectors =
        {
            Vector<double>.Build.Dense(2),
            Vector<double>.Build.Dense(2),
            Vector<double>.Build.Dense(2),
            Vector<double>.Build.Dense(2)
        };

        public static Matrix<double>[] ShapeFunctionsMatrices { get; }=
        {
            Matrix<double>.Build.Dense(2, 4),
            Matrix<double>.Build.Dense(2, 4),
            Matrix<double>.Build.Dense(2, 4),
            Matrix<double>.Build.Dense(2, 4)
        };

        private static Matrix<double>[] nvecNvecTdSMatrices = // {N}*{N}^T
        {
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4)
        };

        private static Matrix<double> sumOfNvecNvecTdSMatrix = Matrix<double>.Build.Dense(4, 4);


        public static Matrix<double> Calculate(Element element)
        {
            var hBCMatrix = Matrix<double>.Build.Dense(4, 4);
            var alpha = element.InitialData.Alpha;

            ReadKsiEta();
            CalculateShapeFunctions();
            CalculateNvecNvecTdS(element.SidesLengths);
            CalculateSumOfNvecNvecTdS(element.BoundarySides);

            hBCMatrix = alpha * sumOfNvecNvecTdSMatrix;

            return hBCMatrix;
        }

        private static void ReadKsiEta()
        {
            JObject ksi_eta_BC_JObject = JObject.Parse(File.ReadAllText(@"..\..\data\ksi_eta_BC.json"));
            JArray sidesJArray = (JArray) ksi_eta_BC_JObject["Side"];
            string[,] ksiStrings = new string[4, 2];
            string[,] etaStrings = new string[4, 2];

            for (int i = 0; i < 4; i++) //Surface
            {
                for (int j = 0; j < 2; j++) //Point
                {
                    ksiStrings[i, j] = sidesJArray[i]["ksi"][j].ToString();
                    etaStrings[i, j] = sidesJArray[i]["eta"][j].ToString();
                }
            }

            Expression ksiExpression = new Expression();
            Expression etaExpression = new Expression();

            for (int i = 0; i < 4; i++) //Side
            {
                for (int j = 0; j < 2; j++) //Node
                {
                    ksiExpression.setExpressionString(ksiStrings[i, j]);
                    etaExpression.setExpressionString(etaStrings[i, j]);

                    ksiVectors[i][j] = ksiExpression.calculate();
                    etaVectors[i][j] = etaExpression.calculate();
                }
            }
        }

        private static void CalculateShapeFunctions()
        {
            for (int i = 0; i < 4; i++) //Side
            {
                for (int j = 0; j < 2; j++) //Node
                {
                    ShapeFunctionsMatrices[i][j, 0] = 0.25 * (1 - ksiVectors[i][j]) * (1 - etaVectors[i][j]); //N1
                    ShapeFunctionsMatrices[i][j, 1] = 0.25 * (1 + ksiVectors[i][j]) * (1 - etaVectors[i][j]); //N2
                    ShapeFunctionsMatrices[i][j, 2] = 0.25 * (1 + ksiVectors[i][j]) * (1 + etaVectors[i][j]); //N3
                    ShapeFunctionsMatrices[i][j, 3] = 0.25 * (1 - ksiVectors[i][j]) * (1 + etaVectors[i][j]); //N4
                }
            }
        }

        private static void CalculateNvecNvecTdS(double[] sidesLengths)
        {
            for (int i = 0; i < 4; i++) //Side
            {
                nvecNvecTdSMatrices[i] = ShapeFunctionsMatrices[i].Transpose() * ShapeFunctionsMatrices[i];
                nvecNvecTdSMatrices[i] *= sidesLengths[i] / 2;
            }
        }

        private static void CalculateSumOfNvecNvecTdS(bool[] boundarySides)
        {
            sumOfNvecNvecTdSMatrix = Matrix<double>.Build.Dense(4, 4);

            for (int i = 0; i < 4; i++) //Side
                if (boundarySides[i]) sumOfNvecNvecTdSMatrix += nvecNvecTdSMatrices[i];
        }
    }
}