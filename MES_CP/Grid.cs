using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using Newtonsoft.Json.Linq;

namespace MES_CP
{
    class Grid
    {
        private List<Node> Nodes { get; } = new List<Node>();
        private List<Element> Elements { get; } = new List<Element>();
        private Matrix<double> H { get; set; }

        public Grid(string initailDataFilePath) => GenerateFromInitialDataFile(initailDataFilePath);
        public Grid(InitialData initialData) => GenerateFromInitialDataObject(initialData);

        private void GenerateFromInitialDataFile(string initailDataFilePath)
        {
            JObject initialDataJObject = JObject.Parse(File.ReadAllText(initailDataFilePath));
            InitialData initialData = initialDataJObject.ToObject<InitialData>();

            GenerateFromInitialDataObject(initialData);
        }

        private void GenerateFromInitialDataObject(InitialData initialData)
        {
            double x0 = 0.0, y0 = 0.0; //na sztywno; później pomyśleć, czy będzie potrzeba wczytywać z JSON-a
            double dx = initialData.Length / (initialData.NodesCountAlongTheLength - 1);
            double dy = initialData.Height / (initialData.NodesCountAlongTheHeight - 1);
            int nL = initialData.NodesCountAlongTheLength;
            int nH = initialData.NodesCountAlongTheHeight;
            double t0 = initialData.T0;
            int elementsCount = (initialData.NodesCountAlongTheHeight - 1) * (initialData.NodesCountAlongTheLength - 1);
            int nodesCount = initialData.NodesCountAlongTheHeight * initialData.NodesCountAlongTheLength;

            AddNodes(x0, y0, dx, dy, nL, nH, t0);
            AddElements(elementsCount, nH);
            GenerateH(nodesCount);
        }

        private void AddNodes(double x0, double y0, double dx, double dy, int nL, int nH, double t0)
        {
            for (int i = 0, nodeId = 1; i < nL; i++)
            {
                for (int j = 0; j < nH; j++, nodeId++)
                {
                    bool isBoundryNode;

                    if (i == 0 || j == 0 || i == nL - 1 || j == nH - 1)
                        isBoundryNode = true;
                    else
                        isBoundryNode = false;

                    Node node = new Node
                    {
                        X = x0 + dx * i,
                        Y = y0 + dy * j,
                        T0 = t0,
                        Id = nodeId,
                        IsBoundry = isBoundryNode
                    };

                    Nodes.Add(node);
                }
            }
        }

        private void AddElements(int elementsCount, int nH)
        {
            for (int id = 1, j = 0; id <= elementsCount; j++)
            {
                if (Nodes[j].Id % nH != 0)
                {
                    Node[] elementNodes = {
                        Nodes[j],
                        Nodes[j + nH],
                        Nodes[j + nH + 1],
                        Nodes[j + 1]
                    };

                    Element element = new Element(elementNodes, id);

                    Elements.Add(element);
                    id++;
                }
            }
        }

        private void GenerateH(int nodesCount)
        {
            H = Matrix<double>.Build.Dense(nodesCount, nodesCount);

            foreach (var element in Elements)
            {
                Matrix<double> elementH = element.H; 

                for (int i = 0; i < 4; i++)
                {
                    for (int j = i; j < 4; j++)
                    {
                        H[element.Nodes[i].Id - 1, element.Nodes[j].Id - 1] = elementH[i, j];
                        H[element.Nodes[j].Id - 1, element.Nodes[i].Id - 1] = elementH[j, i];
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("");

            foreach (var element in Elements)
                stringBuilder.Append($"{element}\n");

            stringBuilder.Append($">>GLOBAL MATRIX [H]<<\n{H.ToMatrixString(Nodes.Last().Id, Nodes.Last().Id)}");

            return stringBuilder.ToString();
        }
    }
}
