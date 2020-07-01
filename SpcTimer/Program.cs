using System;
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
        //TODO optimization
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize DB
            TimerLibrary.GlobalConfig.Initialize(false, true);

            Application.Run(new DashboardForm());
        }
    }
}
