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
            this.LabelTest = new System.Windows.Forms.Label();
            this.mainWinformsTimer = new System.Windows.Forms.Timer(this.components);
            this.ClockLabel = new System.Windows.Forms.Label();
            this.DNFLabel = new System.Windows.Forms.Label();
            this.CubeTypeLabel = new System.Windows.Forms.Label();
            this.ScrambleLabel = new System.Windows.Forms.Label();
            this.StatisticsListBox = new System.Windows.Forms.ListBox();
            this.InspectionLabel = new System.Windows.Forms.Label();
            this.CubeTypeComboBox = new SpcTimer.NonSelectableComboBox();
            this.resetButton = new SpcTimer.NonSelectableButton();
            this.StartTimerButton = new SpcTimer.NonSelectableButton();
            this.SuspendLayout();
            // 
            // LabelTest
            // 
            this.LabelTest.AutoSize = true;
            this.LabelTest.ForeColor = System.Drawing.Color.White;
            this.LabelTest.Location = new System.Drawing.Point(107, 244);
            this.LabelTest.Name = "LabelTest";
            this.LabelTest.Size = new System.Drawing.Size(28, 13);
            this.LabelTest.TabIndex = 2;
            this.LabelTest.Text = "Test";
            // 
            // mainWinformsTimer
            // 
            this.mainWinformsTimer.Enabled = true;
            this.mainWinformsTimer.Interval = 10;
            this.mainWinformsTimer.Tick += new System.EventHandler(this.mainWinformsTimer_Tick);
            // 
            // ClockLabel
            // 
            this.ClockLabel.BackColor = System.Drawing.Color.Transparent;
            this.ClockLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ClockLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClockLabel.Font = new System.Drawing.Font("Ebrima", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ClockLabel.ForeColor = System.Drawing.Color.White;
            this.ClockLabel.Location = new System.Drawing.Point(101, 53);
            this.ClockLabel.Name = "ClockLabel";
            this.ClockLabel.Size = new System.Drawing.Size(322, 47);
            this.ClockLabel.TabIndex = 0;
            this.ClockLabel.Text = "Clock";
            this.ClockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DNFLabel
            // 
            this.DNFLabel.AutoSize = true;
            this.DNFLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.DNFLabel.ForeColor = System.Drawing.Color.White;
            this.DNFLabel.Location = new System.Drawing.Point(429, 53);
            this.DNFLabel.Name = "DNFLabel";
            this.DNFLabel.Size = new System.Drawing.Size(44, 20);
            this.DNFLabel.TabIndex = 3;
            this.DNFLabel.Text = "DNF";
            // 
            // CubeTypeLabel
            // 
            this.CubeTypeLabel.AutoSize = true;
            this.CubeTypeLabel.ForeColor = System.Drawing.Color.White;
            this.CubeTypeLabel.Location = new System.Drawing.Point(13, 244);
            this.CubeTypeLabel.Name = "CubeTypeLabel";
            this.CubeTypeLabel.Size = new System.Drawing.Size(59, 13);
            this.CubeTypeLabel.TabIndex = 4;
            this.CubeTypeLabel.Text = "Cube Type";
            // 
            // ScrambleLabel
            // 
            this.ScrambleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ScrambleLabel.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ScrambleLabel.ForeColor = System.Drawing.Color.White;
            this.ScrambleLabel.Location = new System.Drawing.Point(12, 117);
            this.ScrambleLabel.Name = "ScrambleLabel";
            this.ScrambleLabel.Size = new System.Drawing.Size(511, 52);
            this.ScrambleLabel.TabIndex = 5;
            this.ScrambleLabel.Text = "Scramble";
            this.ScrambleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatisticsListBox
            // 
            this.StatisticsListBox.Enabled = false;
            this.StatisticsListBox.FormattingEnabled = true;
            this.StatisticsListBox.Location = new System.Drawing.Point(12, 266);
            this.StatisticsListBox.Name = "StatisticsListBox";
            this.StatisticsListBox.Size = new System.Drawing.Size(123, 225);
            this.StatisticsListBox.TabIndex = 7;
            this.StatisticsListBox.TabStop = false;
            // 
            // InspectionLabel
            // 
            this.InspectionLabel.AutoSize = true;
            this.InspectionLabel.BackColor = System.Drawing.Color.Transparent;
            this.InspectionLabel.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.InspectionLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.InspectionLabel.Location = new System.Drawing.Point(210, 13);
            this.InspectionLabel.Name = "InspectionLabel";
            this.InspectionLabel.Size = new System.Drawing.Size(105, 25);
            this.InspectionLabel.TabIndex = 10;
            this.InspectionLabel.Text = "Inspection";
            this.InspectionLabel.Visible = false;
            // 
            // CubeTypeComboBox
            // 
            this.CubeTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CubeTypeComboBox.FormattingEnabled = true;
            this.CubeTypeComboBox.Items.AddRange(new object[] {
            "2x2 Cube",
            "3x3 Cube",
            "4x4 Cube"});
            this.CubeTypeComboBox.Location = new System.Drawing.Point(317, 291);
            this.CubeTypeComboBox.Name = "CubeTypeComboBox";
            this.CubeTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.CubeTypeComboBox.TabIndex = 9;
            this.CubeTypeComboBox.TabStop = false;
            this.CubeTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.CubeTypeComboBox_SelectionChangeCommitted);
            // 
            // resetButton
            // 
            this.resetButton.ForeColor = System.Drawing.Color.White;
            this.resetButton.Location = new System.Drawing.Point(317, 182);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 6;
            this.resetButton.TabStop = false;
            this.resetButton.Text = "reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Visible = false;
            // 
            // StartTimerButton
            // 
            this.StartTimerButton.Location = new System.Drawing.Point(224, 182);
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
            this.ClientSize = new System.Drawing.Size(523, 503);
            this.Controls.Add(this.StartTimerButton);
            this.Controls.Add(this.InspectionLabel);
            this.Controls.Add(this.CubeTypeComboBox);
            this.Controls.Add(this.StatisticsListBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.ScrambleLabel);
            this.Controls.Add(this.CubeTypeLabel);
            this.Controls.Add(this.DNFLabel);
            this.Controls.Add(this.ClockLabel);
            this.Controls.Add(this.LabelTest);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Speedcubing Timer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DashboardForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DashboardForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

