using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimerLibrary;

namespace SpcTimer
{
    public partial class DashboardForm : Form, IViewInterface
    {
        Controller controller;
        public DashboardForm()
        {
            InitializeComponent();
            controller = new Controller(this);
            controller.DirName = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            
            KeyPreview = true;
            controller.InspectionTime = 15;

            /*
            Scramble newScramble = new Scramble(new ThreeByThreeScramble());
            LabelTest.Text = newScramble.Representation;
            */

        }
        public void SetController(Controller controller)
        {
            this.controller = controller;
        }
        private void mainWinformsTimer_Tick(object sender, EventArgs e)
        {
            controller.Update();
        }
        #region Labels
        public string ClockTime
        {
            get { return ClockLabel.Text; }
            set { this.ClockLabel.Text = value; }
        }
        public string Scramble
        {
            get { return ScrambleLabel.Text; }
            set { this.ScrambleLabel.Text = value; }
        }
        public string DNF
        {
            get { return DNFLabel.Text; }
            set { this.DNFLabel.Text = value; }
        }
        public string CubeTypeLabelInter
        {
            get { return CubeTypeLabel.Text; }
            set { this.CubeTypeLabel.Text = value; }
        }
        public string BestValue
        {
            get { return BestValueLabel.Text; }
            set 
            {
                BestValueLabel.ForeColor = (value == "00:00:00:00") ? Color.Gray : Color.White;
                this.BestValueLabel.Text = value; 
            }
        }
        public string WorstValue
        {
            get { return WorstValueLabel.Text; }
            set 
            {
                WorstValueLabel.ForeColor = (value == "00:00:00:00") ? Color.Gray : Color.White;
                this.WorstValueLabel.Text = value; 
            }
        }
        public string AverageValue
        {
            get { return AverageValueLabel.Text; }
            set 
            {
                AverageValueLabel.ForeColor = (value == "00:00:00:00") ? Color.Gray : Color.White;
                this.AverageValueLabel.Text = value; 
            }
        }
        public string Bo5Value
        {
            get { return Bo5ValueLabel.Text; }
            set 
            {
                Bo5ValueLabel.ForeColor = (value == "00:00:00:00") ? Color.Gray : Color.White;
                this.Bo5ValueLabel.Text = value; 
            }
        }
        public string Bo12Value
        {
            get { return Bo12ValueLabel.Text; }
            set 
            {
                Bo12ValueLabel.ForeColor = (value == "00:00:00:00") ? Color.Gray : Color.White;
                this.Bo12ValueLabel.Text = value;
            }
        }
        #endregion
        #region Visual
        public void SetClockColor(Color color)
        {
            ClockLabel.ForeColor = color;
        }
        public void SetBackgroundColor(Color color)
        {
            DashboardForm.ActiveForm.BackColor = color;
        }
        public void TimerInteract()
        {
            controller.startStopTimer();
        }
        #endregion
        #region Statistics
        private string selectedItem = "";
        public void DeleteSelectedStatistics(string selectedItem)
        {
            if (StatisticsListBox.Items.Count == 0)
            {
                const string message = "No element to remove";
                const string caption = "Error";
                MessageBox.Show(message, caption);
                return;
            }
            string parsed = selectedItem.Split('[', ']')[1];
            controller.DeleteStatisticsById(int.Parse(parsed));
        }
        public void DeleteAllStatistics()
        {
            const string message = "Do you want to delete all solves (of all cube types)?";
            const string caption = "Confirmation";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            controller.DeleteAllStatistics();
            controller.UpdateStatistics();
            StatisticsListBox.Items.Clear();
        }
        public void DeleteLastStatistics()
        {
            if (StatisticsListBox.Items.Count == 0)
            {
                const string message = "No element to remove";
                const string caption = "Error";
                MessageBox.Show(message, caption);
                return;
            }
            const string message2 = "Do you want to delete last solve?";
            const string caption2 = "Confirmation";
            var result = MessageBox.Show(message2, caption2,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            controller.DeleteLast();
            controller.UpdateStatistics();
            StatisticsListBox.Items.RemoveAt(StatisticsListBox.Items.Count - 1);
        }
        public void AddStatistics(string item)
        {
            StatisticsListBox.Items.Add(item);
        }
        public void GoToLastStatistics()
        {
            StatisticsListBox.SelectedIndex = StatisticsListBox.Items.Count - 1;
        }
        public void ClearStatisticsBox()
        {
            StatisticsListBox.Items.Clear();
        }
        private void StatisticsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = StatisticsListBox.GetItemText(StatisticsListBox.SelectedItem);
        }
        #endregion
        #region Controls
        private void CubeTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (CubeTypeComboBox.SelectedItem.ToString().Trim())
            {
                case "2x2 Cube":
                    controller.ChangeCubeType(CubeType.TWO);
                    break;

                case "3x3 Cube":
                    controller.ChangeCubeType(CubeType.THREE);
                    break;

                case "4x4 Cube":
                    controller.ChangeCubeType(CubeType.FOUR);
                    break;

                default:
                    throw new InvalidOperationException("Unknown ComboBox option");
                    break;
            }
        }
        private void StartTimerButton_Click_1(object sender, EventArgs e)
        {
            controller.startStopTimer();
        }
        private void ConfirmInspectionButton_Click(object sender, EventArgs e)
        {
            int inspectionTimeValue = 0;
            int.TryParse(InspectionTimeLabel.Text, out inspectionTimeValue);
            controller.InspectionTime = inspectionTimeValue;
        }
        private void SoundButton_Click(object sender, EventArgs e)
        {
            controller.ChangePlaySounds();
        }
        private void SetDNFButton_Click(object sender, EventArgs e)
        {
            if (StatisticsListBox.Items.Count == 0)
            {
                const string message2 = "No solve to mark as diqualified";
                const string caption2 = "Error";
                MessageBox.Show(message2, caption2);
                return;
            }
            const string message = "Do you want to mark current solve as DNF";
            const string caption = "Confirmation";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            controller.SetDNF();
        }
        private void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            DeleteSelectedStatistics(selectedItem);
            ClearStatisticsBox();
            controller.UpdateStatistics();
        }
        private void DeleteLastButton_Click(object sender, EventArgs e)
        {
            DeleteLastStatistics();
            controller.UpdateStatistics();
        }
        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            DeleteAllStatistics();
            controller.UpdateStatistics();
        }
        #endregion
        #region KeyboardInput
        private bool keyPressed = false;
        private void DashboardForm_KeyUp(object sender, KeyEventArgs e)
        {
            keyPressed = false;
            if(controller.isInspecting() && e.KeyCode == Keys.Space )
            {
                InspectionLabel.Visible = false;
                controller.startStopTimer();
                InfoLabel.Text = "Hit space to stop timer";
            }
        }
        //TODO - experiment with InspectionTimeLabel.Enabled 
        //ref: https://stackoverflow.com/questions/1140250/how-to-remove-the-focus-from-a-textbox-in-winforms
        private void DashboardForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(keyPressed)
            {
                InspectionTimeLabel.Enabled = false;
                e.Handled = true;
            }
            else
            {
                InspectionTimeLabel.Enabled = true;
                keyPressed = true;
                if (e.KeyCode == Keys.Space)
                {
                    InspectionTimeLabel.Enabled = false;
                    if (controller.isWating())
                    {
                        controller.startStopTimer();
                        InspectionLabel.Visible = true;
                        InfoLabel.Text = "Release space to begin timer";
                    }

                    if (controller.isSolving())
                    {
                        controller.startStopTimer();
                        InfoLabel.Text = "Hold space to begin inspection";
                        InspectionTimeLabel.Enabled = true;
                    }
                }
                
            }
            
        }

        #endregion
    }
}
