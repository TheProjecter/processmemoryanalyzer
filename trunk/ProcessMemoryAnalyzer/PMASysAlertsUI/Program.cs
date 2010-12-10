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
        static void Main(string[] args)
        {
            if (Environment.OSVersion.Version.Major > 5 && args.Length == 0)
            {
                Process uiLuncher = new Process();
                uiLuncher.StartInfo = new ProcessStartInfo(Environment.CurrentDirectory + "\\PMASysAlertsUI.exe", "userauth");
                uiLuncher.StartInfo.Verb = "runas";
                uiLuncher.Start();
                System.Threading.Thread.Sleep(3000);
                Environment.Exit(0);
            }
            else
            {
                LaunchUI();
            }

            if (Environment.OSVersion.Version.Major > 5 && (args.Length == 1 && args[0] == "userauth"))
            {
                LaunchUI();
            }
            
            
        }

        /// <summary>
        /// Launches the UI.
        /// </summary>
        static void LaunchUI()
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
