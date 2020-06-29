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
        public string Hours
        {
            get { return HoursLabel.Text; }
            set { this.HoursLabel.Text = value; }
        }
        private void mainWinformsTimer_Tick(object sender, EventArgs e)
        {
            controller.Update();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            TimerClass.Instance.Reset();
        }

    }
}
