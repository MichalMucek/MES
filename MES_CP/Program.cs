using System;

namespace MES_CP
{
    static class Program
    {
        

        static void Main(string[] args)
        {
            Grid grid = new Grid(@"..\..\initialData.json");

            Console.WriteLine(grid);

            /*Console.WriteLine($@"X -> {xFEPsVector}");
            Console.WriteLine($@"Y -> {yFEPsVector}");
            Console.WriteLine($@"ksi -> {ksiVector}");
            Console.WriteLine($@"eta -> {etaVector}");
            Console.WriteLine($@"Funkcje ksztaltu -> {shapeFunctionsNMatrix}");
            Console.WriteLine($@"Punkty calkowania (X) -> {xFEIntgPsVector}");
            Console.WriteLine($@"Punkty calkowania (Y) -> {yFEIntgPsVector}");
            Console.WriteLine($@"dy/deta -> {dydetaVector}");
            Console.WriteLine($@"dy/dksi -> {dydksiVector}");
            Console.WriteLine($@"dx/deta -> {dxdetaVector}");
            Console.WriteLine($@"dx/dksi -> {dxdksiVector}");
            Console.WriteLine($@"dN/dksi -> {dNdksiMatrix}");
            Console.WriteLine($@"dN/deta -> {dNdksiMatrix}");
            for (int i = 0; i < 4; i++)
                Console.WriteLine($@"Macierz Jacobiego [{i}] -> {jacobianMatrices[i]}");
            Console.WriteLine($@"Jakobian -> {jacobianDeterminantVector}");
            for (int i = 0; i < 4; i++)
                Console.WriteLine($@"Odwrocona macierz Jacobiego [{i}] -> {inverseJacobianMatrices[i]}");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine($@"[(dN/dx)(dN/dy)][{i + 1}, {j + 1}] -> {dNdxdNdyMatrices[i, j]}");
                }
            }
            Console.WriteLine($@"dN/dx -> {dNdxMatrix}");
            Console.WriteLine($@"dN/dy -> {dNdyMatrix}");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($@"(dN/dx)*(dN/dx)^T [{i}] -> {dNdxdNdxTMatrices[i]}");
                Console.WriteLine($@"(dN/dy)*(dN/dy)^T [{i}] -> {dNdydNdyTMatrices[i]}");
            }
            Console.WriteLine($@"Macierz Height -> {hMatrix}");*/
            Console.ReadKey();
        }
    }
}