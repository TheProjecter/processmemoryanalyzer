using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMA.SystemAnalyzer
{
    public class PMAFlowController
    {
        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;

        bool postAlert;


        /// <summary>
        /// Runs the task.
        /// </summary>
        public void RunTask()
        {
            configManager.ClearErrorMessage();
            postAlert = false;
            if (configManager.SystemAnalyzerInfo.SetDiscWatch)
            {
                RunDiscWatch();
            }
            if (configManager.SystemAnalyzerInfo.SetOptimizeDB && configManager.SystemAnalyzerInfo.IsWebServer)
            {
                RunDBOptimizer();
            }
            if (configManager.SystemAnalyzerInfo.SetPhysicalMemWatch)
            {
                RunPhysicalMemoryWatch();
            }
            if (configManager.SystemAnalyzerInfo.SetServiceWatcher)
            {
                RunServiceWatcher();
            }

            if (postAlert)
            {
                if (configManager.SystemAnalyzerInfo.SetSendMail)
                {
                    SendMail();
                }
                if (configManager.SystemAnalyzerInfo.SetPostFTP)
                {
                    PostFTPMessage();
                }

            }

        }

        /// <summary>
        /// Runs the disc watch.
        /// </summary>
        private void RunDiscWatch()
        {
            PMAConfigManager cm = configManager;
            List<string> listMessage = new List<string>();
            if (PMASystemAnalyzer.GenerateDriveSpaceAlert(cm.SystemAnalyzerInfo.ListDrivesToWatch.ToList<string>(),
                cm.SystemAnalyzerInfo.LowDiscAlertAt, out listMessage))
            {
                cm.ErrorMessage.AddRange(listMessage);
                if (!cm.FlagInfo.FlagedDiscAlert)
                {
                    postAlert = true;
                }
                cm.FlagInfo.FlagedDiscAlert = true;
            }
            else
            {
                cm.FlagInfo.FlagedDiscAlert = false;
            }
        }

        /// <summary>
        /// Runs the service watcher.
        /// </summary>
        private void RunServiceWatcher()
        {
            PMAConfigManager cm = configManager;
            List<string> listMessage = new List<string>();
            if (PMASystemAnalyzer.GenerateServiceMemoryAlert(cm.SystemAnalyzerInfo.ListServicesNames.ToList<string>(),
                cm.SystemAnalyzerInfo.ProcessPhysicalMemoryAlertAt, out listMessage, cm.SystemAnalyzerInfo.SetStartStoppedServicesAlerts))
            {
                cm.ErrorMessage.AddRange(listMessage);
                if (!cm.FlagInfo.FlagedServiceAlert)
                {
                    postAlert = true;
                }
                cm.FlagInfo.FlagedServiceAlert = true;
            }
            else
            {
                cm.FlagInfo.FlagedServiceAlert = false;
            }

        }

        /// <summary>
        /// Runs the physical memory watch.
        /// </summary>
        private void RunPhysicalMemoryWatch()
        {
            PMAConfigManager cm = configManager;
            string message = string.Empty;
            if (PMASystemAnalyzer.GeneratePhyMemAlert(cm.SystemAnalyzerInfo.SystemPhysicalMemoryAlertAt, out message))
            {
                cm.ErrorMessage.Add(message);
                if (!cm.FlagInfo.FlagedPhysicalMemoryAlert)
                {
                    postAlert = true;
                }
                cm.FlagInfo.FlagedPhysicalMemoryAlert = true;
            }
            else cm.FlagInfo.FlagedPhysicalMemoryAlert = false;

        }

        /// <summary>
        /// Runs the DB optimizer.
        /// </summary>
        private void RunDBOptimizer()
        {
            throw new NotImplementedException();
        }


        private void SendMail()
        {


        }

        private void PostFTPMessage()
        {

        }
        
        private string GenerateMailMessageBody()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Hi,");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("\r\n");
            //builder.Append("Please find attached Machine Process Report for " + PMAInfoObj.ClientName);
            builder.Append("\r\n");
            builder.Append("CELL FROMAT");
            builder.Append("\r\n");
            builder.Append("PhyMemory|VirtualMem|CPU Use|Thread|Active Recon Window for process in time line");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("Thanks,");
            builder.Append("\r\n");
            builder.Append("Cosmos Team.");
            return builder.ToString();
        }
    }
}
