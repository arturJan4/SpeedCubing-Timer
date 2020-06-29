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
    public partial class Form1 : Form
    {
        Controller controller = new Controller();
        public Form1()
        {
            InitializeComponent();
            
            /*
            Scramble newScramble = new Scramble(new ThreeByThreeScramble());
            LabelTest.Text = newScramble.Representation;
            */
        }

        private void mainWinformsTimer_Tick(object sender, EventArgs e)
        {
            TimerClass.Instance.Tick();
            UpdateFields();
            controller.Update();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            TimerClass.Instance.Reset();
        }

        private void UpdateFields()
        {
            LabelTest.Text = controller.GetTime().ToString();
        }
    }
}
