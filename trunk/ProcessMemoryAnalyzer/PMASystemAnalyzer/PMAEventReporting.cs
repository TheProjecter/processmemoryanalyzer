using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using PMA.Utils.smtp;
using PMA.Info;
using PMA.ProcessMemoryAnalyzer;
using PMA.Utils.Logger;
using System.Threading;
using PMA.ConfigManager;


namespace PMA.SystemAnalyzer
{
    public class PMAEventReporting
    {
        
        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;

        private List<EventLogEntry> listEntryLog;


        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Systems the event listener.
        /// </summary>
        public void SystemEventListener()
        {
            configManager.Logger.Debug(EnumMethod.START);
            EventLog eventSystemLog = new EventLog("System", ".");
            eventSystemLog.EntryWritten += new EntryWrittenEventHandler(SystemLogEntryWrittern_event);
            eventSystemLog.EnableRaisingEvents = true;

            EventLog eventApplicationLog = new EventLog("Application", ".");
            eventApplicationLog.EntryWritten += new EntryWrittenEventHandler(ApplicationLogEntryWrittern_event);
            eventApplicationLog.EnableRaisingEvents = true;

            EventLog eventSecurityLog = new EventLog("Security", ".");
            eventSecurityLog.EntryWritten += new EntryWrittenEventHandler(SecurityLogEntryWrittern_event);
            eventSecurityLog.EnableRaisingEvents = true;

            listEntryLog = new List<EventLogEntry>();

            while (configManager.SystemAnalyzerInfo.SetCrashReporting)
            {
                System.Threading.Thread.Sleep(10000);
                lock (listEntryLog)
                {
                    if (listEntryLog.Count > 0)
                    {
                        PostEventLogs();
                        listEntryLog.Clear();
                    }
                }
            }
            configManager.Logger.Debug(EnumMethod.END);
        }

        private void PostEventLogs()
        {
            configManager.Logger.Debug(EnumMethod.START);
            SendMail();
            configManager.Logger.Debug(EnumMethod.END);
        }

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sends the mail.
        /// </summary>
        private void SendMail()
        {
            configManager.Logger.Debug(EnumMethod.START);
            //string subject = "PMA System Alerts : Events : " + configManager.SystemAnalyzerInfo.ClientInstanceName + " : " + Environment.MachineName + " : " +
            //    " at " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            //SMTPTransport smtp = new SMTPTransport();
            //try
            //{
            //    smtp.SendAsynchronous = true;
            //    smtp.SmtpSend(configManager.SmtpInfo, configManager.SystemAnalyzerInfo.ListAlertMailSubscription, null, subject, GenerateMessageBody(), null);
            //}
            //catch(Exception ex)
            //{
            //    configManager.Logger.Error(ex);
            //}
            StringBuilder messageBuilder = new StringBuilder();
            foreach (EventLogEntry logEntry in listEntryLog)
            {
                messageBuilder.Append("r\n" + logEntry.Category);
                messageBuilder.Append("\r\n"+logEntry.EntryType.ToString() + " : " + logEntry.MachineName + " : " + logEntry.TimeGenerated.ToShortDateString() + "  " + logEntry.TimeGenerated.ToShortTimeString() + "\r\n" + logEntry.Message);
            }
            
            PMAMailController mailController = new PMAMailController(messageBuilder.ToString(), AlertType.EVENT_ALERT, null);
            mailController.SendMail();
            configManager.Logger.Debug(EnumMethod.END);
        }


