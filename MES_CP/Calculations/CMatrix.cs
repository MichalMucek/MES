using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace MES_CP.Calculations
{
    static class CMatrix
    {
        private static readonly double C = 700.0;
        private static readonly double RO = 7800.0;

        public static Matrix<double> Calculate()
        {
            Matrix<double> cMatrix = Matrix<double>.Build.Dense(4, 4);

            for (int i = 0; i < 4; i++)
            {
                cMatrix += C * RO * HMatrix.shapeFunctionsNMatrix.Row(i).ToColumnMatrix() *
                           HMatrix.shapeFunctionsNMatrix.Row(i).ToRowMatrix() * HMatrix.jacobianDeterminantVector[i];
            }

            return cMatrix;
        }
    }
}
