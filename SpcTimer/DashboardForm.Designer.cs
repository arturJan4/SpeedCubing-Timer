namespace SpcTimer
{
    partial class DashboardForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.LabelTest = new System.Windows.Forms.Label();
            this.mainWinformsTimer = new System.Windows.Forms.Timer(this.components);
            this.ClockLabel = new System.Windows.Forms.Label();
            this.DNFLabel = new System.Windows.Forms.Label();
            this.CubeTypeLabel = new System.Windows.Forms.Label();
            this.ScrambleLabel = new System.Windows.Forms.Label();
            this.StatisticsListBox = new System.Windows.Forms.ListBox();
            this.InspectionLabel = new System.Windows.Forms.Label();
            this.Bo12ValueLabel = new System.Windows.Forms.Label();
            this.Bo5ValueLabel = new System.Windows.Forms.Label();
            this.AverageValueLabel = new System.Windows.Forms.Label();
            this.WorstValueLabel = new System.Windows.Forms.Label();
            this.BestValueLabel = new System.Windows.Forms.Label();
            this.Bo12Label = new System.Windows.Forms.Label();
            this.Bo5Label = new System.Windows.Forms.Label();
            this.AverageLabel = new System.Windows.Forms.Label();
            this.WorstLabel = new System.Windows.Forms.Label();
            this.BestLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DeleteLastButton = new SpcTimer.NonSelectableButton();
            this.SetDNFButton = new SpcTimer.NonSelectableButton();
            this.DeleteSelectedButton = new SpcTimer.NonSelectableButton();
            this.DeleteAllButton = new SpcTimer.NonSelectableButton();
            this.CubeTypeComboBox = new SpcTimer.NonSelectableComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SoundButton = new SpcTimer.NonSelectableButton();
            this.ConfirmInspectionButton = new SpcTimer.NonSelectableButton();
            this.label1 = new System.Windows.Forms.Label();
            this.InspectionTimeLabel = new System.Windows.Forms.TextBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.resetButton = new SpcTimer.NonSelectableButton();
            this.StartTimerButton = new SpcTimer.NonSelectableButton();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelTest
            // 
            this.LabelTest.AutoSize = true;
            this.LabelTest.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelTest.ForeColor = System.Drawing.Color.White;
            this.LabelTest.Location = new System.Drawing.Point(162, 3);
            this.LabelTest.Name = "LabelTest";
            this.LabelTest.Size = new System.Drawing.Size(32, 17);
            this.LabelTest.TabIndex = 2;
            this.LabelTest.Text = "Test";
            // 
            // mainWinformsTimer
            // 
            this.mainWinformsTimer.Enabled = true;
            this.mainWinformsTimer.Interval = 10;
            this.mainWinformsTimer.Tick += new System.EventHandler(this.MainWinformsTimer_Tick);
            // 
            // ClockLabel
            // 
            this.ClockLabel.BackColor = System.Drawing.Color.Transparent;
            this.ClockLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ClockLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClockLabel.Font = new System.Drawing.Font("Ebrima", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ClockLabel.ForeColor = System.Drawing.Color.White;
            this.ClockLabel.Location = new System.Drawing.Point(133, 54);
            this.ClockLabel.Name = "ClockLabel";
            this.ClockLabel.Size = new System.Drawing.Size(322, 47);
            this.ClockLabel.TabIndex = 0;
            this.ClockLabel.Text = "Clock";
            this.ClockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DNFLabel
            // 
            this.DNFLabel.AutoSize = true;
            this.DNFLabel.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DNFLabel.ForeColor = System.Drawing.Color.White;
            this.DNFLabel.Location = new System.Drawing.Point(472, 80);
            this.DNFLabel.Name = "DNFLabel";
            this.DNFLabel.Size = new System.Drawing.Size(41, 21);
            this.DNFLabel.TabIndex = 3;
            this.DNFLabel.Text = "DNF";
            // 
            // CubeTypeLabel
            // 
            this.CubeTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.CubeTypeLabel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CubeTypeLabel.ForeColor = System.Drawing.Color.White;
            this.CubeTypeLabel.Location = new System.Drawing.Point(47, 14);
            this.CubeTypeLabel.Name = "CubeTypeLabel";
            this.CubeTypeLabel.Size = new System.Drawing.Size(70, 17);
            this.CubeTypeLabel.TabIndex = 4;
            this.CubeTypeLabel.Text = "Cube Type";
            this.CubeTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScrambleLabel
            // 
            this.ScrambleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ScrambleLabel.BackColor = System.Drawing.Color.Transparent;
            this.ScrambleLabel.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ScrambleLabel.ForeColor = System.Drawing.Color.White;
            this.ScrambleLabel.Location = new System.Drawing.Point(27, 180);
            this.ScrambleLabel.MinimumSize = new System.Drawing.Size(535, 52);
            this.ScrambleLabel.Name = "ScrambleLabel";
            this.ScrambleLabel.Size = new System.Drawing.Size(535, 52);
            this.ScrambleLabel.TabIndex = 5;
            this.ScrambleLabel.Text = "Scramble";
            this.ScrambleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatisticsListBox
            // 
            this.StatisticsListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StatisticsListBox.FormattingEnabled = true;
            this.StatisticsListBox.Location = new System.Drawing.Point(3, 9);
            this.StatisticsListBox.Name = "StatisticsListBox";
            this.tableLayoutPanel1.SetRowSpan(this.StatisticsListBox, 5);
            this.StatisticsListBox.ScrollAlwaysVisible = true;
            this.StatisticsListBox.Size = new System.Drawing.Size(205, 225);
            this.StatisticsListBox.TabIndex = 20;
            this.StatisticsListBox.TabStop = false;
            this.StatisticsListBox.SelectedIndexChanged += new System.EventHandler(this.StatisticsListBox_SelectedIndexChanged);
            // 
            // InspectionLabel
            // 
            this.InspectionLabel.AutoSize = true;
            this.InspectionLabel.BackColor = System.Drawing.Color.Transparent;
            this.InspectionLabel.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InspectionLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.InspectionLabel.Location = new System.Drawing.Point(242, 24);
            this.InspectionLabel.Name = "InspectionLabel";
            this.InspectionLabel.Size = new System.Drawing.Size(105, 25);
            this.InspectionLabel.TabIndex = 10;
            this.InspectionLabel.Text = "Inspection";
            this.InspectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InspectionLabel.Visible = false;
            // 
            // Bo12ValueLabel
            // 
            this.Bo12ValueLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Bo12ValueLabel.AutoSize = true;
            this.Bo12ValueLabel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Bo12ValueLabel.ForeColor = System.Drawing.Color.White;
            this.Bo12ValueLabel.Location = new System.Drawing.Point(333, 209);
            this.Bo12ValueLabel.Name = "Bo12ValueLabel";
            this.Bo12ValueLabel.Size = new System.Drawing.Size(73, 17);
            this.Bo12ValueLabel.TabIndex = 12;
            this.Bo12ValueLabel.Text = "00:00:00:00";
            // 
            // Bo5ValueLabel
            // 
            this.Bo5ValueLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Bo5ValueLabel.AutoSize = true;
            this.Bo5ValueLabel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Bo5ValueLabel.ForeColor = System.Drawing.Color.White;
            this.Bo5ValueLabel.Location = new System.Drawing.Point(333, 159);
            this.Bo5ValueLabel.Name = "Bo5ValueLabel";
            this.Bo5ValueLabel.Size = new System.Drawing.Size(73, 17);
            this.Bo5ValueLabel.TabIndex = 11;
            this.Bo5ValueLabel.Text = "00:00:00:00";
            // 
            // AverageValueLabel
            // 
            this.AverageValueLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AverageValueLabel.AutoSize = true;
            this.AverageValueLabel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AverageValueLabel.ForeColor = System.Drawing.Color.White;
            this.AverageValueLabel.Location = new System.Drawing.Point(333, 111);
            this.AverageValueLabel.Name = "AverageValueLabel";
            this.AverageValueLabel.Size = new System.Drawing.Size(73, 17);
            this.AverageValueLabel.TabIndex = 10;
            this.AverageValueLabel.Text = "00:00:00:00";
            // 
            // WorstValueLabel
            // 
            this.WorstValueLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WorstValueLabel.AutoSize = true;
            this.WorstValueLabel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WorstValueLabel.ForeColor = System.Drawing.Color.White;
            this.WorstValueLabel.Location = new System.Drawing.Point(333, 63);
            this.WorstValueLabel.Name = "WorstValueLabel";
            this.WorstValueLabel.Size = new System.Drawing.Size(73, 17);
            this.WorstValueLabel.TabIndex = 9;
            this.WorstValueLabel.Text = "00:00:00:00";
            // 
            // BestValueLabel
            // 
            this.BestValueLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BestValueLabel.AutoSize = true;
            this.BestValueLabel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BestValueLabel.ForeColor = System.Drawing.Color.White;
            this.BestValueLabel.Location = new System.Drawing.Point(333, 15);
            this.BestValueLabel.Name = "BestValueLabel";
            this.BestValueLabel.Size = new System.Drawing.Size(73, 17);
            this.BestValueLabel.TabIndex = 8;
            this.BestValueLabel.Text = "00:00:00:00";
            // 
            // Bo12Label
            // 
            this.Bo12Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Bo12Label.AutoSize = true;
            this.Bo12Label.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Bo12Label.ForeColor = System.Drawing.Color.White;
            this.Bo12Label.Location = new System.Drawing.Point(229, 209);
            this.Bo12Label.Name = "Bo12Label";
            this.Bo12Label.Size = new System.Drawing.Size(69, 17);
            this.Bo12Label.TabIndex = 7;
            this.Bo12Label.Text = "Best of 12:";
            // 
            // Bo5Label
            // 
            this.Bo5Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Bo5Label.AutoSize = true;
            this.Bo5Label.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Bo5Label.ForeColor = System.Drawing.Color.White;
            this.Bo5Label.Location = new System.Drawing.Point(232, 159);
            this.Bo5Label.Name = "Bo5Label";
            this.Bo5Label.Size = new System.Drawing.Size(62, 17);
            this.Bo5Label.TabIndex = 6;
            this.Bo5Label.Text = "Best of 5:";
            // 
            // AverageLabel
            // 
            this.AverageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AverageLabel.AutoSize = true;
            this.AverageLabel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AverageLabel.ForeColor = System.Drawing.Color.White;
            this.AverageLabel.Location = new System.Drawing.Point(234, 111);
            this.AverageLabel.Name = "AverageLabel";
            this.AverageLabel.Size = new System.Drawing.Size(59, 17);
            this.AverageLabel.TabIndex = 5;
            this.AverageLabel.Text = "Average:";
            // 
            // WorstLabel
            // 
            this.WorstLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WorstLabel.AutoSize = true;
            this.WorstLabel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WorstLabel.ForeColor = System.Drawing.Color.White;
            this.WorstLabel.Location = new System.Drawing.Point(240, 63);
            this.WorstLabel.Name = "WorstLabel";
            this.WorstLabel.Size = new System.Drawing.Size(46, 17);
            this.WorstLabel.TabIndex = 4;
            this.WorstLabel.Text = "Worst:";
            // 
            // BestLabel
            // 
            this.BestLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BestLabel.AutoSize = true;
            this.BestLabel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BestLabel.ForeColor = System.Drawing.Color.White;
            this.BestLabel.Location = new System.Drawing.Point(246, 15);
            this.BestLabel.Name = "BestLabel";
            this.BestLabel.Size = new System.Drawing.Size(35, 17);
            this.BestLabel.TabIndex = 3;
            this.BestLabel.Text = "Best:";
            this.BestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.DeleteLastButton);
            this.panel4.Controls.Add(this.SetDNFButton);
            this.panel4.Controls.Add(this.DeleteSelectedButton);
            this.panel4.Controls.Add(this.DeleteAllButton);
            this.panel4.Controls.Add(this.CubeTypeComboBox);
            this.panel4.Controls.Add(this.CubeTypeLabel);
            this.panel4.Controls.Add(this.LabelTest);
            this.panel4.Location = new System.Drawing.Point(428, 263);
            this.panel4.MinimumSize = new System.Drawing.Size(162, 244);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(162, 244);
            this.panel4.TabIndex = 15;
            // 
            // DeleteLastButton
            // 
            this.DeleteLastButton.Location = new System.Drawing.Point(24, 121);
            this.DeleteLastButton.Name = "DeleteLastButton";
            this.DeleteLastButton.Size = new System.Drawing.Size(121, 23);
            this.DeleteLastButton.TabIndex = 13;
            this.DeleteLastButton.Text = "Delete Last";
            this.DeleteLastButton.UseVisualStyleBackColor = true;
            this.DeleteLastButton.Click += new System.EventHandler(this.DeleteLastButton_Click);
            // 
            // SetDNFButton
            // 
            this.SetDNFButton.Location = new System.Drawing.Point(24, 79);
            this.SetDNFButton.Name = "SetDNFButton";
            this.SetDNFButton.Size = new System.Drawing.Size(121, 23);
            this.SetDNFButton.TabIndex = 12;
            this.SetDNFButton.Text = "Set DNF";
            this.SetDNFButton.UseVisualStyleBackColor = true;
            this.SetDNFButton.Click += new System.EventHandler(this.SetDNFButton_Click);
            // 
            // DeleteSelectedButton
            // 
            this.DeleteSelectedButton.Location = new System.Drawing.Point(24, 164);
            this.DeleteSelectedButton.Name = "DeleteSelectedButton";
            this.DeleteSelectedButton.Size = new System.Drawing.Size(121, 23);
            this.DeleteSelectedButton.TabIndex = 11;
            this.DeleteSelectedButton.Text = "Delete Selected";
            this.DeleteSelectedButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedButton.Click += new System.EventHandler(this.DeleteSelectedButton_Click);
            // 
            // DeleteAllButton
            // 
            this.DeleteAllButton.Location = new System.Drawing.Point(24, 208);
            this.DeleteAllButton.Name = "DeleteAllButton";
            this.DeleteAllButton.Size = new System.Drawing.Size(121, 23);
            this.DeleteAllButton.TabIndex = 10;
            this.DeleteAllButton.Text = "Delete All";
            this.DeleteAllButton.UseVisualStyleBackColor = true;
            this.DeleteAllButton.Click += new System.EventHandler(this.DeleteAllButton_Click);
            // 
            // CubeTypeComboBox
            // 
            this.CubeTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CubeTypeComboBox.FormattingEnabled = true;
            this.CubeTypeComboBox.Items.AddRange(new object[] {
            "2x2 Cube",
            "3x3 Cube",
            "4x4 Cube"});
            this.CubeTypeComboBox.Location = new System.Drawing.Point(24, 40);
            this.CubeTypeComboBox.Name = "CubeTypeComboBox";
            this.CubeTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.CubeTypeComboBox.TabIndex = 9;
            this.CubeTypeComboBox.TabStop = false;
            this.CubeTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.CubeTypeComboBox_SelectionChangeCommitted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.StatisticsListBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Bo12ValueLabel, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.BestLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BestValueLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Bo12Label, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Bo5ValueLabel, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.WorstValueLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Bo5Label, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.AverageLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.AverageValueLabel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.WorstLabel, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-1, 263);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(423, 244);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(423, 244);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.SoundButton);
            this.panel1.Controls.Add(this.ConfirmInspectionButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.InspectionTimeLabel);
            this.panel1.Controls.Add(this.InfoLabel);
            this.panel1.Controls.Add(this.ScrambleLabel);
            this.panel1.Controls.Add(this.DNFLabel);
            this.panel1.Controls.Add(this.resetButton);
            this.panel1.Controls.Add(this.InspectionLabel);
            this.panel1.Controls.Add(this.StartTimerButton);
            this.panel1.Controls.Add(this.ClockLabel);
            this.panel1.Location = new System.Drawing.Point(2, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 252);
            this.panel1.TabIndex = 17;
            // 
            // SoundButton
            // 
            this.SoundButton.ForeColor = System.Drawing.Color.Transparent;
            this.SoundButton.Image = ((System.Drawing.Image)(resources.GetObject("SoundButton.Image")));
            this.SoundButton.Location = new System.Drawing.Point(510, 24);
            this.SoundButton.Name = "SoundButton";
            this.SoundButton.Size = new System.Drawing.Size(42, 33);
            this.SoundButton.TabIndex = 17;
            this.SoundButton.UseVisualStyleBackColor = true;
            this.SoundButton.Click += new System.EventHandler(this.SoundButton_Click);
            // 
            // ConfirmInspectionButton
            // 
            this.ConfirmInspectionButton.Location = new System.Drawing.Point(510, 146);
            this.ConfirmInspectionButton.Name = "ConfirmInspectionButton";
            this.ConfirmInspectionButton.Size = new System.Drawing.Size(72, 20);
            this.ConfirmInspectionButton.TabIndex = 16;
            this.ConfirmInspectionButton.Text = "Confirm";
            this.ConfirmInspectionButton.UseVisualStyleBackColor = true;
            this.ConfirmInspectionButton.Click += new System.EventHandler(this.ConfirmInspectionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(431, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "Inspection Time (s)";
            // 
            // InspectionTimeLabel
            // 
            this.InspectionTimeLabel.Location = new System.Drawing.Point(435, 146);
            this.InspectionTimeLabel.Name = "InspectionTimeLabel";
            this.InspectionTimeLabel.Size = new System.Drawing.Size(70, 20);
            this.InspectionTimeLabel.TabIndex = 14;
            this.InspectionTimeLabel.TabStop = false;
            this.InspectionTimeLabel.Text = "15";
            // 
            // InfoLabel
            // 
            this.InfoLabel.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InfoLabel.ForeColor = System.Drawing.Color.White;
            this.InfoLabel.Location = new System.Drawing.Point(175, 101);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(254, 39);
            this.InfoLabel.TabIndex = 13;
            this.InfoLabel.Text = "Hold space to begin inspection";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetButton
            // 
            this.resetButton.ForeColor = System.Drawing.Color.White;
            this.resetButton.Location = new System.Drawing.Point(21, 54);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 0;
            this.resetButton.Text = "reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Visible = false;
            // 
            // StartTimerButton
            // 
            this.StartTimerButton.Location = new System.Drawing.Point(259, 154);
            this.StartTimerButton.Name = "StartTimerButton";
            this.StartTimerButton.Size = new System.Drawing.Size(75, 23);
            this.StartTimerButton.TabIndex = 12;
            this.StartTimerButton.Text = "Start Timer";
            this.StartTimerButton.UseVisualStyleBackColor = true;
            this.StartTimerButton.Click += new System.EventHandler(this.StartTimerButton_Click_1);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(596, 513);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(612, 552);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Speedcubing Timer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DashboardForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DashboardForm_KeyUp);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelTest;
        private System.Windows.Forms.Timer mainWinformsTimer;
        private System.Windows.Forms.Label ClockLabel;
        private System.Windows.Forms.Label DNFLabel;
        private System.Windows.Forms.Label CubeTypeLabel;
        private System.Windows.Forms.Label ScrambleLabel;
        private NonSelectableButton resetButton;
        private System.Windows.Forms.ListBox StatisticsListBox;
        private NonSelectableComboBox CubeTypeComboBox;
        private System.Windows.Forms.Label InspectionLabel;
        private NonSelectableButton StartTimerButton;
        private System.Windows.Forms.Label BestLabel;
        private System.Windows.Forms.Label Bo12Label;
        private System.Windows.Forms.Label Bo5Label;
        private System.Windows.Forms.Label AverageLabel;
        private System.Windows.Forms.Label WorstLabel;
        private System.Windows.Forms.Label Bo12ValueLabel;
        private System.Windows.Forms.Label Bo5ValueLabel;
        private System.Windows.Forms.Label AverageValueLabel;
        private System.Windows.Forms.Label WorstValueLabel;
        private System.Windows.Forms.Label BestValueLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InspectionTimeLabel;
        private NonSelectableButton ConfirmInspectionButton;
        private NonSelectableButton SoundButton;
        private NonSelectableButton SetDNFButton;
        private NonSelectableButton DeleteSelectedButton;
        private NonSelectableButton DeleteAllButton;
        private NonSelectableButton DeleteLastButton;
    }
}

