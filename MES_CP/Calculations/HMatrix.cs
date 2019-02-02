using System;
using MathNet.Numerics.LinearAlgebra;

namespace MES_CP.Calculations
{
    static class HMatrix
    {
        private const int FiniteElementPointsCount = 4;
        private const int ShapeFunctionsCount = 4;

        private static readonly Vector<double> xFiniteElementPointsVector = Vector<double>.Build.Dense(FiniteElementPointsCount);
        private static readonly Vector<double> yFiniteEelementPointsVector = Vector<double>.Build.Dense(FiniteElementPointsCount);
        private static readonly Vector<double> ksiVector = Vector<double>.Build.DenseOfArray(new double[]
        {
            -1 / Math.Sqrt(3), 1 / Math.Sqrt(3), 1 / Math.Sqrt(3), -1 / Math.Sqrt(3),
        });
        private static readonly Vector<double> etaVector = Vector<double>.Build.DenseOfArray(new double[]
        {
            -1 / Math.Sqrt(3), -1 / Math.Sqrt(3), 1 / Math.Sqrt(3), 1 / Math.Sqrt(3),
        });
        public static Matrix<double> ShapeFunctionsNMatrix { get; } = Matrix<double>.Build.Dense(FiniteElementPointsCount, ShapeFunctionsCount);

        //Transformation Jacobian
        private static readonly Vector<double> dydetaVector = Vector<double>.Build.Dense(FiniteElementPointsCount); //   {   dy/d(eta)               }
        private static readonly Vector<double> dydksiVector = Vector<double>.Build.Dense(FiniteElementPointsCount); //   {   -//-        dy/d(ksi)   }
        private static readonly Vector<double> dxdetaVector = Vector<double>.Build.Dense(FiniteElementPointsCount); //   {   dx/d(eta)   -//-        }
        private static readonly Vector<double> dxdksiVector = Vector<double>.Build.Dense(FiniteElementPointsCount); //   {   -//-        dx/d(ksi)   }