        ////-------------------------------------------------------------------------------------------------
        ///// <summary>
        ///// Generates the message body.
        ///// </summary>
        ///// <returns></returns>
        //private string GenerateMessageBody()
        //{
        //    configManager.Logger.Debug(EnumMethod.START);
        //    StringBuilder builder = new StringBuilder();
        //    builder.Append("Hi,");
        //    builder.Append("\r\n");
        //    builder.Append("\r\n");
        //    builder.Append("\r\n");
        //    builder.Append("Event Alert Generated For machine :" + Environment.MachineName + " : " + configManager.SystemAnalyzerInfo.ClientInstanceName);
        //    builder.Append("\r\n Total RAM :" + PMAServiceProcessController.TotalPhysicalMemoryInKB);
        //    builder.Append("\r\n Available RAM :" + PMAServiceProcessController.TotalFreePhysicalMemoryInKB);
        //    builder.Append("\r\n CPU Usage : " + PMAServiceProcessController.CPUPercentageUsageAtMoment + "%");
        //    builder.Append("\r\n");
        //    foreach (EventLogEntry logEntry in listEntryLog)
        //    {
        //        builder.Append("r\n" + logEntry.Category);
        //        builder.Append("\r\n"+logEntry.EntryType.ToString() + " : " + logEntry.MachineName + " : " + logEntry.TimeGenerated.ToShortDateString() + "  " + logEntry.TimeGenerated.ToShortTimeString() + "\r\n" + logEntry.Message);
        //    }
        //    builder.Append("\r\n");
        //    builder.Append("\r\n");
        //    builder.Append("\r\n");
        //    builder.Append("\r\n");
        //    builder.Append("Thanks,");
        //    builder.Append("\r\n");
        //    builder.Append("Cosmos Team.");
        //    configManager.Logger.Debug(EnumMethod.END);
        //    return builder.ToString();
        //}



        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the event event of the SystemLogEntryWrittern control.
        /// </summary>
        /// <param name="args">The source of the event.</param>
        /// <param name="e">The <see cref="System.Diagnostics.EntryWrittenEventArgs"/> instance containing the event data.</param>
        public void SystemLogEntryWrittern_event(object args, EntryWrittenEventArgs e)
        {
            EventLogEntry logEntry = e.Entry;
            AddEvent("System", logEntry);
            
        }

        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the event event of the ApplicationLogEntryWrittern control.
        /// </summary>
        /// <param name="args">The source of the event.</param>
        /// <param name="e">The <see cref="System.Diagnostics.EntryWrittenEventArgs"/> instance containing the event data.</param>
        public void ApplicationLogEntryWrittern_event(object args, EntryWrittenEventArgs e)
        {
            EventLogEntry logEntry = e.Entry;
            AddEvent("Application", logEntry);
        }

        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the event event of the SecurityLogEntryWrittern control.
        /// </summary>
        /// <param name="args">The source of the event.</param>
        /// <param name="e">The <see cref="System.Diagnostics.EntryWrittenEventArgs"/> instance containing the event data.</param>
        public void SecurityLogEntryWrittern_event(object args, EntryWrittenEventArgs e)
        {
            EventLogEntry logEntry = e.Entry;
            AddEvent("Security", logEntry);
        }


        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Determines whether [is watcher set] [the specified log name].
        /// </summary>
        /// <param name="logName">Name of the log.</param>
        /// <param name="logEntry">The log entry.</param>
        /// <returns>
        /// 	<c>true</c> if [is watcher set] [the specified log name]; otherwise, <c>false</c>.
        /// </returns>
        private bool AddEvent(string logName, EventLogEntry logEntry)
        {
            int count = 0;

            count = (from crashInfo in configManager.SystemAnalyzerInfo.ListCrashReportInfo
                     where crashInfo.LogName == logName
                     select crashInfo).ToList<PMAEventReportInfo>().Count;

            if (count > 0)
            {
                count = (from crashInfo in configManager.SystemAnalyzerInfo.ListCrashReportInfo
                         where
                         crashInfo.EventType == logEntry.EntryType.ToString()
                         &&
                         (crashInfo.EventSource == logEntry.Source || crashInfo.EventSource == "*")
                         &&
                         (logEntry.Message.Contains(crashInfo.EventMessage) || crashInfo.EventMessage == "*")
                         select crashInfo).ToList<PMAEventReportInfo>().Count;
            }
            if (count > 0)
            {
                configManager.Logger.Debug(EnumMethod.START);
                configManager.Logger.Message("Logname : " + logName + " : " + logEntry.EntryType + " : " + logEntry.Source + " : \r\n" + logEntry.Message);
                listEntryLog.Add(logEntry);
                configManager.Logger.Debug(EnumMethod.END);
                return true;
            }
            else return false;
        }
         
        
    }
}
