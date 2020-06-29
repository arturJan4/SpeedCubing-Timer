namespace SpcTimer
{
    partial class Form1
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
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelTest
            // 
            this.LabelTest.AutoSize = true;
            this.LabelTest.Location = new System.Drawing.Point(204, 165);
            this.LabelTest.Name = "LabelTest";
            this.LabelTest.Size = new System.Drawing.Size(35, 13);
            this.LabelTest.TabIndex = 0;
            this.LabelTest.Text = "label1";
            // 
            // mainWinformsTimer
            // 
            this.mainWinformsTimer.Enabled = true;
            this.mainWinformsTimer.Interval = 1;
            this.mainWinformsTimer.Tick += new System.EventHandler(this.mainWinformsTimer_Tick);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(302, 165);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 503);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.LabelTest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelTest;
        private System.Windows.Forms.Timer mainWinformsTimer;
        private System.Windows.Forms.Button resetButton;
    }
}

