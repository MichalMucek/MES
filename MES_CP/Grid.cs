using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using Newtonsoft.Json.Linq;

namespace MES_CP
{
    class Grid
    {
        public InitialData InitialData { get; private set; }
        private List<Node> Nodes { get; } = new List<Node>();
        private List<Element> Elements { get; } = new List<Element>();
        private int nodesCount;
        private int elementsCount;
        private Matrix<double> H { get; set; }
        private Matrix<double> H_BC { get; set; }
        private Matrix<double> C { get; set; }
        private Vector<double> P { get; set; }

        private List<KeyValuePair<double, Vector<double>>> TimeTemperature = new List<KeyValuePair<double, Vector<double>>>();

        public Grid(string initialDataFilePath) => GenerateFromInitialDataFile(initialDataFilePath);
        public Grid(InitialData initialData) => GenerateFromInitialDataObject(initialData);

        private void GenerateFromInitialDataFile(string initialDataFilePath)
        {
            JObject initialDataJObject = JObject.Parse(File.ReadAllText(initialDataFilePath));
            InitialData = initialDataJObject.ToObject<InitialData>();

            GenerateFromInitialDataObject(InitialData);
        }

        private void GenerateFromInitialDataObject(InitialData initialData)
        {
            InitialData = initialData;

            double x0 = 0.0, y0 = 0.0; //na sztywno; później pomyśleć, czy będzie potrzeba wczytywać z JSON-a
            double dx = initialData.Length / (initialData.NodesCountAlongTheLength - 1);
            double dy = initialData.Height / (initialData.NodesCountAlongTheHeight - 1);
            int nL = initialData.NodesCountAlongTheLength;
            int nH = initialData.NodesCountAlongTheHeight;
            double t0 = initialData.InitialTemperature;
            elementsCount = (initialData.NodesCountAlongTheHeight - 1) * (initialData.NodesCountAlongTheLength - 1);
            nodesCount = initialData.NodesCountAlongTheHeight * initialData.NodesCountAlongTheLength;

            AddNodes(x0, y0, dx, dy, nL, nH, t0);
            AddElements(nH);
            GenerateGlobalMatricesAndVectors();
        }

        private void AddNodes(double x0, double y0, double dx, double dy, int nL, int nH, double t0)
        {
            for (int i = 0, nodeId = 1; i < nL; i++)
            {
                for (int j = 0; j < nH; j++, nodeId++)
                {
                    bool isBounadryNode;

                    if (i == 0 || j == 0 || i == nL - 1 || j == nH - 1) isBounadryNode = true;
                    else isBounadryNode = false;

                    Node node = new Node
                    {
                        X = x0 + dx * i,
                        Y = y0 + dy * j,
                        InitialTemperature = t0,
                        Id = nodeId,
                        IsBoundary = isBounadryNode
                    };

                    Nodes.Add(node);
                }
            }
        }

        private void AddElements(int nH)
        {
            for (int id = 1, i = 0; id <= elementsCount; i++)
            {
                if (Nodes[i].Id % nH != 0)
                {
                    Node[] elementNodes = {
                        Nodes[i],
                        Nodes[i + nH],
                        Nodes[i + nH + 1],
                        Nodes[i + 1]
                    };

                    Element element = new Element(elementNodes, id, InitialData);

                    Elements.Add(element);

                    var idLocal = id;
                    Program.MainForm.BeginInvoke((MethodInvoker) delegate
                    {
                        Program.MainForm.SimulationProgressBarValue = (idLocal * 100) / elementsCount;
                    });

                    id++;
                }
            }
        }

