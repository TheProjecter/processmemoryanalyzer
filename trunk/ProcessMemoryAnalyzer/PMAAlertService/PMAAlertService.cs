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

        //-----------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="PMAAlertService"/> class.
        /// </summary>
        public PMAAlertService()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// When implemented in a derived class, executes when a Start command is sent to the service by the Service Control Manager (SCM) or when the operating system starts (for a service that starts automatically). Specifies actions to take when the service starts.
        /// </summary>
        /// <param name="args">Data passed by the start command.</param>
        protected override void OnStart(string[] args)
        {
            int logInterval = int.Parse(ConfigurationSettings.AppSettings["interval"]);
            mTimer = new System.Timers.Timer(logInterval);
            mTimer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer_Elapsed(null, null);
            mTimer.Start();
        }

        //-----------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service stops running.
        /// </summary>
        protected override void OnStop()
        {
            if (flowController != null)
            {
                //flowController.;
            }
            is_lock = false;
        }

        //-----------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the Elapsed event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
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
