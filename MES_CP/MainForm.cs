using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MES_CP
{
    public partial class MainForm : Form
    {
        private Grid grid;
        private InitialData initialData;
        private bool isSimulationRunning;

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
            richTextBox.Text = $">>INITAIL DATA<<\n{initialData.ToString()}\n\n" +
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

            toolStripInitialDataStatusLabel.Text = "Initial data is ready.";
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
                    EnableSimulationAndSaveToJsonButtons();

                openJsonFileDialog.FileName = "";
            }
        }

        private void RunSimulationButton_Click(object sender, EventArgs e)
        {
            runSimulationButton.Enabled = false;
            saveResultToTextFileButton.Enabled = false;
            saveGridDetailsToTextFileButton.Enabled = false;
            toolStripProgressLabel.Text = "0%";
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = true;
            toolStripGridAndSimulationStatusLabel.Visible = true;
            toolStripProgressLabel.Visible = true;

            SetInitialData();

            richTextBox.Text = $">>INITAIL DATA<<\n{initialData.ToString()}\n";

            ThreadPool.QueueUserWorkItem(Async_LongRunningTask, "runSimulationButton_Click");
        }

        private void Async_LongRunningTask(object state)
        {
            this.Invoke((MethodInvoker) delegate
            {
                toolStripGridAndSimulationStatusLabel.Text = "Creating new grid...";
            });

            grid = new Grid(initialData);

            this.Invoke((MethodInvoker) delegate
            {
                toolStripGridAndSimulationStatusLabel.Text = "Simulation is running...";
                saveGridDetailsToTextFileButton.Enabled = true;
                SimulationProgressBarValue = 0;
                richTextBox.Select();
                isSimulationRunning = true;
            });

            grid.RunSimulation();

            this.Invoke((MethodInvoker) delegate
            {
                isSimulationRunning = false;
                toolStripGridAndSimulationStatusLabel.Text = "Simulation is completed :)";
                richTextBox.Text = grid.TimeTemperatureToString();
                saveResultToTextFileButton.Enabled = true;
                toolStripProgressBar.Visible = false;
                toolStripProgressLabel.Visible = false;

                if (IsEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
                else DisableSimulationAndSaveToJsonButtons();
            });
        }

        private void SaveResultToTextFileButton_Click(object sender, EventArgs e)
        {
            saveTextFileDialog.FileName = $"simulation-result-{DateTime.Now:yyyyMMddHHmmss}";

            if (saveTextFileDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripInitialDataStatusLabel.Text = "Saving simulation result to text file...";
                File.WriteAllText(saveTextFileDialog.FileName, richTextBox.Text);
                toolStripInitialDataStatusLabel.Text = "Simulation result has been saved to text file.";
            }
        }

        private void SaveGridDetailsToTextFileButton_Click(object sender, EventArgs e)
        {
            saveTextFileDialog.FileName = $"grid-details-{DateTime.Now:yyyyMMddHHmmss}";

            if (saveTextFileDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripInitialDataStatusLabel.Text = "Saving grid details to text file...";
                File.WriteAllText(saveTextFileDialog.FileName, grid.ToString());
                toolStripInitialDataStatusLabel.Text = "Grid details have been saved to text file.";
            }
        }

        private void SaveInitialDataToJsonFileButton_Click(object sender, EventArgs e)
        {
            saveJsonFileDialog.FileName = $"initial-data-{DateTime.Now:yyyyMMddHHmmss}";

            if (saveJsonFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetInitialData();
                toolStripInitialDataStatusLabel.Text = "Saving initial data to JSON file...";
                File.WriteAllText(saveJsonFileDialog.FileName, JsonConvert.SerializeObject(initialData));
                toolStripInitialDataStatusLabel.Text = "Initial data has been saved to JSON file.";
            }
        }

        private void EnableSimulationAndSaveToJsonButtons()
        {
            saveInitialDataToJsonFileButton.Enabled = true;

            if (!isSimulationRunning) runSimulationButton.Enabled = true;
        }

        private void DisableSimulationAndSaveToJsonButtons()
        {
            saveInitialDataToJsonFileButton.Enabled = false;
            runSimulationButton.Enabled = false;
        }

        private void GridLengthTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void GridHeightTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void NodesCountAlongTheLengthTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void NodesCountAlongTheHeightTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void InitialTemperatureTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void AmbientTemperatureTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void SimulationTimeTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void SimulationTimeStepTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void AlphaTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void SpecificHeatTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void ConductivityTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void DensityTextBox_Leave(object sender, EventArgs e)
        {
            if (IsEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
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
    }
}