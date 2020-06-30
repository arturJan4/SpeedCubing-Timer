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
            }
        }

        private void DashboardForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(keyPressed)
            {
                e.Handled = true;
            }
            else
            {
                keyPressed = true;
                if (e.KeyCode == Keys.Space)
                {
                    if(controller.isWating())
                    {
                        controller.startStopTimer();
                        InspectionLabel.Visible = true;
                    }

                    if (controller.isSolving())
                    {
                        controller.startStopTimer();
                    }
                }
                
            }

        }

        private void StartTimerButton_Click_1(object sender, EventArgs e)
        {
            controller.startStopTimer();
        }
    }
}
