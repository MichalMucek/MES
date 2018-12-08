using System;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace MES_CP
{
    class Element
    {
        public InitialData InitialData { get; }
        public Node[] Nodes { get; set; }
        public int Id { get; set; }
        public Matrix<double> H { get; set; }
        public Matrix<double> H_BC { get; set; }
        public Matrix<double> C { get; set; }
        public Vector<double> P { get; set; }
        public bool[] BoundarySides { get; set; } = new bool[4];
        public double[] SidesLengths { get; set; } = new double[4];

        public Element(Node[] nodes, int id, InitialData initialData)
        {
            InitialData = initialData;
            Nodes = nodes;
            CheckBoundarySides();
            CalculateSidesLengths();
            Id = id;
            H = Calculations.HMatrix.Calculate(this, initialData.Conductivity);
            H_BC = Calculations.HMatricBC.Calculate(this);
            C = Calculations.CMatrix.Calculate(initialData.SpecificHeat, initialData.Density);
            P = Calculations.PVector.Calculate(this);
        }

        private void CheckBoundarySides()
        {
            for (int i = 0; i < 3; i++)
                if (Nodes[i].IsBoundary && Nodes[i + 1].IsBoundary)
                    BoundarySides[i] = true;
                else BoundarySides[i] = false;

            if (Nodes[3].IsBoundary && Nodes[0].IsBoundary)
                BoundarySides[3] = true;
            else BoundarySides[3] = false;
        }

        private void CalculateSidesLengths()
        {
            for (int i = 0; i < 3; i++)
                SidesLengths[i] = Math.Sqrt(Math.Pow(Nodes[i + 1].X - Nodes[i].X, 2) +
                                            Math.Pow(Nodes[i + 1].Y - Nodes[i].Y, 2));

            SidesLengths[3] = Math.Sqrt(Math.Pow(Nodes[0].X - Nodes[3].X, 2) +
                                        Math.Pow(Nodes[0].Y - Nodes[3].Y, 2));
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("[");

            foreach (var node in Nodes)
                stringBuilder.Append($"{node.Id}, ");

            stringBuilder.Length -= 2;
            stringBuilder.Append("]\n");

            foreach (var node in Nodes)
                stringBuilder.AppendLine(node.ToString());

            for (int i = 0; i < 4; i++)
                stringBuilder.AppendLine(
                    $">>ELEMENT SIDE<< [{i + 1}] => SideLength: {SidesLengths[i]} | IsBoundary: {BoundarySides[i]}");

            stringBuilder.Append($">>LOCAL MATRIX [H]<<\n{H.ToMatrixString(4, 4)}");
            stringBuilder.Append($">>LOCAL MATRIX [H_BC]<<\n{H_BC.ToMatrixString(4, 4)}");
            stringBuilder.Append($">>LOCAL MATRIX [C]<<\n{C.ToMatrixString(4, 4)}");
            stringBuilder.Append(">>LOCAL VECTOR {P}\n" + P.ToVectorString(4, 80));

            return $">>ELEMENT<< ID: {Id} => {stringBuilder}";
        }
    }
}
