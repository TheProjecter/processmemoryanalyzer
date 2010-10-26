using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Threading;


namespace PMA.PMAService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            
            base.Install(stateSaver);
            Action("i");

        }

        public override void Commit(System.Collections.IDictionary savedState)
        {
            base.Commit(savedState);
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            base.Uninstall(savedState);
            Action("u");
        }


        private void Action(string action)
        {
            Process ps = new Process();
            ps.StartInfo.FileName = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\InstallUtil.exe";
            ps.StartInfo.Arguments = "PMAAlertService.exe -i";
            ps.StartInfo.CreateNoWindow = false;
            if (action == "u")
            {
                ps.StartInfo.Arguments = "PMAAlertService.exe -u";
            }
            else if (action == "i")
            {
                ps.StartInfo.Arguments = "PMAAlertService.exe -i";
            }
            ps.Start();
            ps.WaitForExit();
        }
    }
}
