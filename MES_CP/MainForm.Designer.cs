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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.initialDataGroupBox = new System.Windows.Forms.GroupBox();
            this.saveInitialDataToJsonFileButton = new System.Windows.Forms.Button();
            this.loadInitialDataJsonFileButton = new System.Windows.Forms.Button();
            this.densityTextBox = new System.Windows.Forms.TextBox();
            this.nodesCountAlongTheHeightTextBox = new System.Windows.Forms.TextBox();
            this.nodesCountAlongTheHeightLabel = new System.Windows.Forms.Label();
            this.densityLabel = new System.Windows.Forms.Label();
            this.nodesCountAlongTheLengthTextBox = new System.Windows.Forms.TextBox();
            this.nodesCountAlongTheLengthLabel = new System.Windows.Forms.Label();
            this.conductivityTextBox = new System.Windows.Forms.TextBox();
            this.gridHeightTextBox = new System.Windows.Forms.TextBox();
            this.gridHeightLabel = new System.Windows.Forms.Label();
            this.conductivityLabel = new System.Windows.Forms.Label();
            this.gridLengthTextBox = new System.Windows.Forms.TextBox();
            this.gridLengthLabel = new System.Windows.Forms.Label();
            this.specificHeatTextBox = new System.Windows.Forms.TextBox();
            this.specificHeatLabel = new System.Windows.Forms.Label();
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
            this.startSimulationButton = new System.Windows.Forms.Button();
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
            this.stopSimulationButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.gridTabPage = new System.Windows.Forms.TabPage();
            this.nodesGroupBox = new System.Windows.Forms.GroupBox();
            this.nodeIdLabel = new System.Windows.Forms.Label();
            this.nodeIdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.elementGroupBox = new System.Windows.Forms.GroupBox();
            this.elementMatricesAndVectorDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elementMatricesAndVectorComboBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.elementNode0IdLinkLabel = new System.Windows.Forms.LinkLabel();
            this.elementNode1IdLinkLabel = new System.Windows.Forms.LinkLabel();
            this.elementNode2IdLinkLabel = new System.Windows.Forms.LinkLabel();
            this.elementNode3IdLinkLabel = new System.Windows.Forms.LinkLabel();
            this.leftSideLengthLabel = new System.Windows.Forms.Label();
            this.topSideLengthLabel = new System.Windows.Forms.Label();
            this.rightSideLengthLabel = new System.Windows.Forms.Label();
            this.bottomSideLengthLabel = new System.Windows.Forms.Label();
            this.elementSidesLengthsLabel = new System.Windows.Forms.Label();
            this.elementNodesIdsLabel = new System.Windows.Forms.Label();
            this.elementIdLabel = new System.Windows.Forms.Label();
            this.elementIdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.generateNewGridFromInitialDataButton = new System.Windows.Forms.Button();
            this.simulationTabPage = new System.Windows.Forms.TabPage();
            this.initialDataGroupBox.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.gridTabPage.SuspendLayout();
            this.nodesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeIdNumericUpDown)).BeginInit();
            this.elementGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementMatricesAndVectorDataGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementIdNumericUpDown)).BeginInit();
            this.simulationTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // initialDataGroupBox
            // 
            this.initialDataGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.initialDataGroupBox.Controls.Add(this.saveInitialDataToJsonFileButton);
            this.initialDataGroupBox.Controls.Add(this.loadInitialDataJsonFileButton);
            this.initialDataGroupBox.Controls.Add(this.densityTextBox);
            this.initialDataGroupBox.Controls.Add(this.nodesCountAlongTheHeightTextBox);
            this.initialDataGroupBox.Controls.Add(this.nodesCountAlongTheHeightLabel);
            this.initialDataGroupBox.Controls.Add(this.densityLabel);
            this.initialDataGroupBox.Controls.Add(this.nodesCountAlongTheLengthTextBox);
            this.initialDataGroupBox.Controls.Add(this.nodesCountAlongTheLengthLabel);
            this.initialDataGroupBox.Controls.Add(this.conductivityTextBox);
            this.initialDataGroupBox.Controls.Add(this.gridHeightTextBox);
            this.initialDataGroupBox.Controls.Add(this.gridHeightLabel);
            this.initialDataGroupBox.Controls.Add(this.conductivityLabel);
            this.initialDataGroupBox.Controls.Add(this.gridLengthTextBox);
            this.initialDataGroupBox.Controls.Add(this.gridLengthLabel);
            this.initialDataGroupBox.Controls.Add(this.specificHeatTextBox);
            this.initialDataGroupBox.Controls.Add(this.specificHeatLabel);
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
            this.densityTextBox.Location = new System.Drawing.Point(174, 273);
            this.densityTextBox.Name = "densityTextBox";
            this.densityTextBox.Size = new System.Drawing.Size(99, 20);
            this.densityTextBox.TabIndex = 12;
            this.densityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DensityTextBox_KeyPress);
            this.densityTextBox.Leave += new System.EventHandler(this.DensityTextBox_Leave);
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
            // densityLabel
            // 
            this.densityLabel.AutoSize = true;
            this.densityLabel.Location = new System.Drawing.Point(6, 276);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(79, 13);
            this.densityLabel.TabIndex = 24;
            this.densityLabel.Text = "Density [kg/m³]";
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
            // conductivityTextBox
            // 
            this.conductivityTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.conductivityTextBox.Location = new System.Drawing.Point(174, 247);
            this.conductivityTextBox.Name = "conductivityTextBox";
            this.conductivityTextBox.Size = new System.Drawing.Size(99, 20);
            this.conductivityTextBox.TabIndex = 11;
            this.conductivityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ConductivityTextBox_KeyPress);
            this.conductivityTextBox.Leave += new System.EventHandler(this.ConductivityTextBox_Leave);
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
            // conductivityLabel
            // 
            this.conductivityLabel.AutoSize = true;
            this.conductivityLabel.Location = new System.Drawing.Point(6, 250);
            this.conductivityLabel.Name = "conductivityLabel";
            this.conductivityLabel.Size = new System.Drawing.Size(115, 13);
            this.conductivityLabel.TabIndex = 23;
            this.conductivityLabel.Text = "Conductivity [W/(m°C)]";
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
            // specificHeatTextBox
            // 
            this.specificHeatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.specificHeatTextBox.Location = new System.Drawing.Point(174, 221);
            this.specificHeatTextBox.Name = "specificHeatTextBox";
            this.specificHeatTextBox.Size = new System.Drawing.Size(99, 20);
            this.specificHeatTextBox.TabIndex = 10;
            this.specificHeatTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpecificHeatTextBox_KeyPress);
            this.specificHeatTextBox.Leave += new System.EventHandler(this.SpecificHeatTextBox_Leave);
            // 
            // specificHeatLabel
            // 
            this.specificHeatLabel.AutoSize = true;
            this.specificHeatLabel.Location = new System.Drawing.Point(6, 224);
            this.specificHeatLabel.Name = "specificHeatLabel";
            this.specificHeatLabel.Size = new System.Drawing.Size(117, 13);
            this.specificHeatLabel.TabIndex = 22;
            this.specificHeatLabel.Text = "Specific heat [J/(kg°C)]";
            // 
            // alphaTextBox
            // 
            this.alphaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alphaTextBox.Location = new System.Drawing.Point(174, 299);
            this.alphaTextBox.Name = "alphaTextBox";
            this.alphaTextBox.Size = new System.Drawing.Size(99, 20);
            this.alphaTextBox.TabIndex = 9;
            this.alphaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AlphaTextBox_KeyPress);
            this.alphaTextBox.Leave += new System.EventHandler(this.AlphaTextBox_Leave);
            // 
            // alphaLabel
            // 
            this.alphaLabel.AutoSize = true;
            this.alphaLabel.Location = new System.Drawing.Point(6, 302);
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
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.richTextBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.richTextBox.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox.Location = new System.Drawing.Point(1208, 12);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(575, 629);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            this.richTextBox.WordWrap = false;
            // 
            // startSimulationButton
            // 
            this.startSimulationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startSimulationButton.Enabled = false;
            this.startSimulationButton.Location = new System.Drawing.Point(6, 403);
            this.startSimulationButton.Name = "startSimulationButton";
            this.startSimulationButton.Size = new System.Drawing.Size(87, 23);
            this.startSimulationButton.TabIndex = 0;
            this.startSimulationButton.Text = "Start simulation";
            this.startSimulationButton.UseVisualStyleBackColor = true;
            this.startSimulationButton.Click += new System.EventHandler(this.StartSimulationButton_Click);
            // 
            // saveResultToTextFileButton
            // 
            this.saveResultToTextFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveResultToTextFileButton.Enabled = false;
            this.saveResultToTextFileButton.Location = new System.Drawing.Point(171, 618);
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
            this.saveGridDetailsToTextFileButton.Location = new System.Drawing.Point(114, 403);
            this.saveGridDetailsToTextFileButton.Name = "saveGridDetailsToTextFileButton";
            this.saveGridDetailsToTextFileButton.Size = new System.Drawing.Size(142, 23);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 644);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1795, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripInitialDataStatusLabel
            // 
            this.toolStripInitialDataStatusLabel.Name = "toolStripInitialDataStatusLabel";
            this.toolStripInitialDataStatusLabel.Size = new System.Drawing.Size(240, 17);
            this.toolStripInitialDataStatusLabel.Text = "Enter or load initial data to start a simulation";
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
            // stopSimulationButton
            // 
            this.stopSimulationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopSimulationButton.Enabled = false;
            this.stopSimulationButton.Location = new System.Drawing.Point(99, 403);
            this.stopSimulationButton.Name = "stopSimulationButton";
            this.stopSimulationButton.Size = new System.Drawing.Size(87, 23);
            this.stopSimulationButton.TabIndex = 7;
            this.stopSimulationButton.Text = "Stop simulation";
            this.stopSimulationButton.UseVisualStyleBackColor = true;
            this.stopSimulationButton.Click += new System.EventHandler(this.StopSimulationButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl.Controls.Add(this.gridTabPage);
            this.tabControl.Controls.Add(this.simulationTabPage);
            this.tabControl.Location = new System.Drawing.Point(297, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(905, 458);
            this.tabControl.TabIndex = 8;
            // 
            // gridTabPage
            // 
            this.gridTabPage.BackColor = System.Drawing.Color.White;
            this.gridTabPage.Controls.Add(this.nodesGroupBox);
            this.gridTabPage.Controls.Add(this.elementGroupBox);
            this.gridTabPage.Controls.Add(this.saveGridDetailsToTextFileButton);
            this.gridTabPage.Controls.Add(this.generateNewGridFromInitialDataButton);
            this.gridTabPage.Location = new System.Drawing.Point(4, 22);
            this.gridTabPage.Name = "gridTabPage";
            this.gridTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.gridTabPage.Size = new System.Drawing.Size(897, 432);
            this.gridTabPage.TabIndex = 0;
            this.gridTabPage.Text = "Grid";
            // 
            // nodesGroupBox
            // 
            this.nodesGroupBox.Controls.Add(this.nodeIdLabel);
            this.nodesGroupBox.Controls.Add(this.nodeIdNumericUpDown);
            this.nodesGroupBox.Location = new System.Drawing.Point(528, 6);
            this.nodesGroupBox.Name = "nodesGroupBox";
            this.nodesGroupBox.Size = new System.Drawing.Size(363, 392);
            this.nodesGroupBox.TabIndex = 38;
            this.nodesGroupBox.TabStop = false;
            this.nodesGroupBox.Text = "Node";
            // 
            // nodeIdLabel
            // 
            this.nodeIdLabel.AutoSize = true;
            this.nodeIdLabel.Location = new System.Drawing.Point(6, 16);
            this.nodeIdLabel.Name = "nodeIdLabel";
            this.nodeIdLabel.Size = new System.Drawing.Size(21, 13);
            this.nodeIdLabel.TabIndex = 2;
            this.nodeIdLabel.Text = "ID:";
            // 
            // nodeIdNumericUpDown
            // 
            this.nodeIdNumericUpDown.Enabled = false;
            this.nodeIdNumericUpDown.Location = new System.Drawing.Point(33, 14);
            this.nodeIdNumericUpDown.Name = "nodeIdNumericUpDown";
            this.nodeIdNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.nodeIdNumericUpDown.TabIndex = 0;
            // 
            // elementGroupBox
            // 
            this.elementGroupBox.Controls.Add(this.elementMatricesAndVectorDataGridView);
            this.elementGroupBox.Controls.Add(this.elementMatricesAndVectorComboBox);
            this.elementGroupBox.Controls.Add(this.flowLayoutPanel1);
            this.elementGroupBox.Controls.Add(this.leftSideLengthLabel);
            this.elementGroupBox.Controls.Add(this.topSideLengthLabel);
            this.elementGroupBox.Controls.Add(this.rightSideLengthLabel);
            this.elementGroupBox.Controls.Add(this.bottomSideLengthLabel);
            this.elementGroupBox.Controls.Add(this.elementSidesLengthsLabel);
            this.elementGroupBox.Controls.Add(this.elementNodesIdsLabel);
            this.elementGroupBox.Controls.Add(this.elementIdLabel);
            this.elementGroupBox.Controls.Add(this.elementIdNumericUpDown);
            this.elementGroupBox.Location = new System.Drawing.Point(6, 6);
            this.elementGroupBox.Name = "elementGroupBox";
            this.elementGroupBox.Size = new System.Drawing.Size(516, 392);
            this.elementGroupBox.TabIndex = 37;
            this.elementGroupBox.TabStop = false;
            this.elementGroupBox.Text = "Element";
            // 
            // elementMatricesAndVectorDataGridView
            // 
            this.elementMatricesAndVectorDataGridView.AllowUserToAddRows = false;
            this.elementMatricesAndVectorDataGridView.AllowUserToDeleteRows = false;
            this.elementMatricesAndVectorDataGridView.AllowUserToResizeColumns = false;
            this.elementMatricesAndVectorDataGridView.AllowUserToResizeRows = false;
            this.elementMatricesAndVectorDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.elementMatricesAndVectorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elementMatricesAndVectorDataGridView.ColumnHeadersVisible = false;
            this.elementMatricesAndVectorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.elementMatricesAndVectorDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.elementMatricesAndVectorDataGridView.Location = new System.Drawing.Point(6, 183);
            this.elementMatricesAndVectorDataGridView.Name = "elementMatricesAndVectorDataGridView";
            this.elementMatricesAndVectorDataGridView.ReadOnly = true;
            this.elementMatricesAndVectorDataGridView.RowHeadersVisible = false;
            this.elementMatricesAndVectorDataGridView.RowTemplate.Height = 50;
            this.elementMatricesAndVectorDataGridView.Size = new System.Drawing.Size(504, 203);
            this.elementMatricesAndVectorDataGridView.TabIndex = 39;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // elementMatricesAndVectorComboBox
            // 
            this.elementMatricesAndVectorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.elementMatricesAndVectorComboBox.Enabled = false;
            this.elementMatricesAndVectorComboBox.FormattingEnabled = true;
            this.elementMatricesAndVectorComboBox.Items.AddRange(new object[] {
            "[H] Matrix",
            "[H_BC] Matrix",
            "[C] Matrix",
            "{P} Vector"});
            this.elementMatricesAndVectorComboBox.Location = new System.Drawing.Point(6, 156);
            this.elementMatricesAndVectorComboBox.MaxDropDownItems = 4;
            this.elementMatricesAndVectorComboBox.Name = "elementMatricesAndVectorComboBox";
            this.elementMatricesAndVectorComboBox.Size = new System.Drawing.Size(121, 21);
            this.elementMatricesAndVectorComboBox.TabIndex = 13;
            this.elementMatricesAndVectorComboBox.SelectedIndexChanged += new System.EventHandler(this.ElementMatricesAndVectorComboBox_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.elementNode0IdLinkLabel);
            this.flowLayoutPanel1.Controls.Add(this.elementNode1IdLinkLabel);
            this.flowLayoutPanel1.Controls.Add(this.elementNode2IdLinkLabel);
            this.flowLayoutPanel1.Controls.Add(this.elementNode3IdLinkLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(53, 42);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(442, 16);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // elementNode0IdLinkLabel
            // 
            this.elementNode0IdLinkLabel.AutoSize = true;
            this.elementNode0IdLinkLabel.Enabled = false;
            this.elementNode0IdLinkLabel.Location = new System.Drawing.Point(3, 0);
            this.elementNode0IdLinkLabel.Name = "elementNode0IdLinkLabel";
            this.elementNode0IdLinkLabel.Size = new System.Drawing.Size(0, 13);
            this.elementNode0IdLinkLabel.TabIndex = 12;
            this.elementNode0IdLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ElementNode0IdLinkLabel_LinkClicked);
            // 
            // elementNode1IdLinkLabel
            // 
            this.elementNode1IdLinkLabel.AutoSize = true;
            this.elementNode1IdLinkLabel.Enabled = false;
            this.elementNode1IdLinkLabel.Location = new System.Drawing.Point(9, 0);
            this.elementNode1IdLinkLabel.Name = "elementNode1IdLinkLabel";
            this.elementNode1IdLinkLabel.Size = new System.Drawing.Size(0, 13);
            this.elementNode1IdLinkLabel.TabIndex = 13;
            this.elementNode1IdLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ElementNode1IdLinkLabel_LinkClicked);
            // 
            // elementNode2IdLinkLabel
            // 
            this.elementNode2IdLinkLabel.AutoSize = true;
            this.elementNode2IdLinkLabel.Enabled = false;
            this.elementNode2IdLinkLabel.Location = new System.Drawing.Point(15, 0);
            this.elementNode2IdLinkLabel.Name = "elementNode2IdLinkLabel";
            this.elementNode2IdLinkLabel.Size = new System.Drawing.Size(0, 13);
            this.elementNode2IdLinkLabel.TabIndex = 14;
            this.elementNode2IdLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ElementNode2IdLinkLabel_LinkClicked);
            // 
            // elementNode3IdLinkLabel
            // 
            this.elementNode3IdLinkLabel.AutoSize = true;
            this.elementNode3IdLinkLabel.Enabled = false;
            this.elementNode3IdLinkLabel.Location = new System.Drawing.Point(21, 0);
            this.elementNode3IdLinkLabel.Name = "elementNode3IdLinkLabel";
            this.elementNode3IdLinkLabel.Size = new System.Drawing.Size(0, 13);
            this.elementNode3IdLinkLabel.TabIndex = 15;
            this.elementNode3IdLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ElementNode3IdLinkLabel_LinkClicked);
            // 
            // leftSideLengthLabel
            // 
            this.leftSideLengthLabel.AutoSize = true;
            this.leftSideLengthLabel.Location = new System.Drawing.Point(30, 133);
            this.leftSideLengthLabel.Name = "leftSideLengthLabel";
            this.leftSideLengthLabel.Size = new System.Drawing.Size(28, 13);
            this.leftSideLengthLabel.TabIndex = 7;
            this.leftSideLengthLabel.Text = "Left:";
            // 
            // topSideLengthLabel
            // 
            this.topSideLengthLabel.AutoSize = true;
            this.topSideLengthLabel.Location = new System.Drawing.Point(30, 120);
            this.topSideLengthLabel.Name = "topSideLengthLabel";
            this.topSideLengthLabel.Size = new System.Drawing.Size(29, 13);
            this.topSideLengthLabel.TabIndex = 6;
            this.topSideLengthLabel.Text = "Top:";
            // 
            // rightSideLengthLabel
            // 
            this.rightSideLengthLabel.AutoSize = true;
            this.rightSideLengthLabel.Location = new System.Drawing.Point(30, 107);
            this.rightSideLengthLabel.Name = "rightSideLengthLabel";
            this.rightSideLengthLabel.Size = new System.Drawing.Size(35, 13);
            this.rightSideLengthLabel.TabIndex = 5;
            this.rightSideLengthLabel.Text = "Right:";
            // 
            // bottomSideLengthLabel
            // 
            this.bottomSideLengthLabel.AutoSize = true;
            this.bottomSideLengthLabel.Location = new System.Drawing.Point(30, 94);
            this.bottomSideLengthLabel.Name = "bottomSideLengthLabel";
            this.bottomSideLengthLabel.Size = new System.Drawing.Size(43, 13);
            this.bottomSideLengthLabel.TabIndex = 4;
            this.bottomSideLengthLabel.Text = "Bottom:";
            // 
            // elementSidesLengthsLabel
            // 
            this.elementSidesLengthsLabel.AutoSize = true;
            this.elementSidesLengthsLabel.Location = new System.Drawing.Point(6, 68);
            this.elementSidesLengthsLabel.Name = "elementSidesLengthsLabel";
            this.elementSidesLengthsLabel.Size = new System.Drawing.Size(73, 13);
            this.elementSidesLengthsLabel.TabIndex = 3;
            this.elementSidesLengthsLabel.Text = "Sides lengths:";
            // 
            // elementNodesIdsLabel
            // 
            this.elementNodesIdsLabel.AutoSize = true;
            this.elementNodesIdsLabel.Location = new System.Drawing.Point(6, 42);
            this.elementNodesIdsLabel.Name = "elementNodesIdsLabel";
            this.elementNodesIdsLabel.Size = new System.Drawing.Size(41, 13);
            this.elementNodesIdsLabel.TabIndex = 2;
            this.elementNodesIdsLabel.Text = "Nodes:";
            // 
            // elementIdLabel
            // 
            this.elementIdLabel.AutoSize = true;
            this.elementIdLabel.Location = new System.Drawing.Point(6, 16);
            this.elementIdLabel.Name = "elementIdLabel";
            this.elementIdLabel.Size = new System.Drawing.Size(21, 13);
            this.elementIdLabel.TabIndex = 1;
            this.elementIdLabel.Text = "ID:";
            // 
            // elementIdNumericUpDown
            // 
            this.elementIdNumericUpDown.Enabled = false;
            this.elementIdNumericUpDown.Location = new System.Drawing.Point(33, 14);
            this.elementIdNumericUpDown.Name = "elementIdNumericUpDown";
            this.elementIdNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.elementIdNumericUpDown.TabIndex = 0;
            this.elementIdNumericUpDown.ValueChanged += new System.EventHandler(this.ElementIdNumericUpDown_ValueChanged);
            // 
            // generateNewGridFromInitialDataButton
            // 
            this.generateNewGridFromInitialDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.generateNewGridFromInitialDataButton.Enabled = false;
            this.generateNewGridFromInitialDataButton.Location = new System.Drawing.Point(6, 403);
            this.generateNewGridFromInitialDataButton.Name = "generateNewGridFromInitialDataButton";
            this.generateNewGridFromInitialDataButton.Size = new System.Drawing.Size(102, 23);
            this.generateNewGridFromInitialDataButton.TabIndex = 0;
            this.generateNewGridFromInitialDataButton.Text = "Generate new grid";
            this.generateNewGridFromInitialDataButton.UseVisualStyleBackColor = true;
            this.generateNewGridFromInitialDataButton.Click += new System.EventHandler(this.GenerateNewGridFromInitialDataButton_Click);
            // 
            // simulationTabPage
            // 
            this.simulationTabPage.BackColor = System.Drawing.Color.White;
            this.simulationTabPage.Controls.Add(this.startSimulationButton);
            this.simulationTabPage.Controls.Add(this.stopSimulationButton);
            this.simulationTabPage.Location = new System.Drawing.Point(4, 22);
            this.simulationTabPage.Name = "simulationTabPage";
            this.simulationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.simulationTabPage.Size = new System.Drawing.Size(897, 432);
            this.simulationTabPage.TabIndex = 1;
            this.simulationTabPage.Text = "Simulation";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1795, 666);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.saveResultToTextFileButton);
            this.Controls.Add(this.initialDataGroupBox);
            this.MinimumSize = new System.Drawing.Size(900, 517);
            this.Name = "MainForm";
            this.Text = "FEM - Temperature distribution 2D";
            this.initialDataGroupBox.ResumeLayout(false);
            this.initialDataGroupBox.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.gridTabPage.ResumeLayout(false);
            this.nodesGroupBox.ResumeLayout(false);
            this.nodesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeIdNumericUpDown)).EndInit();
            this.elementGroupBox.ResumeLayout(false);
            this.elementGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementMatricesAndVectorDataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elementIdNumericUpDown)).EndInit();
            this.simulationTabPage.ResumeLayout(false);
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
        private System.Windows.Forms.Button startSimulationButton;
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
        private System.Windows.Forms.Button stopSimulationButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage gridTabPage;
        private System.Windows.Forms.Button generateNewGridFromInitialDataButton;
        private System.Windows.Forms.TabPage simulationTabPage;
        private System.Windows.Forms.GroupBox nodesGroupBox;
        private System.Windows.Forms.Label nodeIdLabel;
        private System.Windows.Forms.NumericUpDown nodeIdNumericUpDown;
        private System.Windows.Forms.GroupBox elementGroupBox;
        private System.Windows.Forms.Label elementIdLabel;
        private System.Windows.Forms.NumericUpDown elementIdNumericUpDown;
        private System.Windows.Forms.Label leftSideLengthLabel;
        private System.Windows.Forms.Label topSideLengthLabel;
        private System.Windows.Forms.Label rightSideLengthLabel;
        private System.Windows.Forms.Label bottomSideLengthLabel;
        private System.Windows.Forms.Label elementSidesLengthsLabel;
        private System.Windows.Forms.Label elementNodesIdsLabel;
        private System.Windows.Forms.LinkLabel elementNode3IdLinkLabel;
        private System.Windows.Forms.LinkLabel elementNode2IdLinkLabel;
        private System.Windows.Forms.LinkLabel elementNode1IdLinkLabel;
        private System.Windows.Forms.LinkLabel elementNode0IdLinkLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView elementMatricesAndVectorDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ComboBox elementMatricesAndVectorComboBox;
    }
}