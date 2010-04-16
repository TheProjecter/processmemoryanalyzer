using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using PMA.ProcessMemoryAnalyzer;
using System.Configuration;

namespace ProcessMemoryAnalyzerService
{
    public partial class ProcessMemoryAnalyzerService : ServiceBase
    {

        Timer mTimer = null;

        private static bool is_lock = false;

        PMATaskHandler pmaTaskHandler;
        
        public ProcessMemoryAnalyzerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            int logInterval = int.Parse(ConfigurationSettings.AppSettings["loginterval"]);
            mTimer = new System.Timers.Timer(logInterval);
            mTimer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            mTimer.Start();
        }

        protected override void OnStop()
        {
        }


        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!is_lock)
            {
                try
                {
                    is_lock = true;
                    if (pmaTaskHandler == null)
                    {
                        pmaTaskHandler = new PMATaskHandler();
                    }
                    pmaTaskHandler.RunTask();
                }
                finally
                {
                    is_lock = false;
                }
            }

        }
    }
}
