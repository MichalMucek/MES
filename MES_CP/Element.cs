using System.Text;

namespace MES_CP
{
    class Element
    {
        public Node[] Nodes { get; set; } = new Node[4];
        public int id { get; set; }

        public override string ToString()
        {
            StringBuilder ids = new StringBuilder("[");

            foreach (var node in Nodes)
                ids.Append($@"{node.id}, ");

            ids.Length -= 2;
            ids.Append("]");

            return $@">>ELEMENT<< ID: {id} => {ids.ToString()}";
        }
    }
}
