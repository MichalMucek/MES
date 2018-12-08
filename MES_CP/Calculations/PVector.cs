using System.IO;
using MathNet.Numerics.LinearAlgebra;
using Newtonsoft.Json.Linq;
using org.mariuszgromada.math.mxparser;

namespace MES_CP.Calculations
{
    static class PVector
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

        private static Matrix<double>[] shapeFunctionsMatrices =
        {
            Matrix<double>.Build.Dense(2, 4),
            Matrix<double>.Build.Dense(2, 4),
            Matrix<double>.Build.Dense(2, 4),
            Matrix<double>.Build.Dense(2, 4)
        };

        private static Vector<double> sumOfNvecdSVector;

        public static Vector<double> Calculate(Element element)
        {
            var pVector = Vector<double>.Build.Dense(4);
            var alpha = element.InitialData.Alpha;
            var ambientTemperature = element.InitialData.AmbientTemperature;

            ReadKsiEta();
            CalculateShapeFunctions();
            CalculateSumOfNvecdS(element.SidesLengths, element.BoundarySides);

            pVector = -(alpha * sumOfNvecdSVector * ambientTemperature);

            return pVector;
        }

        private static void ReadKsiEta()
        {
            JObject ksi_eta_BC_JObject = JObject.Parse(File.ReadAllText(@"..\..\data\ksi_eta_BC.json"));
            JArray sidesJArray = (JArray)ksi_eta_BC_JObject["Side"];
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
                    shapeFunctionsMatrices[i][j, 0] = 0.25 * (1 - ksiVectors[i][j]) * (1 - etaVectors[i][j]); //N1
                    shapeFunctionsMatrices[i][j, 1] = 0.25 * (1 + ksiVectors[i][j]) * (1 - etaVectors[i][j]); //N2
                    shapeFunctionsMatrices[i][j, 2] = 0.25 * (1 + ksiVectors[i][j]) * (1 + etaVectors[i][j]); //N3
                    shapeFunctionsMatrices[i][j, 3] = 0.25 * (1 - ksiVectors[i][j]) * (1 + etaVectors[i][j]); //N4
                }
            }
        }

        private static void CalculateSumOfNvecdS(double[] sideLengths, bool[] boundarySides)
        {
            sumOfNvecdSVector = Vector<double>.Build.Dense(4);

            for (int i = 0; i < 4; i++)
            {
                if (boundarySides[i])
                {
                    sumOfNvecdSVector += (shapeFunctionsMatrices[i].Row(0) + shapeFunctionsMatrices[i].Row(1)) *
                                         (sideLengths[i] / 2);
                }
            }
        }
    }
}
