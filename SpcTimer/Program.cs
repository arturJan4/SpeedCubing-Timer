using System;
using System.Threading;
using System.Windows.Forms;

namespace SpcTimer
{
    internal static class Program
    {
        //TODO - more tests
        //TODO - mock tests
        //TODO - optimization
        //TODO - graphical representation
        //TODO - plotting time
        //TODO - user-changes in UI
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
        /// <summary>
        /// Temporary workaround for annoying exception handling errors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            
        }
        /// <summary>
        /// Temporary workaround for annoying exception handling errors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
        }
    }
}
