using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration;
using System.Timers;
using PMA.SystemAnalyzer;

namespace PMA.PMAService
{
    public partial class PMAAlertService : ServiceBase
    {

        Timer mTimer = null;

        PMAFlowController flowController = null;

        private static bool is_lock = false;
        
        public PMAAlertService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            int logInterval = int.Parse(ConfigurationSettings.AppSettings["interval"]);
            mTimer = new System.Timers.Timer(logInterval);
            mTimer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer_Elapsed(null, null);
            mTimer.Start();
        }

        protected override void OnStop()
        {
            if (flowController != null)
            {
                //flowController.;
            }
            is_lock = false;
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!is_lock)
            {
                try
                {
                    is_lock = true;
                    if (flowController == null)
                    {
                        flowController = new PMAFlowController();
                    }
                    flowController.RunTask();
                }
                finally
                {
                    is_lock = false;
                }
            }

        }
    }
}
