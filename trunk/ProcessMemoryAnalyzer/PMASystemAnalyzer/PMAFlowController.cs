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
            if (configManager.SystemAnalyzerInfo.SetSessionStateSizeAlerts)
            {
                RunDBSizeWatch("ASPState", configManager.SystemAnalyzerInfo.SessionStateSizeAlertLevel);
            }

            if (configManager.SystemAnalyzerInfo.SetTempDBSizeAlerts)
            {
                RunDBSizeWatch("tempdb", configManager.SystemAnalyzerInfo.TempDBSizeAlertLevel);
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
            configManager.Logger.Debug(EnumMethod.END);
        }

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the service watcher.
        /// </summary>
        private void RunServiceWatcher()
        {
            configManager.Logger.Debug(EnumMethod.START);
            List<string> listMessage = new List<string>();
            if (PMASystemAnalyzer.GenerateServiceMemoryAlert(configManager.SystemAnalyzerInfo.ListServicesNames.ToList<string>(),
                configManager.SystemAnalyzerInfo.ProcessPhysicalMemoryAlertAt, out listMessage, configManager.SystemAnalyzerInfo.SetStartStoppedServicesAlerts))
            {
                configManager.ErrorMessage.AddRange(listMessage);
                if (!configManager.FlagInfo.FlagedServiceAlert)
                {
                    postAlert = true;
                }
                configManager.FlagInfo.FlagedServiceAlert = true;
            }
            else
            {
                configManager.FlagInfo.FlagedServiceAlert = false;
            }
            configManager.Logger.Debug(EnumMethod.END);
        }

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the physical memory watch.
        /// </summary>
        private void RunPhysicalMemoryWatch()
        {
            configManager.Logger.Debug(EnumMethod.START);
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

            configManager.Logger.Debug(EnumMethod.END);

        }

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the DB optimizer.
        /// </summary>
        private void RunDBOptimizer()
        {
            configManager.Logger.Debug(EnumMethod.START);
            PMAConfigManager cm = configManager;
            if (cm.SystemAnalyzerInfo.IsWebServer)
            {
                List<Process> proceessList = (from process in Process.GetProcesses()
                                            where process.ProcessName == "w3wp" || process.ProcessName == "w3wp*32"
                                             select process).ToList<Process>() ;

                if (proceessList.Count == 0)
                {
                    //Implement Later
                    //PMADatabaseController dbController = new PMADatabaseController(cm.SystemAnalyzerInfo.Database,
                    //cm.SystemAnalyzerInfo.DBUser, cm.SystemAnalyzerInfo.DBPassword);
                    //dbController.TruncateSessionStateDatabase();
                }
            }
            configManager.Logger.Debug(EnumMethod.END);
        }

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the DB size watch.
        /// </summary>
        /// <param name="dbName">Name of the db.</param>
        /// <param name="alertLevel">The alert level.</param>
        private void RunDBSizeWatch(string dbName,int alertLevel)
        {
            configManager.Logger.Debug(EnumMethod.START);
            PMADatabaseController dbController = new PMADatabaseController(configManager.SystemAnalyzerInfo.Database,
                    configManager.SystemAnalyzerInfo.DBUser, configManager.SystemAnalyzerInfo.DBPassword);
            if (dbController.GetDBSize(dbName) > alertLevel)
            {
                configManager.ErrorMessage.Add("Database Server : " + configManager.SystemAnalyzerInfo.Database + ": Database " + dbName + 
                    " is exceeding alert level of " + alertLevel + " MB");
                if (dbName == "ASPState")
                {
                    if (!configManager.FlagInfo.FlagedASPStateSizeAlert)
                    {
                        postAlert = true;
                    }
                    configManager.FlagInfo.FlagedASPStateSizeAlert = true;
                }
                else if (dbName == "tempdb")
                {
                    if (!configManager.FlagInfo.FlagedTempDBMemoryAlert)
                    {
                        postAlert = true;
                    }
                    configManager.FlagInfo.FlagedTempDBMemoryAlert = true;
                }
            }
            else
            {
                if(dbName == "ASPState")
                {
                    configManager.FlagInfo.FlagedASPStateSizeAlert = false;
                }
                else if(dbName == "tempdb")
                {
                    configManager.FlagInfo.FlagedTempDBMemoryAlert = false;
                }
            }
            configManager.Logger.Debug(EnumMethod.END);
        }

        


        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sends the mail.
        /// </summary>
        private void SendMail()
        {
            configManager.Logger.Debug(EnumMethod.START);
            string subject = "PMA System Alerts : General : " + configManager.SystemAnalyzerInfo.ClientInstanceName + " : " + systemName + " : " + " at " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() ;
            SMTPTransport smtp = new SMTPTransport();
            try
            {
                smtp.SendAsynchronous = false;
                smtp.SmtpSend(configManager.SmtpInfo, configManager.SystemAnalyzerInfo.ListAlertMailSubscription, null, subject, GenerateMessageBody(), null);
            }
            catch(Exception ex)
            {
                configManager.FlagInfo.FlagedDiscAlert = false;
                configManager.FlagInfo.FlagedPhysicalMemoryAlert = false;
                configManager.FlagInfo.FlagedServiceAlert = false;
                configManager.FlagInfo.FlagedASPStateSizeAlert = false;
                configManager.FlagInfo.FlagedTempDBMemoryAlert = false;
                configManager.Logger.Error(ex);
            }
            configManager.Logger.Debug(EnumMethod.END);
        }

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Posts the FTP message.
        /// </summary>
        private void PostFTPMessage()
        {
            configManager.Logger.Debug(EnumMethod.START);
            try
            {
                string tempFileName = configManager.PostDir + "\\PMA_ALERTS_" + systemName+ "_" + configManager.SystemAnalyzerInfo.ClientInstanceName + ".txt";
                File.WriteAllText(tempFileName, GenerateMessageBody());
                FTPTransport ftpTransport = new FTPTransport();
                List<string> filetoUpload = new List<string>();
                filetoUpload.Add(tempFileName);
                ftpTransport.FTPSend(configManager.FtpInfo, filetoUpload);
                filetoUpload = null;
                File.Delete(tempFileName);
            }
            catch(Exception ex)
            {
                // No Reattempt if FTP upload fail, otherwise it can bombart mails
                
                //configManager.FlagInfo.FlagedDiscAlert = false;
                //configManager.FlagInfo.FlagedPhysicalMemoryAlert = false;
                //configManager.FlagInfo.FlagedServiceAlert = false;
                //configManager.FlagInfo.FlagedASPStateSizeAlert = false;
                //configManager.FlagInfo.FlagedTempDBMemoryAlert = false;
                configManager.Logger.Error(ex);
            }
            configManager.Logger.Debug(EnumMethod.END);
        }

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Generates the message body.
        /// </summary>
        /// <returns></returns>
        private string GenerateMessageBody()
        {
            configManager.Logger.Debug(EnumMethod.START);
            StringBuilder builder = new StringBuilder();
            builder.Append("Hi,");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("Alert Generated For machine :" + systemName +" : " + configManager.SystemAnalyzerInfo.ClientInstanceName);
            builder.Append("\r\n");
            builder.Append(configManager.GetConsolidatedError("System Alert"));
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("Thanks,");
            builder.Append("\r\n");
            builder.Append("Cosmos Team.");
            configManager.Logger.Debug(EnumMethod.END);
            return builder.ToString();
        }
    }
}
