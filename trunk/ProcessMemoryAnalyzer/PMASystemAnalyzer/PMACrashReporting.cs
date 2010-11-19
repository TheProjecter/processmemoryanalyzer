using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using PMA.Utils.smtp;

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
                    PostEventLogs();
                }
            }
        }

        private void PostEventLogs()
        {
            throw new NotImplementedException();
        }

        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sends the mail.
        /// </summary>
        private void SendMail()
        {
            configManager.Logger.Debug();
            string subject = "PMA System Alert for : " + Environment.MachineName + " : " + configManager.SystemAnalyzerInfo.ClientInstanceName;
            SMTPTransport smtp = new SMTPTransport();
            try
            {
                smtp.SendAsynchronous = true;
                smtp.SmtpSend(configManager.SmtpInfo, configManager.SystemAnalyzerInfo.ListSendMailTo, null, subject, GenerateMessageBody(), null);
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
            builder.Append("Alert Generated For machine :" + Environment.MachineName + " : " + configManager.SystemAnalyzerInfo.ClientInstanceName);
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

        //---------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the event event of the SystemLogEntryWrittern control.
        /// </summary>
        /// <param name="args">The source of the event.</param>
        /// <param name="e">The <see cref="System.Diagnostics.EntryWrittenEventArgs"/> instance containing the event data.</param>
        public void SystemLogEntryWrittern_event(object args, EntryWrittenEventArgs e)
        {
            EventLogEntry logEntry = e.Entry;

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
        }




    }
}
