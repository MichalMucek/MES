using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using Newtonsoft.Json.Linq;

namespace MES_CP
{
    class Grid
    {
        public InitialData InitialData { get; private set; }
        public List<Node> Nodes { get; } = new List<Node>();
        public List<Element> Elements { get; } = new List<Element>();
        public int NodesCount { get; private set; }
        public int ElementsCount { get; private set; }
        public Matrix<double> H { get; private set; }
        public Matrix<double> HBoundaryConditions { get; private set; }
        public Matrix<double> C { get; private set; }
        public Vector<double> P { get; private set; }

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
            ElementsCount = (initialData.NodesCountAlongTheHeight - 1) * (initialData.NodesCountAlongTheLength - 1);
            NodesCount = initialData.NodesCountAlongTheHeight * initialData.NodesCountAlongTheLength;

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
            for (int elementId = 1, i = 0; elementId <= ElementsCount; i++)
            {
                if (Nodes[i].Id % nH != 0)
                {
                    Node[] elementNodes = {
                        Nodes[i],
                        Nodes[i + nH],
                        Nodes[i + nH + 1],
                        Nodes[i + 1]
                    };

                    Elements.Add(new Element(elementNodes, elementId, InitialData));

                    // GUI update
                    Program.MainForm.Invoke((MethodInvoker) delegate
                    {
                        Program.MainForm.SimulationProgressBarValue = (elementId * 100) / ElementsCount;
                    });

                    elementId++;
                }
            }
        }

        private void GenerateGlobalMatricesAndVectors()
        {
            H = Matrix<double>.Build.Dense(NodesCount, NodesCount);
            HBoundaryConditions = Matrix<double>.Build.Dense(NodesCount, NodesCount);
            C = Matrix<double>.Build.Dense(NodesCount, NodesCount);
            P = Vector<double>.Build.Dense(NodesCount);


            foreach (var element in Elements)
            {
                for (int i = 0; i < Element.NodesCount; i++)
                {
                    for (int j = i; j < Element.NodesCount; j++)
                    {
                        H[element.Nodes[i].Id - 1, element.Nodes[j].Id - 1] += element.H[i, j];
                        HBoundaryConditions[element.Nodes[i].Id - 1, element.Nodes[j].Id - 1] += element.HBoundaryConditions[i, j];
                        C[element.Nodes[i].Id - 1, element.Nodes[j].Id - 1] += element.C[i, j];
                        
                        if (i != j)
                        {
                            H[element.Nodes[j].Id - 1, element.Nodes[i].Id - 1] += element.H[j, i];
                            HBoundaryConditions[element.Nodes[j].Id - 1, element.Nodes[i].Id - 1] += element.HBoundaryConditions[j, i];
                            C[element.Nodes[j].Id - 1, element.Nodes[i].Id - 1] += element.C[j, i];
                        }
                    }

                    P[element.Nodes[i].Id - 1] += element.P[i];
                }
            }
        }

        public void RunSimulation()
        {
            var hHatMatrix = Matrix<double>.Build.Dense(NodesCount, NodesCount);
            var pHatVector = Vector<double>.Build.Dense(ElementsCount);
            var t0Vector = Vector<double>.Build.Dense(NodesCount, InitialData.InitialTemperature);
            var tVector = Vector<double>.Build.Dense(NodesCount);
            var timeStep = InitialData.SimulationTimeStep;

            hHatMatrix = (H + HBoundaryConditions) + (C / timeStep);

            // GUI update
            Program.MainForm.BeginInvoke((MethodInvoker) delegate
            {
                Program.MainForm.UpdateGridAndSimulationStatusLabel("Simulation is about to start...");
            });

            var hHatMatrixInverse = hHatMatrix.Inverse(); // Time consuming

            // GUI update
            Program.MainForm.BeginInvoke((MethodInvoker)delegate
            {
                Program.MainForm.UpdateGridAndSimulationStatusLabel("Simulation is running...");
            });

            for (double passedTime = timeStep; passedTime <= InitialData.SimulationTime; passedTime += timeStep)
            {
                pHatVector = (C / timeStep) * t0Vector + P;
                tVector = hHatMatrixInverse * pHatVector;

                var time = passedTime;
                var minTemp = tVector.Min();
                var maxTemp = tVector.Max();

                // GUI update
                Program.MainForm.Invoke((MethodInvoker) delegate
                {
                    Program.MainForm.SimulationProgressBarValue = (int)((time / InitialData.SimulationTime) * 100);
                    Program.MainForm.UpdateTimeTemperatureOnRichTextBox(time, minTemp, maxTemp);
                });

                TimeTemperature.Add(new KeyValuePair<double, Vector<double>>(passedTime, tVector));

                t0Vector = tVector;
            }
        }

