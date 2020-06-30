namespace SpcTimer
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
            this.components = new System.ComponentModel.Container();
            this.LabelTest = new System.Windows.Forms.Label();
            this.mainWinformsTimer = new System.Windows.Forms.Timer(this.components);
            this.ClockLabel = new System.Windows.Forms.Label();
            this.DNFLabel = new System.Windows.Forms.Label();
            this.CubeTypeLabel = new System.Windows.Forms.Label();
            this.ScrambleLabel = new System.Windows.Forms.Label();
            this.StatisticsListBox = new System.Windows.Forms.ListBox();
            this.resetButton = new SpcTimer.NonSelectableButton();
            this.SuspendLayout();
            // 
            // LabelTest
            // 
            this.LabelTest.AutoSize = true;
            this.LabelTest.ForeColor = System.Drawing.Color.White;
            this.LabelTest.Location = new System.Drawing.Point(109, 244);
            this.LabelTest.Name = "LabelTest";
            this.LabelTest.Size = new System.Drawing.Size(28, 13);
            this.LabelTest.TabIndex = 0;
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
            this.ClockLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClockLabel.Font = new System.Drawing.Font("Ebrima", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ClockLabel.ForeColor = System.Drawing.Color.White;
            this.ClockLabel.Location = new System.Drawing.Point(101, 53);
            this.ClockLabel.Name = "ClockLabel";
            this.ClockLabel.Size = new System.Drawing.Size(322, 47);
            this.ClockLabel.TabIndex = 2;
            this.ClockLabel.Text = "Clock";
            this.ClockLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DNFLabel
            // 
            this.DNFLabel.AutoSize = true;
            this.DNFLabel.ForeColor = System.Drawing.Color.White;
            this.DNFLabel.Location = new System.Drawing.Point(106, 174);
            this.DNFLabel.Name = "DNFLabel";
            this.DNFLabel.Size = new System.Drawing.Size(29, 13);
            this.DNFLabel.TabIndex = 3;
            this.DNFLabel.Text = "DNF";
            // 
            // CubeTypeLabel
            // 
            this.CubeTypeLabel.AutoSize = true;
            this.CubeTypeLabel.ForeColor = System.Drawing.Color.White;
            this.CubeTypeLabel.Location = new System.Drawing.Point(106, 215);
            this.CubeTypeLabel.Name = "CubeTypeLabel";
            this.CubeTypeLabel.Size = new System.Drawing.Size(59, 13);
            this.CubeTypeLabel.TabIndex = 4;
            this.CubeTypeLabel.Text = "Cube Type";
            // 
            // ScrambleLabel
            // 
            this.ScrambleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ScrambleLabel.ForeColor = System.Drawing.Color.White;
            this.ScrambleLabel.Location = new System.Drawing.Point(109, 117);
            this.ScrambleLabel.Name = "ScrambleLabel";
            this.ScrambleLabel.Size = new System.Drawing.Size(314, 13);
            this.ScrambleLabel.TabIndex = 5;
            this.ScrambleLabel.Text = "Scramble";
            this.ScrambleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatisticsListBox
            // 
            this.StatisticsListBox.FormattingEnabled = true;
            this.StatisticsListBox.Location = new System.Drawing.Point(12, 266);
            this.StatisticsListBox.Name = "StatisticsListBox";
            this.StatisticsListBox.Size = new System.Drawing.Size(190, 225);
            this.StatisticsListBox.TabIndex = 7;
            this.StatisticsListBox.TabStop = false;
            // 
            // resetButton
            // 
            this.resetButton.ForeColor = System.Drawing.Color.White;
            this.resetButton.Location = new System.Drawing.Point(317, 164);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 6;
            this.resetButton.Text = "reset";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(523, 503);
            this.Controls.Add(this.StatisticsListBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.ScrambleLabel);
            this.Controls.Add(this.CubeTypeLabel);
            this.Controls.Add(this.DNFLabel);
            this.Controls.Add(this.ClockLabel);
            this.Controls.Add(this.LabelTest);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Speedcubing Timer";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
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
    }
}

