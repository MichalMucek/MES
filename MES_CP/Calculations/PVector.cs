using System.IO;
using MathNet.Numerics.LinearAlgebra;
using Newtonsoft.Json.Linq;
using org.mariuszgromada.math.mxparser;

namespace MES_CP.Calculations
{
    static class PVector
    {
        private static Vector<double> sumOfNvecdSVector;

        public static Vector<double> Calculate(Element element)
        {
            var pVector = Vector<double>.Build.Dense(4);
            var alpha = element.InitialData.Alpha;
            var ambientTemperature = element.InitialData.AmbientTemperature;

            CalculateSumOfNvecdS(element.SidesLengths, element.BoundarySides);

            pVector = alpha * sumOfNvecdSVector * ambientTemperature;

            return pVector;
        }

        private static void CalculateSumOfNvecdS(double[] sideLengths, bool[] boundarySides)
        {
            var shapeFunctionsMatrices = HMatricBC.ShapeFunctionsMatrices;
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