        public bool RunSimulationWithCancellationToken(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                var hHatMatrix = Matrix<double>.Build.Dense(NodesCount, NodesCount);
                var pHatVector = Vector<double>.Build.Dense(ElementsCount);
                var t0Vector = Vector<double>.Build.Dense(NodesCount, InitialData.InitialTemperature);
                var tVector = Vector<double>.Build.Dense(NodesCount);
                var timeStep = InitialData.SimulationTimeStep;

                if (!token.IsCancellationRequested)
                {
                    hHatMatrix = (H + HBoundaryConditions) + (C / timeStep);

                    // GUI update
                    Program.MainForm.BeginInvoke((MethodInvoker) delegate
                    {
                        Program.MainForm.UpdateGridAndSimulationStatusLabel("Simulation is about to start...");
                    });
                }
                else return false;

                var hHatMatrixInverse = hHatMatrix.Inverse(); // Time consuming

                if (!token.IsCancellationRequested)
                {
                    // GUI update
                    Program.MainForm.BeginInvoke((MethodInvoker) delegate
                    {
                        Program.MainForm.UpdateGridAndSimulationStatusLabel("Simulation is running...");
                    });

                    double passedTime;

                    for (passedTime = timeStep;
                        passedTime <= InitialData.SimulationTime && !token.IsCancellationRequested;
                        passedTime += timeStep)
                    {
                        pHatVector = (C / timeStep) * t0Vector + P;
                        tVector = hHatMatrixInverse * pHatVector;

                        var time = passedTime;
                        var minTemp = tVector.Min();
                        var maxTemp = tVector.Max();

                        // GUI update
                        Program.MainForm.Invoke((MethodInvoker) delegate
                        {
                            Program.MainForm.SimulationProgressBarValue =
                                (int) ((time / InitialData.SimulationTime) * 100);
                            Program.MainForm.UpdateTimeTemperatureOnRichTextBox(time, minTemp, maxTemp);
                        });

                        TimeTemperature.Add(new KeyValuePair<double, Vector<double>>(passedTime, tVector));

                        t0Vector = tVector;
                    }

                    if (Math.Abs(passedTime - InitialData.SimulationTime) > InitialData.SimulationTimeStep) return false;
                }
                else return false;
            }
            else return false;

            return true;
        }

        public string TimeTemperatureToString()
        {
            StringBuilder stringBuilder = new StringBuilder($">>INITIAL DATA<<\n{InitialData.ToString()}\n");

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
            StringBuilder stringBuilder = new StringBuilder($">>INITIAL DATA<<\n{InitialData.ToString()}\n");

            foreach (var element in Elements)
                stringBuilder.Append($"{element}\n");

            stringBuilder.Append($">>GLOBAL MATRIX [H]<<\n{H.ToMatrixString(NodesCount, NodesCount)}\n");
            stringBuilder.Append($">>GLOBAL MATRIX [H_BC]<<\n{HBoundaryConditions.ToMatrixString(NodesCount, NodesCount)}\n");
            stringBuilder.Append($">>GLOBAL MATRIX [C]<<\n{C.ToMatrixString(NodesCount, NodesCount)}\n");
            stringBuilder.Append(">>GLOBAL VECTOR {P}<<\n" + P.ToRowMatrix().ToMatrixString(1, NodesCount));

            return stringBuilder.ToString();
        }
    }
}