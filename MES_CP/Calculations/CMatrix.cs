using MathNet.Numerics.LinearAlgebra;

namespace MES_CP.Calculations
{
    static class CMatrix
    {
        private const int FiniteElementPointsCount = 4;

        public static Matrix<double> Calculate(double specificHeat, double density)
        {
            Matrix<double> cMatrix = Matrix<double>.Build.Dense(FiniteElementPointsCount, FiniteElementPointsCount);

            for (int i = 0; i < FiniteElementPointsCount; i++)
            {
                cMatrix += specificHeat * density * HMatrix.ShapeFunctionsNMatrix.Row(i).ToColumnMatrix() *
                           HMatrix.ShapeFunctionsNMatrix.Row(i).ToRowMatrix() * HMatrix.JacobianDeterminantVector[i];
            }

            return cMatrix;
        }
    }
}
