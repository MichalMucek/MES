using MathNet.Numerics.LinearAlgebra;

namespace MES_CP.Calculations
{
    static class PVector
    {
        private static Vector<double> sumOfNvecdSVector;

        public static Vector<double> Calculate(Element element)
        {
            var pVector = Vector<double>.Build.Dense(Element.SidesCount);
            var convectionCoefficient = element.InitialData.ConvectionCoefficient;
            var ambientTemperature = element.InitialData.AmbientTemperature;

            CalculateSumOfNvecdS(element.SidesLengths, element.BoundarySides);

            pVector = convectionCoefficient * sumOfNvecdSVector * ambientTemperature;

            return pVector;
        }

        private static void CalculateSumOfNvecdS(double[] sideLengths, bool[] boundarySides)
        {
            var shapeFunctionsMatrices = HMatrixBC2D.ShapeFunctionsMatrices;
            sumOfNvecdSVector = Vector<double>.Build.Dense(Element.SidesCount);

            for (int i = 0; i < Element.SidesCount; i++)
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
