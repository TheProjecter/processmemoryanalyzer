using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace PMASysAlertsUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] p = Process.GetProcessesByName("PMASysAlertsUI");
            if (p.Length > 1)
            {
                System.Threading.Thread.Sleep(3000);
                Environment.Exit(0);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PMASysAlertsUI());
        }
    }
}
