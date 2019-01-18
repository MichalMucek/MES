using MathNet.Numerics.LinearAlgebra;

namespace MES_CP.Calculations
{
    static class CMatrix
    {
        public static Matrix<double> Calculate(double specificHeat, double density)
        {
            Matrix<double> cMatrix = Matrix<double>.Build.Dense(4, 4);

            for (int i = 0; i < 4; i++)
            {
                cMatrix += specificHeat * density * HMatrix.ShapeFunctionsNMatrix.Row(i).ToColumnMatrix() *
                           HMatrix.ShapeFunctionsNMatrix.Row(i).ToRowMatrix() * HMatrix.jacobianDeterminantVector[i];
            }

            return cMatrix.Clone();
        }
    }
}
