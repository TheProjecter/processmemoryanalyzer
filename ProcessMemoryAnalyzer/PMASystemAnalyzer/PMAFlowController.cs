using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using PMA.Utils.smtp;
using System.IO;
using PMA.Utils.ftp;
using PMA.ConfigManager;
using PMA.Utils.Logger;

namespace PMA.ConfigManager
{
    public class PMAFlowController
    {
        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        bool postAlert;
        private string systemName = Environment.MachineName;


        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the task.
        /// </summary>
        public void RunTask()
        {
            configManager.Logger.Debug(EnumMethod.START);
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
            configManager.Logger.Debug(EnumMethod.END);

        }

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the disc watch.
        /// </summary>
        private void RunDiscWatch()
        {
            configManager.Logger.Debug(EnumMethod.START);
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

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the service watcher.
        /// </summary>
        private void RunServiceWatcher()
        {
            configManager.Logger.Debug();
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

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the physical memory watch.
        /// </summary>
        private void RunPhysicalMemoryWatch()
        {
            configManager.Logger.Debug();
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

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the DB optimizer.
        /// </summary>
        private void RunDBOptimizer()
        {
            configManager.Logger.Debug();
            PMAConfigManager cm = configManager;
            if (cm.SystemAnalyzerInfo.IsWebServer)
            {
                List<Process> proceessList = (from process in Process.GetProcesses()
                                            where process.ProcessName == "w3wp" || process.ProcessName == "w3wp*32"
                                             select process).ToList<Process>() ;

                if (proceessList.Count == 0)
                {
                    PMADatabaseController dbController = new PMADatabaseController(cm.SystemAnalyzerInfo.Database,
                    cm.SystemAnalyzerInfo.DBUser, cm.SystemAnalyzerInfo.DBPassword);
                    dbController.TruncateSessionStateDatabase();
                }
            }
        }


        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sends the mail.
        /// </summary>
        private void SendMail()
        {
            configManager.Logger.Debug();
            string subject = "PMA System Alert for : " + systemName;
            SMTPTransport smtp = new SMTPTransport();
            try
            {
                smtp.SendAsynchronous = true;
                smtp.SmtpSend(configManager.SmtpInfo, configManager.SystemAnalyzerInfo.ListSendMailTo, null, subject, GenerateMessageBody(), null);
            }
            catch(Exception ex)
            {
                configManager.FlagInfo.FlagedDiscAlert = false;
                configManager.FlagInfo.FlagedPhysicalMemoryAlert = false;
                configManager.FlagInfo.FlagedServiceAlert = false;
            }
        }

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Posts the FTP message.
        /// </summary>
        private void PostFTPMessage()
        {
            configManager.Logger.Debug();
            try
            {
            string tempFileName = configManager.CurrentAppConfigDir + "\\PMA_ALERTS_" + systemName + ".txt";
            File.WriteAllText(tempFileName, GenerateMessageBody());
            FTPTransport ftpTransport = new FTPTransport();
            List<string> filetoUpload = new List<string>();
            filetoUpload.Add(tempFileName);
            ftpTransport.FTPSend(configManager.FtpInfo, filetoUpload);
            filetoUpload = null;
            File.Delete(tempFileName);
            }
            catch
            {
                configManager.FlagInfo.FlagedDiscAlert = false;
                configManager.FlagInfo.FlagedPhysicalMemoryAlert = false;
                configManager.FlagInfo.FlagedServiceAlert = false;
            }
        }

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Generates the message body.
        /// </summary>
        /// <returns></returns>
        private string GenerateMessageBody()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Hi,");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("Alert Generated For machine :" + systemName);
            builder.Append("\r\n");
            builder.Append(configManager.GetConsolidatedError("System Alert"));
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("Thanks,");
            builder.Append("\r\n");
            builder.Append("Cosmos Team.");
            return builder.ToString();
        }
    }
}