        private static readonly Matrix<double> dNdksiMatrix = Matrix<double>.Build.Dense(FiniteElementPointsCount, ShapeFunctionsCount); //   {   dN/d(ksi)   }
        private static readonly Matrix<double> dNdetaMatrix = Matrix<double>.Build.Dense(FiniteElementPointsCount, ShapeFunctionsCount); //   {   dN/d(eta)   }
        private static readonly Matrix<double>[,] dNdksidNdetaMatrices =
        {
            { Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1) },
            { Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1) },
            { Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1) },
            { Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1), Matrix<double>.Build.Dense(2, 1) }
        };

        private static readonly Matrix<double>[] jacobianMatrices =
        {
            Matrix<double>.Build.Dense(2, 2),
            Matrix<double>.Build.Dense(2, 2),
            Matrix<double>.Build.Dense(2, 2),
            Matrix<double>.Build.Dense(2, 2)
        };

        public static Vector<double> JacobianDeterminantVector { get; } = Vector<double>.Build.Dense(FiniteElementPointsCount);
        private static readonly Matrix<double>[] inverseJacobianMatrices =
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

        private static readonly Matrix<double> dNdxMatrix = Matrix<double>.Build.Dense(FiniteElementPointsCount, FiniteElementPointsCount);
        private static readonly Matrix<double> dNdyMatrix = Matrix<double>.Build.Dense(FiniteElementPointsCount, FiniteElementPointsCount);

        private static readonly Matrix<double>[] dNdxdNdxTMatrices = // {dN/dx}*{dN/dx}^T 
        {
            Matrix<double>.Build.Dense(ShapeFunctionsCount, ShapeFunctionsCount),
            Matrix<double>.Build.Dense(ShapeFunctionsCount, ShapeFunctionsCount),
            Matrix<double>.Build.Dense(ShapeFunctionsCount, ShapeFunctionsCount),
            Matrix<double>.Build.Dense(ShapeFunctionsCount, ShapeFunctionsCount)
        };

        private static readonly Matrix<double>[] dNdydNdyTMatrices = // {dN/dy}*{dN/dy}^T 
        {
            Matrix<double>.Build.Dense(ShapeFunctionsCount, ShapeFunctionsCount),
            Matrix<double>.Build.Dense(ShapeFunctionsCount, ShapeFunctionsCount),
            Matrix<double>.Build.Dense(ShapeFunctionsCount, ShapeFunctionsCount),
            Matrix<double>.Build.Dense(ShapeFunctionsCount, ShapeFunctionsCount)
        };

        public static Matrix<double> Calculate(Element element, double conductivity)
        {
            var hMatrix = Matrix<double>.Build.Dense(FiniteElementPointsCount, FiniteElementPointsCount);

            SetFiniteElementPoints(element.Nodes);
            CalculateShapeFunctions();
            Calculate_dNdksi_dNdeta_Matrices();
            CalculateJaobianMatrices();
            CalculateInverseJacobianMatrices();
            Calculate_dNdx_dNdy();
            Calculate_dNdxdNdxT_dNdydNdyT();
            CalculateJacobianDeterminantVector();

            for (int i = 0; i < FiniteElementPointsCount; i++) // k(t) * ({dN/dx}*{dN/dx}^T + {dN/dy}*{dN/dy}^T) * Det(J)
                hMatrix += conductivity * (dNdxdNdxTMatrices[i] + dNdydNdyTMatrices[i]) * JacobianDeterminantVector[i];

            return hMatrix.Clone();
        }

        private static void SetFiniteElementPoints(Node[] nodes)
        {
            for (int i = 0; i < FiniteElementPointsCount; i++)
            {
                xFiniteElementPointsVector[i] = nodes[i].X;
                yFiniteEelementPointsVector[i] = nodes[i].Y;
            }
        }

        private static void CalculateShapeFunctions()
        {
            for (int i = 0; i < ShapeFunctionsCount; i++)
            {
                ShapeFunctionsNMatrix[i, 0] = 0.25 * (1 - ksiVector[i]) * (1 - etaVector[i]);
                ShapeFunctionsNMatrix[i, 1] = 0.25 * (1 + ksiVector[i]) * (1 - etaVector[i]);
                ShapeFunctionsNMatrix[i, 2] = 0.25 * (1 + ksiVector[i]) * (1 + etaVector[i]);
                ShapeFunctionsNMatrix[i, 3] = 0.25 * (1 - ksiVector[i]) * (1 + etaVector[i]);
            }
        }

        private static void Calculate_dNdksi_dNdeta_Matrices()
        {
            for (int i = 0; i < FiniteElementPointsCount; i++)
            {
                for (int j = 0; j < ShapeFunctionsCount; j++)
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
            for (int i = 0; i < FiniteElementPointsCount; i++)
            {
                dxdksiVector[i] = dNdksiMatrix.Row(i) * xFiniteElementPointsVector;
                dydksiVector[i] = dNdksiMatrix.Row(i) * yFiniteEelementPointsVector;
                dxdetaVector[i] = dNdetaMatrix.Row(i) * xFiniteElementPointsVector;
                dydetaVector[i] = dNdetaMatrix.Row(i) * yFiniteEelementPointsVector;

                jacobianMatrices[i][0, 0] = dxdksiVector[i]; jacobianMatrices[i][0, 1] = dydksiVector[i];
                jacobianMatrices[i][1, 0] = dxdetaVector[i]; jacobianMatrices[i][1, 1] = dydetaVector[i];
            }
        }

        private static void CalculateInverseJacobianMatrices()
        {
            for (int i = 0; i < FiniteElementPointsCount; i++)
                inverseJacobianMatrices[i] = jacobianMatrices[i].Inverse();
        }

        private static void Calculate_dNdx_dNdy()
        {
            for (int i = 0; i < FiniteElementPointsCount; i++) //i <- punkt całkowania / integration point
            {
                for (int j = 0; j < ShapeFunctionsCount; j++) //j <- funkcja kształtu / shape function
                {
                    dNdxMatrix[i, j] = (inverseJacobianMatrices[i] * dNdksidNdetaMatrices[i, j])[0, 0];
                    dNdyMatrix[i, j] = (inverseJacobianMatrices[i] * dNdksidNdetaMatrices[i, j])[1, 0];
                }
            }
        }

        private static void Calculate_dNdxdNdxT_dNdydNdyT()
        {
            for (int i = 0; i < FiniteElementPointsCount; i++)
            {
                dNdxdNdxTMatrices[i] = dNdxMatrix.Row(i).ToColumnMatrix() * dNdxMatrix.Row(i).ToRowMatrix();
                dNdydNdyTMatrices[i] = dNdyMatrix.Row(i).ToColumnMatrix() * dNdyMatrix.Row(i).ToRowMatrix();
            }
        }

        private static void CalculateJacobianDeterminantVector()
        {
            for (int i = 0; i < FiniteElementPointsCount; i++)
                JacobianDeterminantVector[i] = jacobianMatrices[i].Determinant();
        }

        public static void WriteDetailsInTheConsole()
        {
            Console.WriteLine($@"X -> {xFiniteElementPointsVector}");
            Console.WriteLine($@"Y -> {yFiniteEelementPointsVector}");
            Console.WriteLine($@"ksi -> {ksiVector}");
            Console.WriteLine($@"eta -> {etaVector}");
            Console.WriteLine($@"Funkcje ksztaltu -> {ShapeFunctionsNMatrix}");
            Console.WriteLine($@"dy/deta -> {dydetaVector}");
            Console.WriteLine($@"dy/dksi -> {dydksiVector}");
            Console.WriteLine($@"dx/deta -> {dxdetaVector}");
            Console.WriteLine($@"dx/dksi -> {dxdksiVector}");
            Console.WriteLine($@"dN/dksi -> {dNdksiMatrix}");
            Console.WriteLine($@"dN/deta -> {dNdksiMatrix}");
            for (int i = 0; i < FiniteElementPointsCount; i++)
                Console.WriteLine($@"Macierz Jacobiego [{i}] -> {jacobianMatrices[i]}");
            Console.WriteLine($@"Jakobian -> {JacobianDeterminantVector}");
            for (int i = 0; i < FiniteElementPointsCount; i++)
                Console.WriteLine($@"Odwrócona macierz Jacobiego [{i}] -> {inverseJacobianMatrices[i]}");
            Console.WriteLine($@"dN/dx -> {dNdxMatrix}");
            Console.WriteLine($@"dN/dy -> {dNdyMatrix}");
            for (int i = 0; i < FiniteElementPointsCount; i++)
            {
                Console.WriteLine($@"(dN/dx)*(dN/dx)^T [{i}] -> {dNdxdNdxTMatrices[i]}");
                Console.WriteLine($@"(dN/dy)*(dN/dy)^T [{i}] -> {dNdydNdyTMatrices[i]}");
            }
        }
    }
}