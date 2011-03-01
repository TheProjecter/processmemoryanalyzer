using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.ConfigManager;
using PMA.Utils.Logger;
using PMA.Utils.smtp;
using PMA.SystemAnalyzer;
using PMA.ProcessMemoryAnalyzer;
using System.Diagnostics;
using System.IO;


namespace PMA.SystemAnalyzer
{
    public class PMAMailController
    {

        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;

        //Event Type : ClientInstance : User
        private string _subject = "PMA System Alerts : {0} : {1} : " + Environment.MachineName + " : For {2} User  " +
                " at " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();


        private string _message;
        private string _user;
        private string _alertType;
        private List<string> _emailSubscribers;
        private AlertType alertType;
        private bool _isGeneratingLog;

        public PMAMailController(string message, AlertType alertType, string user)
        {
            this.alertType = alertType;
            _emailSubscribers = new List<string>();
            switch (alertType)
            {
                case AlertType.EVENT_ALERT:
                    _alertType = "Event";
                    _emailSubscribers = configManager.SystemAnalyzerInfo.ListAlertMailSubscription;
                    break;
                case AlertType.GENERAL_ALERT:
                    _alertType = "General";
                    _emailSubscribers = configManager.SystemAnalyzerInfo.ListAlertMailSubscription;
                    break;
                case AlertType.USER_ALERT :
                    _alertType = "PMA User Login";
                    _emailSubscribers.AddRange(configManager.PMAServerManagerInfo.EmailActionServicesSubsubscribers);
                    _emailSubscribers.AddRange(configManager.PMAServerManagerInfo.EmailSqlRemoteActivitySubscribers);
                    break;
                case AlertType.SQL_ALERT :
                    _alertType = "SQL Remote Action";
                    _emailSubscribers.AddRange(configManager.PMAServerManagerInfo.EmailSqlRemoteActivitySubscribers);
                    break;
                case AlertType.SERVICE_ALERT :
                    _alertType = "Remote Service Action";
                    _emailSubscribers.AddRange(configManager.PMAServerManagerInfo.EmailActionServicesSubsubscribers);
                    break;
                case AlertType.ACTION_ALERT:
                    _alertType = "Remote Command Action";
                    _emailSubscribers.AddRange(configManager.PMAServerManagerInfo.EmailActionServicesSubsubscribers);
                    break;
            }
            if (user == null || user == string.Empty)
            {
                user = "SYSTEM";
            }
            _user = user;
            _message = message;
        }
        
        
        public void SendMail()
        {
            configManager.Logger.Debug(EnumMethod.START);
            string subject = string.Format(_subject, _alertType,configManager.SystemAnalyzerInfo.ClientInstanceName, _user);
            SMTPTransport smtp = new SMTPTransport();
            try
            {
                smtp.SendAsynchronous = true;
                SaveLog();
                smtp.SmtpSend(configManager.SmtpInfo, configManager.SystemAnalyzerInfo.ListAlertMailSubscription, null, subject, GenerateMessageBody(), null);
            }
            catch (Exception ex)
            {
                configManager.Logger.Error(ex);
            }
            configManager.Logger.Debug(EnumMethod.END);
        }

