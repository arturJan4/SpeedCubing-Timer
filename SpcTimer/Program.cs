using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpcTimer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        //TODO proper setter and getters and encapsulation
        //TODO more tests
        //TODO mock tests?
        //TODO scale form
        //TODO visualizer
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize DB
            TimerLibrary.GlobalConfig.Initialize(false, true);

            Application.Run(new MainForm());

        }
    }
}
