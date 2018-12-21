using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
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

        public void AppendTimeTemperature(double time, double minTemp, double maxTemp)
        {
            richTextBox.AppendText($"{time}\t\t{minTemp}\t\t{maxTemp}\n");
        }

        private void setInitialData()
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
                Alpha = Double.Parse(alphaTextBox.Text),
                SpecificHeat = Double.Parse(specificHeatTextBox.Text),
                Conductivity = Double.Parse(conductivityTextBox.Text),
                Density = Double.Parse(densityTextBox.Text)
            };
        }

        private bool isEveryInitialDataTextBoxFilled()
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

        private bool isPositiveNumberTyped(object sender, KeyPressEventArgs e)
        {
            return (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',')) ||
                   (e.KeyChar == ',') && (((TextBox) sender).Text.IndexOf(',') > -1);
        }

        private bool isNumberTyped(object sender, KeyPressEventArgs e)
        {
            return (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') &&
                    (e.KeyChar != '-')) ||
                   (e.KeyChar == ',') && (((TextBox) sender).Text.IndexOf(',') > -1) ||
                   (e.KeyChar == '-') && (((TextBox) sender).Text.IndexOf('-') > -1);
        }

        private void loadInitialDataFileButton_Click(object sender, EventArgs e)
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
                alphaTextBox.Text = initialData.Alpha.ToString();
                specificHeatTextBox.Text = initialData.SpecificHeat.ToString();
                conductivityTextBox.Text = initialData.Conductivity.ToString();
                densityTextBox.Text = initialData.Density.ToString();

                toolStripInitialDataStatusLabel.Text = "Initial data from JSON file has been loaded.";

                if (isEveryInitialDataTextBoxFilled())
                    EnableSimulationAndSaveToJsonButtons();

                openJsonFileDialog.FileName = "";
            }
        }

        private void runSimulationButton_Click(object sender, EventArgs e)
        {
            runSimulationButton.Enabled = false;
            saveResultToTextFileButton.Enabled = false;
            saveGridDetailsToTextFileButton.Enabled = false;
            toolStripProgressLabel.Text = "0%";
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = true;
            toolStripGridAndSimulationStatusLabel.Visible = true;
            toolStripProgressLabel.Visible = true;

            richTextBox.Text = $">>INITAIL DATA<<\n{initialData.ToString()}\n";

            setInitialData();

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
                toolStripGridAndSimulationStatusLabel.Text = "Grid has been created. Simulation is running...";
                richTextBox.AppendText("Time[s]\tMinTemp[°C]\t\t\tMaxTemp[°C]\n");
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
                SimulationProgressBarValue = 100;
                richTextBox.Text = grid.TimeTemperatureToString();
                saveResultToTextFileButton.Enabled = true;
                toolStripProgressBar.Visible = false;
                toolStripProgressLabel.Visible = false;

                if (isEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
                else DisableSimulationAndSaveToJsonButtons();
            });
        }

        private void saveResultToTextFileButton_Click(object sender, EventArgs e)
        {
            saveTextFileDialog.FileName = $"simulation-result-{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            
            if (saveTextFileDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripInitialDataStatusLabel.Text = "Saving simulation result to text file...";
                File.WriteAllText(saveTextFileDialog.FileName, richTextBox.Text);
                toolStripInitialDataStatusLabel.Text = "Simulation result has been saved to text file.";
            }
        }

        private void saveGridDetailsToTextFileButton_Click(object sender, EventArgs e)
        {
            saveTextFileDialog.FileName = $"grid-details-{DateTime.Now.ToString("yyyyMMddHHmmss")}";

            if (saveTextFileDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripInitialDataStatusLabel.Text = "Saving grid details to text file...";
                File.WriteAllText(saveTextFileDialog.FileName, grid.ToString());
                toolStripInitialDataStatusLabel.Text = "Grid details have been saved to text file.";
            }
        }

        private void saveInitialDataToJsonFileButton_Click(object sender, EventArgs e)
        {
            saveJsonFileDialog.FileName = $"initial-data-{DateTime.Now.ToString("yyyyMMddHHmmss")}";

            if (saveJsonFileDialog.ShowDialog() == DialogResult.OK)
            {
                setInitialData();
                toolStripInitialDataStatusLabel.Text = "Saving initial data to JSON file...";
                File.WriteAllText(saveJsonFileDialog.FileName, JsonConvert.SerializeObject(initialData));
                toolStripInitialDataStatusLabel.Text = "Initial data has been saved to JSON file.";
            }
        }

        private void EnableSimulationAndSaveToJsonButtons()
        {
            saveInitialDataToJsonFileButton.Enabled = true;

            if(!isSimulationRunning) runSimulationButton.Enabled = true;
        }

        private void DisableSimulationAndSaveToJsonButtons()
        {
            saveInitialDataToJsonFileButton.Enabled = false;
            runSimulationButton.Enabled = false;
        }

        private void gridLengthTextBox_Leave(object sender, EventArgs e)
        {
            if (isEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void gridHeightTextBox_Leave(object sender, EventArgs e)
        {
            if (isEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void nodesCountAlongTheLengthTextBox_Leave(object sender, EventArgs e)
        {
            if (isEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void nodesCountAlongTheHeightTextBox_Leave(object sender, EventArgs e)
        {
            if (isEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void initialTemperatureTextBox_Leave(object sender, EventArgs e)
        {
            if (isEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void ambientTemperatureTextBox_Leave(object sender, EventArgs e)
        {
            if (isEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void simulationTimeTextBox_Leave(object sender, EventArgs e)
        {
            if (isEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void simulationTimeStepTextBox_Leave(object sender, EventArgs e)
        {
            if (isEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void alphaTextBox_Leave(object sender, EventArgs e)
        {
            if (isEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void specificHeatTextBox_Leave(object sender, EventArgs e)
        {
            if (isEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void conductivityTextBox_Leave(object sender, EventArgs e)
        {
            if (isEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void densityTextBox_Leave(object sender, EventArgs e)
        {
            if (isEveryInitialDataTextBoxFilled()) EnableSimulationAndSaveToJsonButtons();
            else DisableSimulationAndSaveToJsonButtons();
        }

        private void gridLengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isPositiveNumberTyped(sender, e);
        }

        private void gridHeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isPositiveNumberTyped(sender, e);
        }

        private void nodesCountAlongTheLengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isPositiveNumberTyped(sender, e);
        }

        private void nodesCountAlongTheHeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isPositiveNumberTyped(sender, e);
        }

        private void initialTemperatureTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isNumberTyped(sender, e);
        }

        private void ambientTemperatureTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isNumberTyped(sender, e);
        }

        private void simulationTimeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isPositiveNumberTyped(sender, e);
        }

        private void simulationTimeStepTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isPositiveNumberTyped(sender, e);
        }

        private void alphaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isNumberTyped(sender, e);
        }

        private void specificHeatTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isPositiveNumberTyped(sender, e);
        }

        private void conductivityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isPositiveNumberTyped(sender, e);
        }

        private void densityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = isPositiveNumberTyped(sender, e);
        }
    }
}
