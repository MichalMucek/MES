using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace MES_CP
{
    class Element
    {
        public Node[] Nodes { get; set; }
        public int Id { get; set; }
        public Matrix<double> H { get; set; }
        public Matrix<double> C { get; set; }

        public Element(Node[] nodes, int id)
        {
            Nodes = nodes;
            Id = id;
            H = Calculations.HMatrix.Calculate(this);
            C = Calculations.CMatrix.Calculate();
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

            stringBuilder.Append($">>LOCAL MATRIX [H]<<\n{H.ToMatrixString(4, 4)}");
            stringBuilder.Append($">>LOCAL MATRIX [C]<<\n{C.ToMatrixString(4, 4)}");

            return $">>ELEMENT<< ID: {Id} => {stringBuilder}";
        }
    }
}
