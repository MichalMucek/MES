using System;
using MathNet.Numerics.LinearAlgebra;

namespace MES_CP.Calculations
{
    static class HMatrix
    {
        private static Vector<double> xFEPsVector = Vector<double>.Build.Dense(4); //FEPs - Finite Element Points
        private static Vector<double> yFEPsVector = Vector<double>.Build.Dense(4); //FEPs - Finite Element Points
        private static Vector<double> ksiVector = Vector<double>.Build.DenseOfArray(new double[]
        {
            -1 / Math.Sqrt(3), 1 / Math.Sqrt(3), 1 / Math.Sqrt(3), -1 / Math.Sqrt(3),
        });
        private static Vector<double> etaVector = Vector<double>.Build.DenseOfArray(new double[]
        {
            -1 / Math.Sqrt(3), -1 / Math.Sqrt(3), 1 / Math.Sqrt(3), 1 / Math.Sqrt(3),
        });
        public static Matrix<double> ShapeFunctionsNMatrix { get; } = Matrix<double>.Build.Dense(4, 4);
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
        private static Matrix<double>[,] dNdksidNdetaMatrices = 
        {
            { Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1) },
            { Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1) },
            { Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1) },
            { Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1) }
        };
        //*************************************************************************************************************//
        private static Matrix<double>[] jacobianMatrices = 
        {
            Matrix<double>.Build.Dense(2, 2),
            Matrix<double>.Build.Dense(2, 2),
            Matrix<double>.Build.Dense(2, 2),
            Matrix<double>.Build.Dense(2, 2)
        };

        public static Vector<double> jacobianDeterminantVector { get; } = Vector<double>.Build.Dense(4);
        private static Matrix<double>[] inverseJacobianMatrices = 
        {
            Matrix<double>.Build.Dense(2, 2),
            Matrix<double>.Build.Dense(2, 2),
            Matrix<double>.Build.Dense(2, 2),
            Matrix<double>.Build.Dense(2, 2)
        };

        /*  >> przełożone z PDF-a z Jakobianem, wiersz po wierszu <<

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
        private static Matrix<double>[,] dNdxdNdyMatrices = //4x4
        {
            { Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1) },
            { Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1) },
            { Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1) },
            { Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1) }
        };

        private static Matrix<double>[] dNdxdNdxTMatrices = // {dN/dx}*{dN/dx}^T 
        { 
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4)
        };

        private static Matrix<double>[] dNdydNdyTMatrices = // {dN/dy}*{dN/dy}^T 
        {
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4),
            Matrix<double>.Build.Dense(4, 4)
        };

        public static Matrix<double> Calculate(Element element, double k)
        {
            var hMatrix = Matrix<double>.Build.Dense(4, 4);

            SetFiniteElementPoints(element.Nodes);
            CalculateShapeFunctions();
            CalculateIntegrationPoints();
            Calculate_dNdksi_dNdeta_Matrices();
            CalculateJaobianMatrices();
            CalculateInverseJacobianMatrices();
            Calculate_dNdx_dNdy();
            Calculate_dNdxdNdxT_dNdydNdyT();
            CalculateJacobianDeterminantVector();

            for (int i = 0; i < 4; i++) // k(t) * ({dN/dx}*{dN/dx}^T + {dN/dy}*{dN/dy}^T) * Det(J)
                hMatrix += k * (dNdxdNdxTMatrices[i] + dNdydNdyTMatrices[i]) * jacobianDeterminantVector[i];

            return hMatrix.Clone();
        }

        private static void SetFiniteElementPoints(Node[] nodes)
        {
            for (int i = 0; i < 4; i++)
            {
                xFEPsVector[i] = nodes[i].X;
                yFEPsVector[i] = nodes[i].Y;
            }
        }

        private static void CalculateShapeFunctions()
        {
            for (int i = 0; i < 4; i++)
            {
                ShapeFunctionsNMatrix[i, 0] = 0.25 * (1 - ksiVector[i]) * (1 - etaVector[i]);
                ShapeFunctionsNMatrix[i, 1] = 0.25 * (1 + ksiVector[i]) * (1 - etaVector[i]);
                ShapeFunctionsNMatrix[i, 2] = 0.25 * (1 + ksiVector[i]) * (1 + etaVector[i]);
                ShapeFunctionsNMatrix[i, 3] = 0.25 * (1 - ksiVector[i]) * (1 + etaVector[i]);
            }
        }

        private static void CalculateIntegrationPoints()
        {
            xFEIntgPsVector = ShapeFunctionsNMatrix * xFEPsVector;
            yFEIntgPsVector = ShapeFunctionsNMatrix * yFEPsVector;
        }

        private static void Calculate_dNdksi_dNdeta_Matrices()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dNdksiMatrix[i, 0] = -0.25 * (1 - etaVector[i]);
                    dNdksiMatrix[i, 1] = 0.25 * (1 - etaVector[i]);
                    dNdksiMatrix[i, 2] = 0.25 * (1 + etaVector[i]);
                    dNdksiMatrix[i, 3] = -0.25 * (1 + etaVector[i]);

                    dNdetaMatrix[i, 0] = -0.25 * (1 - ksiVector[i]);
                    dNdetaMatrix[i, 1] = -0.25 * (1 + ksiVector[i]);
                    dNdetaMatrix[i, 2] = 0.25 * (1 + ksiVector[i]);
                    dNdetaMatrix[i, 3] = 0.25 * (1 - ksiVector[i]);

                    dNdksidNdetaMatrices[i, j][0, 0] = dNdksiMatrix[i, j];
                    dNdksidNdetaMatrices[i, j][1, 0] = dNdetaMatrix[i, j];
                }
            }
        }

        private static void CalculateJaobianMatrices()
        {
            for (int i = 0; i < 4; i++)
            {
                dxdksiVector[i] = dNdksiMatrix.Row(i) * xFEPsVector;
                dydksiVector[i] = dNdksiMatrix.Row(i) * yFEPsVector;
                dxdetaVector[i] = dNdetaMatrix.Row(i) * xFEPsVector;
                dydetaVector[i] = dNdetaMatrix.Row(i) * yFEPsVector;

                jacobianMatrices[i][0, 0] = dxdksiVector[i]; jacobianMatrices[i][0, 1] = dydksiVector[i];
                jacobianMatrices[i][1, 0] = dxdetaVector[i]; jacobianMatrices[i][1, 1] = dydetaVector[i];
            }
        }

        private static void CalculateInverseJacobianMatrices()
        {
            for (int i = 0; i < 4; i++)
                inverseJacobianMatrices[i] = jacobianMatrices[i].Inverse();
        }

        private static void Calculate_dNdx_dNdy()
        {
            for (int i = 0; i < 4; i++) //i <- punkt całkowania / integration point
            {
                for (int j = 0; j < 4; j++) //j <- funkcja kształtu / shape function
                {
                    dNdxdNdyMatrices[i, j] = inverseJacobianMatrices[i] * dNdksidNdetaMatrices[i, j];

                    dNdxMatrix[i, j] = dNdxdNdyMatrices[i, j][0, 0];
                    dNdyMatrix[i, j] = dNdxdNdyMatrices[i, j][1, 0];
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

        private static void CalculateJacobianDeterminantVector()
        {
            for (int i = 0; i < 4; i++)
                jacobianDeterminantVector[i] = jacobianMatrices[i].Determinant();
        }

        public static void PrintDetails()
        {
            Console.WriteLine($@"X -> {xFEPsVector}");
            Console.WriteLine($@"Y -> {yFEPsVector}");
            Console.WriteLine($@"ksi -> {ksiVector}");
            Console.WriteLine($@"eta -> {etaVector}");
            Console.WriteLine($@"Funkcje ksztaltu -> {ShapeFunctionsNMatrix}");
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
        }
    }
}