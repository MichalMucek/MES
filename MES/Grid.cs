using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace MES
{
    class Grid
    {
        private List<Node> Nodes { get; set; } = new List<Node>();
        private List<Element> Elements { get; set; } = new List<Element>();

        public void Generate(DataSet dataSet)
        {
            double x0 = 0.0, y0 = 0.0;
            double dx = dataSet.L / (dataSet.nL - 1);
            double dy = dataSet.H / (dataSet.nH - 1);
            int nN = dataSet.nH * dataSet.nL;
            int nE = (dataSet.nH - 1) * (dataSet.nL - 1);

            //Adding nodes
            for (int i = 0, nodeId = 1; i < dataSet.nL; i++)
            {
                for (int j = 0; j < dataSet.nH; j++, nodeId++)
                {
                    Node node = new Node()
                    {
                        x = x0 + dx * i,
                        y = y0 + dy * j,
                        t0 = dataSet.t0,
                        id = nodeId
                    };

                    Nodes.Add(node); 
                }
            }

            //Generating elements
            for (int i = 1, j = 0; i <= nE; j++)
            {
                if (Nodes[j].id % dataSet.nH != 0)
                {
                    Element element = new Element
                    {
                        Nodes =
                        {
                            [0] = Nodes[j],
                            [1] = Nodes[j + dataSet.nH],
                            [2] = Nodes[j + dataSet.nH + 1],
                            [3] = Nodes[j + 1]
                        },
                        id = i
                    };

                    Elements.Add(element);
                    i++;
                }
            }
        }

        public void Generate(string dataSetFilePath)
        {
            JObject dataSetJObject = JObject.Parse(File.ReadAllText(dataSetFilePath));
            DataSet dataSet = dataSetJObject.ToObject<DataSet>();

            Generate(dataSet);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("");

            foreach (var element in Elements)
            {
                stringBuilder.Append($"{element}\n");

                foreach (var node in element.Nodes)
                    stringBuilder.Append($"\t{node}\n");

                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }
    }
}