        public void SaveLog()
        {
            configManager.Logger.Debug(EnumMethod.START);
            _isGeneratingLog = true;
            string fileName = DateTime.Now.ToShortDateString().Replace('/', '-') + "_" + DateTime.Now.ToLongTimeString().Replace(':', '-') + "_" + _alertType + "_" + _user + ".log";
            try
            {
                lock (new object())
                {
                    if (!File.Exists(configManager.GetFileNameForRemoteAction(fileName)))
                    {
                        File.WriteAllText(configManager.GetFileNameForRemoteAction(fileName), GenerateMessageBody());
                    }
                }
            }
            catch(Exception ex)
            {
                configManager.Logger.Error(ex);
            }
            finally
            {
                _isGeneratingLog = false;
                configManager.Logger.Debug(EnumMethod.END);
            }
        }


        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Generates the message body.
        /// </summary>
        /// <returns></returns>
        public string GenerateMessageBody()
        {
            configManager.Logger.Debug(EnumMethod.START);
            StringBuilder builder = new StringBuilder();
            string lineSeprator = string.Empty;
            bool isHTMLMessage = false;
            if (!_isGeneratingLog)
            {
                if (configManager.SmtpInfo.IsBodyHtml)
                {
                    isHTMLMessage = true;
                    lineSeprator = "<br/>";
                }
                else lineSeprator = "\r\n";
            }
            else
            {
                isHTMLMessage = false;
                lineSeprator = "\r\n";
            }

            if (!_isGeneratingLog)
            {
                builder.Append("Hi,");
                builder.Append(lineSeprator);
                builder.Append(lineSeprator);
                builder.Append(lineSeprator);
            }
            if (alertType == AlertType.EVENT_ALERT)
            {
                if (isHTMLMessage)
                {
                    builder.Append("<div style=\"COLOR:RED\">");
                }
                builder.Append("Event Alert Generated For machine :" + Environment.MachineName + " : " + configManager.SystemAnalyzerInfo.ClientInstanceName);
                builder.Append(lineSeprator + " Total RAM :" + PMAServiceProcessController.TotalPhysicalMemoryInKB);
                builder.Append(lineSeprator + " Available RAM :" + PMAServiceProcessController.TotalFreePhysicalMemoryInKB);
                builder.Append(lineSeprator + " CPU Usage : " + PMAServiceProcessController.CPUPercentageUsageAtMoment + "%");
                builder.Append(lineSeprator);
                builder.Append(_message);
            }
            else if (alertType == AlertType.GENERAL_ALERT)
            {
                if (isHTMLMessage)
                {
                    builder.Append("<div style=\"COLOR:RED\">");
                }
                builder.Append("Alert Generated For machine :" + Environment.MachineName + " : " + configManager.SystemAnalyzerInfo.ClientInstanceName);
                builder.Append(lineSeprator);
                if (isHTMLMessage)
                {
                    builder.Append(configManager.GetConsolidatedError("System Alert").Replace("\r\n", "<br/>"));
                }
                else builder.Append(configManager.GetConsolidatedError("System Alert"));
            }
            else if (alertType == AlertType.SQL_ALERT)
            {
                if (isHTMLMessage)
                {
                    builder.Append("<div style=\"COLOR:GREEN\">");
                }
                builder.Append("SQL Action On :" + configManager.PMAServerManagerInfo.DatabaseServer) ;
                builder.Append(lineSeprator);
                builder.Append("Query : " + _message);
            }
            else if (alertType == AlertType.SERVICE_ALERT)
            {
                if (isHTMLMessage)
                {
                    builder.Append("<div style=\"COLOR:GREEN\">");
                }
                builder.Append("Service Action On :" + configManager.PMAServerManagerInfo.DatabaseServer);
                builder.Append(lineSeprator);
                builder.Append("Services Effected ");
                builder.Append(lineSeprator);
                builder.Append(_message); 
            }
            else if (alertType == AlertType.ACTION_ALERT)
            {
                if (isHTMLMessage)
                {
                    builder.Append("<div style=\"COLOR:GREEN\">");
                }
                builder.Append("Command Action On : " + Environment.MachineName + ":" + configManager.SystemAnalyzerInfo.ClientInstanceName);
                builder.Append(lineSeprator);
                builder.Append("Actions Performed Are :");
                builder.Append(lineSeprator);
                builder.Append(_message);
            }
            else if (alertType == AlertType.USER_ALERT)
            {
                if (isHTMLMessage)
                {
                    builder.Append("<div style=\"COLOR:GREEN\">");
                }
                builder.Append("User :" + _user + " login on : "  + Environment.MachineName + ":" + configManager.SystemAnalyzerInfo.ClientInstanceName);
            }
            if (isHTMLMessage)
            {
                builder.Append("</div>");
            }
            if (!_isGeneratingLog)
            {
                builder.Append(lineSeprator);
                builder.Append(lineSeprator);
                builder.Append(lineSeprator);
                builder.Append(lineSeprator);
                if (isHTMLMessage)
                {
                    builder.Append("<h4>");
                }
                builder.Append("Thanks,");
                builder.Append(lineSeprator);
                builder.Append("Cosmos Team.");
                if (isHTMLMessage)
                {
                    builder.Append("</h4>");
                }
            }
            configManager.Logger.Debug(EnumMethod.END);
            return builder.ToString();
        }
     

    }

    public enum AlertType
    {
        EVENT_ALERT,
        GENERAL_ALERT,
        USER_ALERT,
        SQL_ALERT,
        SERVICE_ALERT,
        ACTION_ALERT

    }
}
