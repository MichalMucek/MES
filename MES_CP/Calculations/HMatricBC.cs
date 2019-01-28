using System;
using MathNet.Numerics.LinearAlgebra;

namespace MES_CP.Calculations
{
    internal static class HMatricBC
    {
        private static readonly Vector<double>[] ksiVectors =
        {
            Vector<double>.Build.DenseOfArray(new double[] {-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)}),
            Vector<double>.Build.DenseOfArray(new double[] {1.0, 1.0}),
            Vector<double>.Build.DenseOfArray(new double[] {1 / Math.Sqrt(3), -1 / Math.Sqrt(3)}),
            Vector<double>.Build.DenseOfArray(new double[] {-1.0, -1.0}),
        };

        private static readonly Vector<double>[] etaVectors =
        {
            Vector<double>.Build.DenseOfArray(new double[] {-1.0, -1.0}),
            Vector<double>.Build.DenseOfArray(new double[] {-1 / Math.Sqrt(3), 1 / Math.Sqrt(3)}),
            Vector<double>.Build.DenseOfArray(new double[] {1.0, 1.0}),
            Vector<double>.Build.DenseOfArray(new double[] {1 / Math.Sqrt(3), -1 / Math.Sqrt(3)}),
        };

        public static Matrix<double>[] ShapeFunctionsMatrices { get; } =
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
            var convectionCoefficient = element.InitialData.ConvectionCoefficient;

            CalculateShapeFunctions();
            CalculateNvecNvecTdS(element.SidesLengths);
            CalculateSumOfNvecNvecTdS(element.BoundarySides);

            hBCMatrix = convectionCoefficient * sumOfNvecNvecTdSMatrix;

            return hBCMatrix;
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