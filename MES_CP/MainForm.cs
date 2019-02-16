using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MES_CP
{
    public partial class MainForm : Form
    {
        private Grid grid;
        private InitialData initialData;
        private bool isSimulationRunning;
        private CancellationTokenSource cancellationTokenSource;

        public int SimulationProgressBarValue
        {
            set
            {
                toolStripProgressBar.Value = value;
                toolStripProgressLabel.Text = value + "%";
            }
        }

        public void UpdateTimeTemperatureOnRichTextBox(double time, double minTemp, double maxTemp)
        {
            richTextBox.Text = $">>INITIAL DATA<<\n{initialData.ToString()}\n\n" +
                               $"Time: {time} s\n" +
                               $"Min. temperature: {minTemp}°C\n" +
                               $"Max. temperature: {maxTemp}°C";
        }

        public void UpdateGridAndSimulationStatusLabel(string status)
        {
            toolStripGridAndSimulationStatusLabel.Text = status;
        }

        private void SetInitialData()
        {
            initialData = new InitialData
            {
                Length = Double.Parse(gridLengthTextBox.Text),
                Height = Double.Parse(gridHeightTextBox.Text),
                NodesCountAlongTheLength = int.Parse(nodesCountAlongTheLengthTextBox.Text),
                NodesCountAlongTheHeight = int.Parse(nodesCountAlongTheHeightTextBox.Text),
                InitialTemperature = Double.Parse(initialTemperatureTextBox.Text),
                AmbientTemperature = Double.Parse(ambientTemperatureTextBox.Text),
                SimulationTime = Double.Parse(simulationTimeTextBox.Text),
                SimulationTimeStep = Double.Parse(simulationTimeStepTextBox.Text),
                ConvectionCoefficient = Double.Parse(alphaTextBox.Text),
                SpecificHeat = Double.Parse(specificHeatTextBox.Text),
                Conductivity = Double.Parse(conductivityTextBox.Text),
                Density = Double.Parse(densityTextBox.Text)
            };
        }

        private bool IsEveryInitialDataTextBoxFilled()
        {
            foreach (Control control in initialDataGroupBox.Controls)
                if (control.Text.Equals(""))
                {
                    toolStripInitialDataStatusLabel.Text = "Enter initial data!";
                    return false;
                }

            toolStripInitialDataStatusLabel.Text = "Initial data is complete.";
            return true;
        }

        public MainForm()
        {
            InitializeComponent();
            openJsonFileDialog.InitialDirectory = Application.StartupPath;
            saveTextFileDialog.InitialDirectory = Application.StartupPath;
        }

        private bool IsPositiveNumberTyped(object sender, KeyPressEventArgs e)
        {
            return (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',')) ||
                   (e.KeyChar == ',') && (((TextBox) sender).Text.IndexOf(',') > -1);
        }

        private bool IsNumberTyped(object sender, KeyPressEventArgs e)
        {
            return (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') &&
                    (e.KeyChar != '-')) ||
                   (e.KeyChar == ',') && (((TextBox) sender).Text.IndexOf(',') > -1) ||
                   (e.KeyChar == '-') && (((TextBox) sender).Text.IndexOf('-') > -1);
        }

        private void LoadInitialDataFileButton_Click(object sender, EventArgs e)
        {
            if (openJsonFileDialog.ShowDialog() == DialogResult.OK)
            {
                JObject initialDataJObject = JObject.Parse(File.ReadAllText(openJsonFileDialog.FileName));
                InitialData initialData = initialDataJObject.ToObject<InitialData>();

                gridLengthTextBox.Text = initialData.Length.ToString();
                gridHeightTextBox.Text = initialData.Height.ToString();
                nodesCountAlongTheLengthTextBox.Text = initialData.NodesCountAlongTheLength.ToString();
                nodesCountAlongTheHeightTextBox.Text = initialData.NodesCountAlongTheHeight.ToString();
                initialTemperatureTextBox.Text = initialData.InitialTemperature.ToString();
                ambientTemperatureTextBox.Text = initialData.AmbientTemperature.ToString();
                simulationTimeTextBox.Text = initialData.SimulationTime.ToString();
                simulationTimeStepTextBox.Text = initialData.SimulationTimeStep.ToString();
                alphaTextBox.Text = initialData.ConvectionCoefficient.ToString();
                specificHeatTextBox.Text = initialData.SpecificHeat.ToString();
                conductivityTextBox.Text = initialData.Conductivity.ToString();
                densityTextBox.Text = initialData.Density.ToString();

                toolStripInitialDataStatusLabel.Text = "Initial data from JSON file has been loaded.";

                if (IsEveryInitialDataTextBoxFilled())
                    EnableGenerateGridAndSaveToJsonButtons();

                openJsonFileDialog.FileName = "";
            }
        }

        private void GenerateNewGridFromInitialDataButton_Click(object sender, EventArgs e)
        {
            SetInitialData();

            Invoke((MethodInvoker) delegate
            {
                toolStripGridAndSimulationStatusLabel.Text = "Creating new grid...";
                grid = new Grid(initialData);
            });

            saveGridDetailsToTextFileButton.Enabled = true;

            elementIdNumericUpDown.Enabled = true;
            elementIdNumericUpDown.Minimum = 1;
            elementIdNumericUpDown.Maximum = grid.ElementsCount;

            elementNode0IdLinkLabel.Enabled = true;
            elementNode1IdLinkLabel.Enabled = true;
            elementNode2IdLinkLabel.Enabled = true;
            elementNode3IdLinkLabel.Enabled = true;

            elementMatricesAndVectorComboBox.Enabled = true;
            elementMatricesAndVectorDataGridView.Rows.Add(4);
            elementMatricesAndVectorComboBox.SelectedIndex = 0;

            nodeIdNumericUpDown.Enabled = true;
            nodeIdNumericUpDown.Minimum = 1;
            nodeIdNumericUpDown.Maximum = grid.NodesCount;
            nodeIdNumericUpDown.Value = grid.Elements[0].Nodes[0].Id;

            // For GUI update purpose
            elementIdNumericUpDown.Value = elementIdNumericUpDown.Maximum;
            elementIdNumericUpDown.Value = 1;
        }

        private void StartSimulationButton_Click(object sender, EventArgs e)
        {
            startSimulationButton.Enabled = false;
            stopSimulationButton.Enabled = true;
            saveResultToTextFileButton.Enabled = false;
            saveGridDetailsToTextFileButton.Enabled = false;
            toolStripProgressLabel.Text = "0%";
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = true;
            toolStripGridAndSimulationStatusLabel.Visible = true;
            toolStripProgressLabel.Visible = true;

            SetInitialData();

            richTextBox.Text = $">>INITIAL DATA<<\n{initialData.ToString()}\n";

            cancellationTokenSource = new CancellationTokenSource();

            ThreadPool.QueueUserWorkItem(Async_LongRunningTask_StartSimulation, cancellationTokenSource.Token);
        }

        private void Async_LongRunningTask_StartSimulation(object state)
        {
            Invoke((MethodInvoker) delegate
            {
                toolStripGridAndSimulationStatusLabel.Text = "Creating new grid...";
                grid = new Grid(initialData);
            });

            Invoke((MethodInvoker) delegate
            {
                saveGridDetailsToTextFileButton.Enabled = true;
                SimulationProgressBarValue = 0;
                richTextBox.Select();
                isSimulationRunning = true;
            });

            //grid.RunSimulation();
            grid.RunSimulationWithCancellationToken((CancellationToken) state);

            Invoke((MethodInvoker) delegate
            {
                isSimulationRunning = false;
                toolStripGridAndSimulationStatusLabel.Text = "Simulation is completed :)";
                richTextBox.Text = grid.TimeTemperatureToString();
                saveResultToTextFileButton.Enabled = true;
                toolStripProgressBar.Visible = false;
                toolStripProgressLabel.Visible = false;

                if (IsEveryInitialDataTextBoxFilled()) EnableGenerateGridAndSaveToJsonButtons();
                else DisableGenerateGridnAndSaveToJsonButtons();
            });
        }

        private void StopSimulationButton_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();

            toolStripGridAndSimulationStatusLabel.Text = "Simulation is about to stop...";
        }

        private void SaveResultToTextFileButton_Click(object sender, EventArgs e)
        {
            saveTextFileDialog.FileName = $"simulation-result-{DateTime.Now.ToString("yyyyMMddHHmmss")}";

            if (saveTextFileDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripInitialDataStatusLabel.Text = "Saving simulation result to text file...";
                File.WriteAllText(saveTextFileDialog.FileName, richTextBox.Text);
                toolStripInitialDataStatusLabel.Text = "Simulation result has been saved to text file.";
            }
        }

        private void SaveGridDetailsToTextFileButton_Click(object sender, EventArgs e)
        {
            saveTextFileDialog.FileName = $"grid-details-{DateTime.Now.ToString("yyyyMMddHHmmss")}";

            if (saveTextFileDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripInitialDataStatusLabel.Text = "Saving grid details to text file...";
                File.WriteAllText(saveTextFileDialog.FileName, grid.ToString());
                toolStripInitialDataStatusLabel.Text = "Grid details have been saved to text file.";
            }
        }

        private void SaveInitialDataToJsonFileButton_Click(object sender, EventArgs e)
        {
            saveJsonFileDialog.FileName = $"initial-data-{DateTime.Now.ToString("yyyyMMddHHmmss")}";

            if (saveJsonFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetInitialData();
                toolStripInitialDataStatusLabel.Text = "Saving initial data to JSON file...";
                File.WriteAllText(saveJsonFileDialog.FileName, JsonConvert.SerializeObject(initialData));
                toolStripInitialDataStatusLabel.Text = "Initial data has been saved to JSON file.";
            }
        }

        private void EnableGenerateGridAndSaveToJsonButtons()
        {
            saveInitialDataToJsonFileButton.Enabled = true;
            generateNewGridFromInitialDataButton.Enabled = true;

            if (!isSimulationRunning) startSimulationButton.Enabled = true;
        }

        private void DisableGenerateGridnAndSaveToJsonButtons()
        {
            saveInitialDataToJsonFileButton.Enabled = false;
            generateNewGridFromInitialDataButton.Enabled = false;
        }

        private void GridLengthTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableGenerateGridAndSaveToJsonButtons();
            else DisableGenerateGridnAndSaveToJsonButtons();
        }

        private void GridHeightTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableGenerateGridAndSaveToJsonButtons();
            else DisableGenerateGridnAndSaveToJsonButtons();
        }

        private void NodesCountAlongTheLengthTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableGenerateGridAndSaveToJsonButtons();
            else DisableGenerateGridnAndSaveToJsonButtons();
        }

        private void NodesCountAlongTheHeightTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableGenerateGridAndSaveToJsonButtons();
            else DisableGenerateGridnAndSaveToJsonButtons();
        }

        private void InitialTemperatureTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableGenerateGridAndSaveToJsonButtons();
            else DisableGenerateGridnAndSaveToJsonButtons();
        }

        private void AmbientTemperatureTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableGenerateGridAndSaveToJsonButtons();
            else DisableGenerateGridnAndSaveToJsonButtons();
        }

        private void SimulationTimeTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableGenerateGridAndSaveToJsonButtons();
            else DisableGenerateGridnAndSaveToJsonButtons();
        }

        private void SimulationTimeStepTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableGenerateGridAndSaveToJsonButtons();
            else DisableGenerateGridnAndSaveToJsonButtons();
        }

        private void AlphaTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableGenerateGridAndSaveToJsonButtons();
            else DisableGenerateGridnAndSaveToJsonButtons();
        }

        private void SpecificHeatTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableGenerateGridAndSaveToJsonButtons();
            else DisableGenerateGridnAndSaveToJsonButtons();
        }

        private void ConductivityTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableGenerateGridAndSaveToJsonButtons();
            else DisableGenerateGridnAndSaveToJsonButtons();
        }

        private void DensityTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableGenerateGridAndSaveToJsonButtons();
            else DisableGenerateGridnAndSaveToJsonButtons();
        }

        private void GridLengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsPositiveNumberTyped(sender, e);
        }

        private void GridHeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsPositiveNumberTyped(sender, e);
        }

        private void NodesCountAlongTheLengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsPositiveNumberTyped(sender, e);
        }

        private void NodesCountAlongTheHeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsPositiveNumberTyped(sender, e);
        }

        private void InitialTemperatureTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumberTyped(sender, e);
        }

        private void AmbientTemperatureTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumberTyped(sender, e);
        }

        private void SimulationTimeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsPositiveNumberTyped(sender, e);
        }

        private void SimulationTimeStepTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsPositiveNumberTyped(sender, e);
        }

        private void AlphaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsNumberTyped(sender, e);
        }

        private void SpecificHeatTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsPositiveNumberTyped(sender, e);
        }

        private void ConductivityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsPositiveNumberTyped(sender, e);
        }

        private void DensityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = IsPositiveNumberTyped(sender, e);
        }

        private void ElementIdNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Element selectedElement = grid.Elements[(int)elementIdNumericUpDown.Value - 1];

            nodeIdNumericUpDown.Value = selectedElement.Nodes[0].Id;

            // Nodes IDs
            elementNode0IdLinkLabel.Text = $"{selectedElement.Nodes[0].Id}";
            elementNode1IdLinkLabel.Text = $"{selectedElement.Nodes[1].Id}";
            elementNode2IdLinkLabel.Text = $"{selectedElement.Nodes[2].Id}";
            elementNode3IdLinkLabel.Text = $"{selectedElement.Nodes[3].Id}";

            // Side length -> Bottom
            if (selectedElement.BoundarySides[0])
                bottomSideLengthLabel.Text =
                    $"Bottom [Boundary]: {selectedElement.SidesLengths[0]} m";
            else
                bottomSideLengthLabel.Text =
                    $"Bottom: {selectedElement.SidesLengths[0]} m";

            // Side length -> Right
            if (selectedElement.BoundarySides[1])
                rightSideLengthLabel.Text =
                    $"Right [Boundary]: {selectedElement.SidesLengths[1]} m";
            else
                rightSideLengthLabel.Text =
                    $"Right: {selectedElement.SidesLengths[1]} m";

            // Side length -> Top
            if (selectedElement.BoundarySides[2])
                topSideLengthLabel.Text =
                    $"Top [Boundary]: {selectedElement.SidesLengths[2]} m";
            else
                topSideLengthLabel.Text =
                    $"Top: {selectedElement.SidesLengths[2]} m";

            // Side length -> Left
            if (selectedElement.BoundarySides[3])
                leftSideLengthLabel.Text =
                    $"Left [Boundary]: {selectedElement.SidesLengths[3]} m";
            else
                leftSideLengthLabel.Text =
                    $"Left: {selectedElement.SidesLengths[3]} m";

            ElementMatricesAndVectorComboBox_SelectedIndexChanged(sender, e);
        }

        private void ElementNode0IdLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Element selectedElement = grid.Elements[(int)elementIdNumericUpDown.Value - 1];

            nodeIdNumericUpDown.Value = selectedElement.Nodes[0].Id;
        }

        private void ElementNode1IdLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Element selectedElement = grid.Elements[(int)elementIdNumericUpDown.Value - 1];

            nodeIdNumericUpDown.Value = selectedElement.Nodes[1].Id;
        }

        private void ElementNode2IdLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Element selectedElement = grid.Elements[(int)elementIdNumericUpDown.Value - 1];

            nodeIdNumericUpDown.Value = selectedElement.Nodes[2].Id;
        }

        private void ElementNode3IdLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Element selectedElement = grid.Elements[(int)elementIdNumericUpDown.Value - 1];

            nodeIdNumericUpDown.Value = selectedElement.Nodes[3].Id;
        }

        private void ElementMatricesAndVectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Element selectedElement = grid.Elements[(int)elementIdNumericUpDown.Value - 1];

            switch (elementMatricesAndVectorComboBox.SelectedIndex)
            {
                case 0: // [H] Matrix
                    elementMatricesAndVectorDataGridView.RowCount = 4;
                    for (int rowIndex = 0; rowIndex < selectedElement.H.RowCount; rowIndex++)
                        for (int columnIndex = 0; columnIndex < selectedElement.H.ColumnCount; columnIndex++)
                            elementMatricesAndVectorDataGridView.Rows[rowIndex].Cells[columnIndex].Value = selectedElement.H.Row(rowIndex)[columnIndex];
                    break;
                case 1: // [H_BC] Matrix
                    elementMatricesAndVectorDataGridView.RowCount = 4;
                    for (int rowIndex = 0; rowIndex < selectedElement.HBoundaryConditions.RowCount; rowIndex++)
                        for (int columnIndex = 0; columnIndex < selectedElement.HBoundaryConditions.ColumnCount; columnIndex++)
                            elementMatricesAndVectorDataGridView.Rows[rowIndex].Cells[columnIndex].Value = selectedElement.HBoundaryConditions.Row(rowIndex)[columnIndex];
                    break;
                case 2: // [C] Matrix
                    elementMatricesAndVectorDataGridView.RowCount = 4;
                    for (int rowIndex = 0; rowIndex < selectedElement.C.RowCount; rowIndex++)
                        for (int columnIndex = 0; columnIndex < selectedElement.C.ColumnCount; columnIndex++)
                            elementMatricesAndVectorDataGridView.Rows[rowIndex].Cells[columnIndex].Value = selectedElement.C.Row(rowIndex)[columnIndex];
                    break;
                case 3: // {P} Vactor
                    elementMatricesAndVectorDataGridView.RowCount = 1;
                    for (int index = 0; index < selectedElement.P.Count; index++)
                        elementMatricesAndVectorDataGridView.Rows[0].Cells[index].Value = selectedElement.P[index];
                    break;
            }
        }
    }
}