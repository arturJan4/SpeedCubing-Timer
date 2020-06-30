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
        // TODO - refactor with events
        Controller controller;
        public DashboardForm()
        {
            InitializeComponent();
            controller = new Controller(this);
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
            set { this.BestValueLabel.Text = value; }
        }

        public string WorstValue
        {
            get { return WorstValueLabel.Text; }
            set { this.WorstValueLabel.Text = value; }
        }
        public string AverageValue
        {
            get { return AverageValueLabel.Text; }
            set { this.AverageValueLabel.Text = value; }
        }
        public string Bo5Value
        {
            get { return Bo5ValueLabel.Text; }
            set { this.Bo5ValueLabel.Text = value; }
        }
        public string Bo12Value
        {
            get { return Bo12ValueLabel.Text; }
            set { this.Bo12ValueLabel.Text = value; }
        }

        public void TimerInteract()
        {
            controller.startStopTimer();
        }

        private void mainWinformsTimer_Tick(object sender, EventArgs e)
        {
            controller.Update();       
        }

        // TODO - change to up/release
        /*
        private void DashboardForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                if (this.ActiveControl is Button)
                {
                    var button = this.ActiveControl;
                    button.Enabled = false;
                    controller.startStopTimer();
                    Application.DoEvents();
                    button.Enabled = true;
                    button.Focus();
                }
                else
                {
                    controller.startStopTimer();
                    Application.DoEvents();
                }
            }
           
        } 
        */

        public void SetClockColor(Color color)
        {
            ClockLabel.ForeColor = color;
        }

        public void SetBackgroundColor(Color color)
        {
            DashboardForm.ActiveForm.BackColor = color;
        }

        //TODO - statistics box takes over focus and space doesn't work
        public void DeleteSelectedStatistics()
        {
            // TODO check id - delete from DB
            StatisticsListBox.Items.Remove(StatisticsListBox.SelectedItem);
        }

        public void DeleteAllStatistics()
        {
            StatisticsListBox.Items.Clear();
        }

        public void DeleteLastStatistics()
        {
            if (StatisticsListBox.Items.Count == 0)
                throw new IndexOutOfRangeException("Can't delete with no elements");
            StatisticsListBox.Items.RemoveAt(StatisticsListBox.Items.Count - 1);
        }

        public void AddStatistics(string item)
        {
            StatisticsListBox.Items.Add(item);
        }


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

        private bool keyPressed = false;
        private void DashboardForm_KeyUp(object sender, KeyEventArgs e)
        {
            keyPressed = false;
            // at least half a second of inspection time
            if(controller.isInspecting() && e.KeyCode == Keys.Space && controller.GetTime().TotalMilliseconds > 500)
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

        private void StartTimerButton_Click_1(object sender, EventArgs e)
        {
            controller.startStopTimer();
        }

        private void ConfirmInspectionButton_Click(object sender, EventArgs e)
        {
            int inspectionTimeValue = 0;
            //TODO fail parse?
            int.TryParse(InspectionTimeLabel.Text, out inspectionTimeValue);
            controller.InspectionTime = inspectionTimeValue;
        }
    }
}
