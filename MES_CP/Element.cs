using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace MES_CP
{
    class Element
    {
        public Node[] Nodes { get; set; }
        public int Id { get; set; }
        public Matrix<double> H { get; set; }

        public Element(Node[] nodes, int id)
        {
            Nodes = nodes;
            Id = id;
            H = Calculations.H.Calculate(this);
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

            return $">>ELEMENT<< ID: {Id} => {stringBuilder}";
        }
    }
}