        private void GenerateGlobalMatricesAndVectors()
        {
            H = Matrix<double>.Build.Dense(nodesCount, nodesCount);
            H_BC = Matrix<double>.Build.Dense(nodesCount, nodesCount);
            C = Matrix<double>.Build.Dense(nodesCount, nodesCount);
            P = Vector<double>.Build.Dense(nodesCount);


            foreach (var element in Elements)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = i; j < 4; j++)
                    {
                        H[element.Nodes[i].Id - 1, element.Nodes[j].Id - 1] += element.H[i, j];
                        H_BC[element.Nodes[i].Id - 1, element.Nodes[j].Id - 1] += element.H_BC[i, j];
                        C[element.Nodes[i].Id - 1, element.Nodes[j].Id - 1] += element.C[i, j];
                        
                        if (i != j)
                        {
                            H[element.Nodes[j].Id - 1, element.Nodes[i].Id - 1] += element.H[j, i];
                            H_BC[element.Nodes[j].Id - 1, element.Nodes[i].Id - 1] += element.H_BC[j, i];
                            C[element.Nodes[j].Id - 1, element.Nodes[i].Id - 1] += element.C[j, i];
                        }
                    }

                    P[element.Nodes[i].Id - 1] += element.P[i];
                }
            }
        }

        public void RunSimulation()
        {
            var hHatMatrix = Matrix<double>.Build.Dense(nodesCount, nodesCount);
            var pHatVector = Vector<double>.Build.Dense(elementsCount);
            var t0Vector = Vector<double>.Build.Dense(nodesCount, InitialData.InitialTemperature);
            var tVector = Vector<double>.Build.Dense(nodesCount);
            var timeStep = InitialData.SimulationTimeStep;

            hHatMatrix = (H + H_BC) + (C / timeStep);

            //GUI update
            Program.MainForm.BeginInvoke((MethodInvoker) delegate
            {
                Program.MainForm.UpdateGridAndSimulationStatusLabel("Simulation is about to start...");
            });

            var hHatMatrixInverse = hHatMatrix.Inverse(); //time consuming

            for (double passedTime = timeStep; passedTime <= InitialData.SimulationTime; passedTime += timeStep)
            {
                pHatVector = (C / timeStep) * t0Vector + P;
                tVector = hHatMatrixInverse * pHatVector;

                var time = passedTime;
                var minTemp = tVector.Min();
                var maxTemp = tVector.Max();

                //GUI update
                Program.MainForm.BeginInvoke((MethodInvoker) delegate
                {
                    Program.MainForm.SimulationProgressBarValue = (int)((time / InitialData.SimulationTime) * 100);
                    Program.MainForm.UpdateTimeTemperatureOnRichTextBox(time, minTemp, maxTemp);
                });

                TimeTemperature.Add(new KeyValuePair<double, Vector<double>>(passedTime, tVector));

                t0Vector = tVector;
            }
        }

        public string TimeTemperatureToString()
        {
            StringBuilder stringBuilder = new StringBuilder($">>INITAIL DATA<<\n{InitialData.ToString()}\n");

            stringBuilder.Append("Time[s]\tMinTemp[°C]\t\t\tMaxTemp[°C]\n");

            foreach (var keyValuePair in TimeTemperature)
            {
                stringBuilder.Append($"{keyValuePair.Key}");
                stringBuilder.Append($"\t\t{keyValuePair.Value.Min()}");
                stringBuilder.Append($"\t\t{keyValuePair.Value.Max()}\n");
            }

            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder($">>INITAIL DATA<<\n{InitialData.ToString()}\n");

            foreach (var element in Elements)
                stringBuilder.Append($"{element}\n");

            stringBuilder.Append($">>GLOBAL MATRIX [H]<<\n{H.ToMatrixString(nodesCount, nodesCount)}\n");
            stringBuilder.Append($">>GLOBAL MATRIX [H_BC]<<\n{H_BC.ToMatrixString(nodesCount, nodesCount)}\n");
            stringBuilder.Append($">>GLOBAL MATRIX [C]<<\n{C.ToMatrixString(nodesCount, nodesCount)}\n");
            stringBuilder.Append(">>GLOBAL VECTOR {P}<<\n" + P.ToRowMatrix().ToMatrixString(1, nodesCount));

            return stringBuilder.ToString();
        }
    }
}