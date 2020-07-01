using System;
using System.Threading;
using System.Windows.Forms;

namespace SpcTimer
{
    internal static class Program
    {
        //TODO proper setter and getters and encapsulation
        //TODO more tests
        //TODO mock tests?
        //TODO optimization
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //TODO - workaround - for release purposes
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Initialize DB
            TimerLibrary.GlobalConfig.Initialize(false, true);

            Application.Run(new DashboardForm());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
        }
    }
}
