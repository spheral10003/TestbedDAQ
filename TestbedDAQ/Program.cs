using KwonLib;
using KwonLib.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestbedDAQ.Forms;

namespace TestbedDAQ
{
    internal static class Program
    {
        static public LogManager ErrLog = new LogManager("Err_", null);

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {

            bool createdNew;
            Mutex mutex = new Mutex(true, "TestbedDAQ", out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("프로그램이 이미 실행되고 있습니다.");
                return;
            }

            string[] strArg = Environment.GetCommandLineArgs();

            if (strArg.Length > 1)
            {
                if (strArg[1].Equals("DEBUG"))
                {
                    DebugConsole.AllocConsole();
                    DebugMode.Enable = true;
                }
            }

            // 처리되지 않은 예외를 처리합니다.
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
            //Application.Run(new frmCombo());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Console.WriteLine("Application_ThreadException " + e.Exception.Message);
            MessageBox.Show("Application_ThreadException " + e.Exception.Message);
            Application.Exit(new System.ComponentModel.CancelEventArgs(false));
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("CurrentDomain_UnhandledException " + ((Exception)e.ExceptionObject).Message);
            MessageBox.Show("CurrentDomain_UnhandledException " + ((Exception)e.ExceptionObject).Message + " Is Terminating: " + e.IsTerminating.ToString());

        }
    }
}
