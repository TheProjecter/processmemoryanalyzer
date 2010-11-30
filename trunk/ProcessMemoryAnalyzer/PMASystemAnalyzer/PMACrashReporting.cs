using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using PMA.Utils.smtp;
using PMA.Info;

namespace PMA.ConfigManager
{
    public class PMACrashReporting
    {
        
        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;

        private List<EventLogEntry> listEntryLog;


        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Systems the event listener.
        /// </summary>
        public void SystemEventListener()
        {
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
        }

        private void PostEventLogs()
        {
            SendMail();
        }

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sends the mail.
        /// </summary>
        private void SendMail()
        {
            configManager.Logger.Debug();
            string subject = "PMA Event Alert for : " + Environment.MachineName + " : " +
                configManager.SystemAnalyzerInfo.ClientInstanceName + " at " +
                DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            SMTPTransport smtp = new SMTPTransport();
            try
            {
                smtp.SendAsynchronous = true;
                smtp.SmtpSend(configManager.SmtpInfo, configManager.SystemAnalyzerInfo.ListSendMailTo, null, subject, GenerateMessageBody(), null);
            }
            catch(Exception ex)
            {
                configManager.Logger.Error(ex);
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
            builder.Append("Event Alert Generated For machine :" + Environment.MachineName + " : " + configManager.SystemAnalyzerInfo.ClientInstanceName);
            builder.Append("\r\n");
            foreach (EventLogEntry logEntry in listEntryLog)
            {
                builder.AppendLine(logEntry.EntryType.ToString() + " : " + logEntry.MachineName + " : " + logEntry.TimeGenerated.ToShortDateString() + "  " + logEntry.TimeGenerated.ToShortTimeString() + "\r\n" + logEntry.Message);
            }
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("Thanks,");
            builder.Append("\r\n");
            builder.Append("Cosmos Team.");
            return builder.ToString();
        }



        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the event event of the SystemLogEntryWrittern control.
        /// </summary>
        /// <param name="args">The source of the event.</param>
        /// <param name="e">The <see cref="System.Diagnostics.EntryWrittenEventArgs"/> instance containing the event data.</param>
        public void SystemLogEntryWrittern_event(object args, EntryWrittenEventArgs e)
        {
            EventLogEntry logEntry = e.Entry;
            if(IsWatcherSet("System", logEntry))
                listEntryLog.Add(logEntry); 
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
            if (IsWatcherSet("Application", logEntry))
                listEntryLog.Add(logEntry); 
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
            if (IsWatcherSet("Security", logEntry))
                listEntryLog.Add(logEntry); 
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
        private bool IsWatcherSet(string logName, EventLogEntry logEntry)
        {
            int count = (from crashInfo in configManager.SystemAnalyzerInfo.ListCrashReportInfo
                    where crashInfo.EventType == logEntry.EntryType.ToString() &&
                    crashInfo.EventSource == logEntry.Source &&
                    logEntry.Message.Contains(crashInfo.EventMessage)
                         select crashInfo).ToList<PMACrashReportInfo>().Count;

            if (count > 0)
                return true;
            else return false;
        }

    }
}
