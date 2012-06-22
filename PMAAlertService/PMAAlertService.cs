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
using PMA.ConfigManager;
using PMA.ProcessMemoryAnalyzer;
using PMA.SystemAnalyzer;
using System.ServiceModel;
using PMA.CommunicationAPI;
using System.IO;

namespace PMA.PMAService
{
    public partial class PMAAlertService : ServiceBase
    {

        Timer mTimer = null;

        PMAFlowController flowController = null;
        PMATaskHandler pmaTaskHandler;

        ServiceHost serviceHost = null;

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

            //Starting EventLoging Thread - Have to imporve this 
            System.Threading.Thread threadEventMonitor = new System.Threading.Thread(EvenLogTask);
            threadEventMonitor.IsBackground = true;
            threadEventMonitor.Name = "EventMonitor";
            threadEventMonitor.Start();

            System.Threading.Thread threadEventWCFHost = new System.Threading.Thread(WCFHost);
            threadEventWCFHost.IsBackground = true;
            threadEventWCFHost.Name = "WCFHost";
            threadEventWCFHost.Start();
            
            int logInterval = int.Parse(ConfigurationSettings.AppSettings["interval"]);
            mTimer = new System.Timers.Timer(logInterval);
            mTimer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            mTimer.Start();
        }

        //-----------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Host For WCF Service.
        /// </summary>
        private void WCFHost()
        {
            try
            {
                if (serviceHost != null)
                {
                    serviceHost.Close();
                }
                serviceHost = new ServiceHost(typeof(PMACommunicationAPI));
                serviceHost.Open();
            }
            catch(Exception ex)
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\ServiceError.log", ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Evens the log task.
        /// </summary>
        private void EvenLogTask()
        {
            PMAEventReporting crashReporting = new PMAEventReporting();
            crashReporting.SystemEventListener();
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
            if (pmaTaskHandler != null)
            {
                pmaTaskHandler.ReportingTask();
            }
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
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
                    if (flowController == null || pmaTaskHandler == null)
                    {
                        if (flowController == null)
                        {
                            flowController = new PMAFlowController();
                        }
                        if (pmaTaskHandler == null)
                        {
                            pmaTaskHandler = new PMATaskHandler();
                        }
                    }
                    flowController.RunTask();
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
