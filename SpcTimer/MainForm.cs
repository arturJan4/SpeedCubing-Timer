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
    public partial class MainForm : Form, IViewInterface
    {
        // TODO - refactor with events
        Controller controller;
        public MainForm()
        {
            InitializeComponent();
            controller = new Controller(this);
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

        public void TimerInteract()
        {
            controller.startStopTimer();
        }

        private void mainWinformsTimer_Tick(object sender, EventArgs e)
        {
            controller.Update();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            controller.startStopTimer();
        }

        // TODO - change to up/release
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
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
                }
            }

        }

        public void SetClockColor(Color color)
        {
            ClockLabel.ForeColor = color;
        }

        public void SetBackgroundColor(Color color)
        {
            MainForm.ActiveForm.BackColor = color;
        }

        private void resetButton_Click_1(object sender, EventArgs e)
        {

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
    }
}
