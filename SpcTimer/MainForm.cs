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
            TimerClass.Instance.Reset();
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ' ')
            {
                if (this.ActiveControl is Button)
                {
                    var button = this.ActiveControl;
                    button.Enabled = false;
                    controller.startStopTimer();
                    Application.DoEvents();
                    button.Enabled = true;
                    button.Focus();
                }else
                {
                    controller.startStopTimer();
                }
            }
            
        }

        // TODO - change to up/release

    }
}
