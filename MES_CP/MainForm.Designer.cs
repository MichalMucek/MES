namespace MES_CP
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.initialDataGroupBox = new System.Windows.Forms.GroupBox();
            this.saveInitialDataToJsonFileButton = new System.Windows.Forms.Button();
            this.loadInitialDataJsonFileButton = new System.Windows.Forms.Button();
            this.densityTextBox = new System.Windows.Forms.TextBox();
            this.densityLabel = new System.Windows.Forms.Label();
            this.conductivityTextBox = new System.Windows.Forms.TextBox();
            this.conductivityLabel = new System.Windows.Forms.Label();
            this.specificHeatTextBox = new System.Windows.Forms.TextBox();
            this.specificHeatLabel = new System.Windows.Forms.Label();
            this.nodesCountAlongTheHeightTextBox = new System.Windows.Forms.TextBox();
            this.nodesCountAlongTheHeightLabel = new System.Windows.Forms.Label();
            this.nodesCountAlongTheLengthTextBox = new System.Windows.Forms.TextBox();
            this.nodesCountAlongTheLengthLabel = new System.Windows.Forms.Label();
            this.gridHeightTextBox = new System.Windows.Forms.TextBox();
            this.gridHeightLabel = new System.Windows.Forms.Label();
            this.gridLengthTextBox = new System.Windows.Forms.TextBox();
            this.gridLengthLabel = new System.Windows.Forms.Label();
            this.alphaTextBox = new System.Windows.Forms.TextBox();
            this.alphaLabel = new System.Windows.Forms.Label();
            this.ambientTemperatureTextBox = new System.Windows.Forms.TextBox();
            this.ambientTemperatureLabel = new System.Windows.Forms.Label();
            this.simulationTimeStepTextBox = new System.Windows.Forms.TextBox();
            this.simulationTimeStepLabel = new System.Windows.Forms.Label();
            this.simulationTimeTextBox = new System.Windows.Forms.TextBox();
            this.simulationTimeLabel = new System.Windows.Forms.Label();
            this.initialTemperatureTextBox = new System.Windows.Forms.TextBox();
            this.initialTemperatureLabel = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.runSimulationButton = new System.Windows.Forms.Button();
            this.saveResultToTextFileButton = new System.Windows.Forms.Button();
            this.openJsonFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveTextFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveGridDetailsToTextFileButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripInitialDataStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripGridAndSimulationStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveJsonFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.initialDataGroupBox.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // initialDataGroupBox
            // 
            this.initialDataGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.initialDataGroupBox.Controls.Add(this.saveInitialDataToJsonFileButton);
            this.initialDataGroupBox.Controls.Add(this.loadInitialDataJsonFileButton);
            this.initialDataGroupBox.Controls.Add(this.densityTextBox);
            this.initialDataGroupBox.Controls.Add(this.densityLabel);
            this.initialDataGroupBox.Controls.Add(this.conductivityTextBox);
            this.initialDataGroupBox.Controls.Add(this.conductivityLabel);
            this.initialDataGroupBox.Controls.Add(this.specificHeatTextBox);
            this.initialDataGroupBox.Controls.Add(this.specificHeatLabel);
            this.initialDataGroupBox.Controls.Add(this.nodesCountAlongTheHeightTextBox);
            this.initialDataGroupBox.Controls.Add(this.nodesCountAlongTheHeightLabel);
            this.initialDataGroupBox.Controls.Add(this.nodesCountAlongTheLengthTextBox);
            this.initialDataGroupBox.Controls.Add(this.nodesCountAlongTheLengthLabel);
            this.initialDataGroupBox.Controls.Add(this.gridHeightTextBox);
            this.initialDataGroupBox.Controls.Add(this.gridHeightLabel);
            this.initialDataGroupBox.Controls.Add(this.gridLengthTextBox);
            this.initialDataGroupBox.Controls.Add(this.gridLengthLabel);
            this.initialDataGroupBox.Controls.Add(this.alphaTextBox);
            this.initialDataGroupBox.Controls.Add(this.alphaLabel);
            this.initialDataGroupBox.Controls.Add(this.ambientTemperatureTextBox);
            this.initialDataGroupBox.Controls.Add(this.ambientTemperatureLabel);
            this.initialDataGroupBox.Controls.Add(this.simulationTimeStepTextBox);
            this.initialDataGroupBox.Controls.Add(this.simulationTimeStepLabel);
            this.initialDataGroupBox.Controls.Add(this.simulationTimeTextBox);
            this.initialDataGroupBox.Controls.Add(this.simulationTimeLabel);
            this.initialDataGroupBox.Controls.Add(this.initialTemperatureTextBox);
            this.initialDataGroupBox.Controls.Add(this.initialTemperatureLabel);
            this.initialDataGroupBox.Location = new System.Drawing.Point(12, 12);
            this.initialDataGroupBox.MaximumSize = new System.Drawing.Size(279, 383);
            this.initialDataGroupBox.MinimumSize = new System.Drawing.Size(279, 383);
            this.initialDataGroupBox.Name = "initialDataGroupBox";
            this.initialDataGroupBox.Size = new System.Drawing.Size(279, 383);
            this.initialDataGroupBox.TabIndex = 0;
            this.initialDataGroupBox.TabStop = false;
            this.initialDataGroupBox.Text = "Initial data";
            // 
            // saveInitialDataToJsonFileButton
            // 
            this.saveInitialDataToJsonFileButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveInitialDataToJsonFileButton.Enabled = false;
            this.saveInitialDataToJsonFileButton.Location = new System.Drawing.Point(13, 354);
            this.saveInitialDataToJsonFileButton.Name = "saveInitialDataToJsonFileButton";
            this.saveInitialDataToJsonFileButton.Size = new System.Drawing.Size(252, 23);
            this.saveInitialDataToJsonFileButton.TabIndex = 13;
            this.saveInitialDataToJsonFileButton.Text = "Save initial data to JSON file";
            this.saveInitialDataToJsonFileButton.UseVisualStyleBackColor = true;
            this.saveInitialDataToJsonFileButton.Click += new System.EventHandler(this.SaveInitialDataToJsonFileButton_Click);
            // 
            // loadInitialDataJsonFileButton
            // 
            this.loadInitialDataJsonFileButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.loadInitialDataJsonFileButton.Location = new System.Drawing.Point(13, 325);
            this.loadInitialDataJsonFileButton.Name = "loadInitialDataJsonFileButton";
            this.loadInitialDataJsonFileButton.Size = new System.Drawing.Size(252, 23);
            this.loadInitialDataJsonFileButton.TabIndex = 0;
            this.loadInitialDataJsonFileButton.Text = "Load JSON file with initial data";
            this.loadInitialDataJsonFileButton.UseVisualStyleBackColor = true;
            this.loadInitialDataJsonFileButton.Click += new System.EventHandler(this.LoadInitialDataFileButton_Click);
            // 
            // densityTextBox
            // 
            this.densityTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.densityTextBox.Location = new System.Drawing.Point(174, 299);
            this.densityTextBox.Name = "densityTextBox";
            this.densityTextBox.Size = new System.Drawing.Size(99, 20);
            this.densityTextBox.TabIndex = 12;
            this.densityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DensityTextBox_KeyPress);
            this.densityTextBox.Leave += new System.EventHandler(this.DensityTextBox_Leave);
            // 
            // densityLabel
            // 
            this.densityLabel.AutoSize = true;
            this.densityLabel.Location = new System.Drawing.Point(6, 302);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(79, 13);
            this.densityLabel.TabIndex = 24;
            this.densityLabel.Text = "Density [kg/m³]";
            // 
            // conductivityTextBox
            // 
            this.conductivityTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.conductivityTextBox.Location = new System.Drawing.Point(174, 273);
            this.conductivityTextBox.Name = "conductivityTextBox";
            this.conductivityTextBox.Size = new System.Drawing.Size(99, 20);
            this.conductivityTextBox.TabIndex = 11;
            this.conductivityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConductivityTextBox_KeyPress);
            this.conductivityTextBox.Leave += new System.EventHandler(this.ConductivityTextBox_Leave);
            // 
            // conductivityLabel
            // 
            this.conductivityLabel.AutoSize = true;
            this.conductivityLabel.Location = new System.Drawing.Point(6, 276);
            this.conductivityLabel.Name = "conductivityLabel";
            this.conductivityLabel.Size = new System.Drawing.Size(115, 13);
            this.conductivityLabel.TabIndex = 23;
            this.conductivityLabel.Text = "Conductivity [W/(m°C)]";
            // 
            // specificHeatTextBox
            // 
            this.specificHeatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.specificHeatTextBox.Location = new System.Drawing.Point(174, 247);
            this.specificHeatTextBox.Name = "specificHeatTextBox";
            this.specificHeatTextBox.Size = new System.Drawing.Size(99, 20);
            this.specificHeatTextBox.TabIndex = 10;
            this.specificHeatTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpecificHeatTextBox_KeyPress);
            this.specificHeatTextBox.Leave += new System.EventHandler(this.SpecificHeatTextBox_Leave);
            // 
            // specificHeatLabel
            // 
            this.specificHeatLabel.AutoSize = true;
            this.specificHeatLabel.Location = new System.Drawing.Point(6, 250);
            this.specificHeatLabel.Name = "specificHeatLabel";
            this.specificHeatLabel.Size = new System.Drawing.Size(117, 13);
            this.specificHeatLabel.TabIndex = 22;
            this.specificHeatLabel.Text = "Specific heat [J/(kg°C)]";
            // 
            // nodesCountAlongTheHeightTextBox
            // 
            this.nodesCountAlongTheHeightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nodesCountAlongTheHeightTextBox.Location = new System.Drawing.Point(174, 91);
            this.nodesCountAlongTheHeightTextBox.Name = "nodesCountAlongTheHeightTextBox";
            this.nodesCountAlongTheHeightTextBox.Size = new System.Drawing.Size(99, 20);
            this.nodesCountAlongTheHeightTextBox.TabIndex = 4;
            this.nodesCountAlongTheHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NodesCountAlongTheHeightTextBox_KeyPress);
            this.nodesCountAlongTheHeightTextBox.Leave += new System.EventHandler(this.NodesCountAlongTheHeightTextBox_Leave);
            // 
            // nodesCountAlongTheHeightLabel
            // 
            this.nodesCountAlongTheHeightLabel.AutoSize = true;
            this.nodesCountAlongTheHeightLabel.Location = new System.Drawing.Point(6, 94);
            this.nodesCountAlongTheHeightLabel.Name = "nodesCountAlongTheHeightLabel";
            this.nodesCountAlongTheHeightLabel.Size = new System.Drawing.Size(147, 13);
            this.nodesCountAlongTheHeightLabel.TabIndex = 16;
            this.nodesCountAlongTheHeightLabel.Text = "Nodes count along the height";
            // 
            // nodesCountAlongTheLengthTextBox
            // 
            this.nodesCountAlongTheLengthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nodesCountAlongTheLengthTextBox.Location = new System.Drawing.Point(174, 65);
            this.nodesCountAlongTheLengthTextBox.Name = "nodesCountAlongTheLengthTextBox";
            this.nodesCountAlongTheLengthTextBox.Size = new System.Drawing.Size(99, 20);
            this.nodesCountAlongTheLengthTextBox.TabIndex = 3;
            this.nodesCountAlongTheLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NodesCountAlongTheLengthTextBox_KeyPress);
            this.nodesCountAlongTheLengthTextBox.Leave += new System.EventHandler(this.NodesCountAlongTheLengthTextBox_Leave);
            // 
            // nodesCountAlongTheLengthLabel
            // 
            this.nodesCountAlongTheLengthLabel.AutoSize = true;
            this.nodesCountAlongTheLengthLabel.Location = new System.Drawing.Point(6, 68);
            this.nodesCountAlongTheLengthLabel.Name = "nodesCountAlongTheLengthLabel";
            this.nodesCountAlongTheLengthLabel.Size = new System.Drawing.Size(147, 13);
            this.nodesCountAlongTheLengthLabel.TabIndex = 15;
            this.nodesCountAlongTheLengthLabel.Text = "Nodes count along the length";
            // 
            // gridHeightTextBox
            // 
            this.gridHeightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gridHeightTextBox.Location = new System.Drawing.Point(174, 39);
            this.gridHeightTextBox.Name = "gridHeightTextBox";
            this.gridHeightTextBox.Size = new System.Drawing.Size(99, 20);
            this.gridHeightTextBox.TabIndex = 2;
            this.gridHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GridHeightTextBox_KeyPress);
            this.gridHeightTextBox.Leave += new System.EventHandler(this.GridHeightTextBox_Leave);
            // 
            // gridHeightLabel
            // 
            this.gridHeightLabel.AutoSize = true;
            this.gridHeightLabel.Location = new System.Drawing.Point(6, 42);
            this.gridHeightLabel.Name = "gridHeightLabel";
            this.gridHeightLabel.Size = new System.Drawing.Size(75, 13);
            this.gridHeightLabel.TabIndex = 14;
            this.gridHeightLabel.Text = "Grid height [m]";
            // 
            // gridLengthTextBox
            // 
            this.gridLengthTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLengthTextBox.Location = new System.Drawing.Point(174, 13);
            this.gridLengthTextBox.Name = "gridLengthTextBox";
            this.gridLengthTextBox.Size = new System.Drawing.Size(99, 20);
            this.gridLengthTextBox.TabIndex = 1;
            this.gridLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GridLengthTextBox_KeyPress);
            this.gridLengthTextBox.Leave += new System.EventHandler(this.GridLengthTextBox_Leave);
            // 
            // gridLengthLabel
            // 
            this.gridLengthLabel.AutoSize = true;
            this.gridLengthLabel.Location = new System.Drawing.Point(6, 16);
            this.gridLengthLabel.Name = "gridLengthLabel";
            this.gridLengthLabel.Size = new System.Drawing.Size(75, 13);
            this.gridLengthLabel.TabIndex = 13;
            this.gridLengthLabel.Text = "Grid length [m]";
            // 
            // alphaTextBox
            // 
            this.alphaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alphaTextBox.Location = new System.Drawing.Point(174, 221);
            this.alphaTextBox.Name = "alphaTextBox";
            this.alphaTextBox.Size = new System.Drawing.Size(99, 20);
            this.alphaTextBox.TabIndex = 9;
            this.alphaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AlphaTextBox_KeyPress);
            this.alphaTextBox.Leave += new System.EventHandler(this.AlphaTextBox_Leave);
            // 
            // alphaLabel
            // 
            this.alphaLabel.AutoSize = true;
            this.alphaLabel.Location = new System.Drawing.Point(6, 224);
            this.alphaLabel.Name = "alphaLabel";
            this.alphaLabel.Size = new System.Drawing.Size(162, 13);
            this.alphaLabel.TabIndex = 21;
            this.alphaLabel.Text = "Convection coefficient [W/(m²K)]";
            // 
            // ambientTemperatureTextBox
            // 
            this.ambientTemperatureTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ambientTemperatureTextBox.Location = new System.Drawing.Point(174, 143);
            this.ambientTemperatureTextBox.Name = "ambientTemperatureTextBox";
            this.ambientTemperatureTextBox.Size = new System.Drawing.Size(99, 20);
            this.ambientTemperatureTextBox.TabIndex = 6;
            this.ambientTemperatureTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmbientTemperatureTextBox_KeyPress);
            this.ambientTemperatureTextBox.Leave += new System.EventHandler(this.AmbientTemperatureTextBox_Leave);
            // 
            // ambientTemperatureLabel
            // 
            this.ambientTemperatureLabel.AutoSize = true;
            this.ambientTemperatureLabel.Location = new System.Drawing.Point(6, 146);
            this.ambientTemperatureLabel.Name = "ambientTemperatureLabel";
            this.ambientTemperatureLabel.Size = new System.Drawing.Size(124, 13);
            this.ambientTemperatureLabel.TabIndex = 18;
            this.ambientTemperatureLabel.Text = "Ambient temperature [°C]";
            // 
            // simulationTimeStepTextBox
            // 
            this.simulationTimeStepTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simulationTimeStepTextBox.Location = new System.Drawing.Point(174, 195);
            this.simulationTimeStepTextBox.Name = "simulationTimeStepTextBox";
            this.simulationTimeStepTextBox.Size = new System.Drawing.Size(99, 20);
            this.simulationTimeStepTextBox.TabIndex = 8;
            this.simulationTimeStepTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SimulationTimeStepTextBox_KeyPress);
            this.simulationTimeStepTextBox.Leave += new System.EventHandler(this.SimulationTimeStepTextBox_Leave);
            // 
            // simulationTimeStepLabel
            // 
            this.simulationTimeStepLabel.AutoSize = true;
            this.simulationTimeStepLabel.Location = new System.Drawing.Point(6, 198);
            this.simulationTimeStepLabel.Name = "simulationTimeStepLabel";
            this.simulationTimeStepLabel.Size = new System.Drawing.Size(114, 13);
            this.simulationTimeStepLabel.TabIndex = 20;
            this.simulationTimeStepLabel.Text = "Simulation time step [s]";
            // 
            // simulationTimeTextBox
            // 
            this.simulationTimeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simulationTimeTextBox.Location = new System.Drawing.Point(174, 169);
            this.simulationTimeTextBox.Name = "simulationTimeTextBox";
            this.simulationTimeTextBox.Size = new System.Drawing.Size(99, 20);
            this.simulationTimeTextBox.TabIndex = 7;
            this.simulationTimeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SimulationTimeTextBox_KeyPress);
            this.simulationTimeTextBox.Leave += new System.EventHandler(this.SimulationTimeTextBox_Leave);
            // 
            // simulationTimeLabel
            // 
            this.simulationTimeLabel.AutoSize = true;
            this.simulationTimeLabel.Location = new System.Drawing.Point(6, 172);
            this.simulationTimeLabel.Name = "simulationTimeLabel";
            this.simulationTimeLabel.Size = new System.Drawing.Size(91, 13);
            this.simulationTimeLabel.TabIndex = 19;
            this.simulationTimeLabel.Text = "Simulation time [s]";
            // 
            // initialTemperatureTextBox
            // 
            this.initialTemperatureTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.initialTemperatureTextBox.Location = new System.Drawing.Point(174, 117);
            this.initialTemperatureTextBox.Name = "initialTemperatureTextBox";
            this.initialTemperatureTextBox.Size = new System.Drawing.Size(99, 20);
            this.initialTemperatureTextBox.TabIndex = 5;
            this.initialTemperatureTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InitialTemperatureTextBox_KeyPress);
            this.initialTemperatureTextBox.Leave += new System.EventHandler(this.InitialTemperatureTextBox_Leave);
            // 
            // initialTemperatureLabel
            // 
            this.initialTemperatureLabel.AutoSize = true;
            this.initialTemperatureLabel.Location = new System.Drawing.Point(6, 120);
            this.initialTemperatureLabel.Name = "initialTemperatureLabel";
            this.initialTemperatureLabel.Size = new System.Drawing.Size(110, 13);
            this.initialTemperatureLabel.TabIndex = 17;
            this.initialTemperatureLabel.Text = "Initial temperature [°C]";
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.richTextBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox.Location = new System.Drawing.Point(297, 12);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(475, 441);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            this.richTextBox.WordWrap = false;
            // 
            // runSimulationButton
            // 
            this.runSimulationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.runSimulationButton.Enabled = false;
            this.runSimulationButton.Location = new System.Drawing.Point(12, 401);
            this.runSimulationButton.Name = "runSimulationButton";
            this.runSimulationButton.Size = new System.Drawing.Size(279, 23);
            this.runSimulationButton.TabIndex = 0;
            this.runSimulationButton.Text = "Run simulation";
            this.runSimulationButton.UseVisualStyleBackColor = true;
            this.runSimulationButton.Click += new System.EventHandler(this.RunSimulationButton_Click);
            // 
            // saveResultToTextFileButton
            // 
            this.saveResultToTextFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveResultToTextFileButton.Enabled = false;
            this.saveResultToTextFileButton.Location = new System.Drawing.Point(171, 430);
            this.saveResultToTextFileButton.Name = "saveResultToTextFileButton";
            this.saveResultToTextFileButton.Size = new System.Drawing.Size(120, 23);
            this.saveResultToTextFileButton.TabIndex = 2;
            this.saveResultToTextFileButton.Text = "Save result to text file";
            this.saveResultToTextFileButton.UseVisualStyleBackColor = true;
            this.saveResultToTextFileButton.Click += new System.EventHandler(this.SaveResultToTextFileButton_Click);
            // 
            // openJsonFileDialog
            // 
            this.openJsonFileDialog.DefaultExt = "json";
            this.openJsonFileDialog.Filter = "JSON file|*.json|Text file|*.txt";
            this.openJsonFileDialog.Tag = "";
            // 
            // saveTextFileDialog
            // 
            this.saveTextFileDialog.DefaultExt = "txt";
            this.saveTextFileDialog.Filter = "Text file|*.txt|Rich Text Format|*.rtf";
            // 
            // saveGridDetailsToTextFileButton
            // 
            this.saveGridDetailsToTextFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveGridDetailsToTextFileButton.Enabled = false;
            this.saveGridDetailsToTextFileButton.Location = new System.Drawing.Point(12, 430);
            this.saveGridDetailsToTextFileButton.Name = "saveGridDetailsToTextFileButton";
            this.saveGridDetailsToTextFileButton.Size = new System.Drawing.Size(153, 23);
            this.saveGridDetailsToTextFileButton.TabIndex = 1;
            this.saveGridDetailsToTextFileButton.Text = "Save grid details to text file";
            this.saveGridDetailsToTextFileButton.UseVisualStyleBackColor = true;
            this.saveGridDetailsToTextFileButton.Click += new System.EventHandler(this.SaveGridDetailsToTextFileButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripInitialDataStatusLabel,
            this.toolStripGridAndSimulationStatusLabel,
            this.toolStripProgressBar,
            this.toolStripProgressLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 456);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripInitialDataStatusLabel
            // 
            this.toolStripInitialDataStatusLabel.Name = "toolStripInitialDataStatusLabel";
            this.toolStripInitialDataStatusLabel.Size = new System.Drawing.Size(92, 17);
            this.toolStripInitialDataStatusLabel.Text = "Enter initial data";
            // 
            // toolStripGridAndSimulationStatusLabel
            // 
            this.toolStripGridAndSimulationStatusLabel.Name = "toolStripGridAndSimulationStatusLabel";
            this.toolStripGridAndSimulationStatusLabel.Size = new System.Drawing.Size(108, 17);
            this.toolStripGridAndSimulationStatusLabel.Text = "GridAndSimulation";
            this.toolStripGridAndSimulationStatusLabel.Visible = false;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripProgressLabel
            // 
            this.toolStripProgressLabel.Name = "toolStripProgressLabel";
            this.toolStripProgressLabel.Size = new System.Drawing.Size(23, 17);
            this.toolStripProgressLabel.Text = "0%";
            this.toolStripProgressLabel.Visible = false;
            // 
            // saveJsonFileDialog
            // 
            this.saveJsonFileDialog.DefaultExt = "json";
            this.saveJsonFileDialog.Filter = "JSON file|*.json|Text file|*.txt";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 478);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.saveGridDetailsToTextFileButton);
            this.Controls.Add(this.saveResultToTextFileButton);
            this.Controls.Add(this.runSimulationButton);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.initialDataGroupBox);
            this.MinimumSize = new System.Drawing.Size(800, 517);
            this.Name = "MainForm";
            this.Text = "FEM - Temperature distribution 2D";
            this.initialDataGroupBox.ResumeLayout(false);
            this.initialDataGroupBox.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox initialDataGroupBox;
        private System.Windows.Forms.TextBox gridLengthTextBox;
        private System.Windows.Forms.Label gridLengthLabel;
        private System.Windows.Forms.TextBox alphaTextBox;
        private System.Windows.Forms.Label alphaLabel;
        private System.Windows.Forms.TextBox ambientTemperatureTextBox;
        private System.Windows.Forms.Label ambientTemperatureLabel;
        private System.Windows.Forms.TextBox simulationTimeStepTextBox;
        private System.Windows.Forms.Label simulationTimeStepLabel;
        private System.Windows.Forms.TextBox simulationTimeTextBox;
        private System.Windows.Forms.Label simulationTimeLabel;
        private System.Windows.Forms.TextBox initialTemperatureTextBox;
        private System.Windows.Forms.Label initialTemperatureLabel;
        private System.Windows.Forms.TextBox gridHeightTextBox;
        private System.Windows.Forms.Label gridHeightLabel;
        private System.Windows.Forms.TextBox nodesCountAlongTheHeightTextBox;
        private System.Windows.Forms.Label nodesCountAlongTheHeightLabel;
        private System.Windows.Forms.TextBox nodesCountAlongTheLengthTextBox;
        private System.Windows.Forms.Label nodesCountAlongTheLengthLabel;
        private System.Windows.Forms.TextBox densityTextBox;
        private System.Windows.Forms.Label densityLabel;
        private System.Windows.Forms.TextBox conductivityTextBox;
        private System.Windows.Forms.Label conductivityLabel;
        private System.Windows.Forms.TextBox specificHeatTextBox;
        private System.Windows.Forms.Label specificHeatLabel;
        private System.Windows.Forms.Button loadInitialDataJsonFileButton;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button runSimulationButton;
        private System.Windows.Forms.Button saveResultToTextFileButton;
        private System.Windows.Forms.OpenFileDialog openJsonFileDialog;
        private System.Windows.Forms.SaveFileDialog saveTextFileDialog;
        private System.Windows.Forms.Button saveGridDetailsToTextFileButton;
        private System.Windows.Forms.Button saveInitialDataToJsonFileButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripInitialDataStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripProgressLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripGridAndSimulationStatusLabel;
        private System.Windows.Forms.SaveFileDialog saveJsonFileDialog;
    }
}