using System;
using System.Windows.Forms;
using System.Threading;
using Calculator.Model;

namespace Calculator
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException +=
       new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ErrorLookup.ShowError(e.Exception.Message);
            
        }
    }
}
