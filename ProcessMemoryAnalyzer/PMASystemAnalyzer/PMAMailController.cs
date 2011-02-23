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

        public PMAMailController(string message, AlertType alertType, string user)
        {
            string messageBody;
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
                smtp.SmtpSend(configManager.SmtpInfo, configManager.SystemAnalyzerInfo.ListAlertMailSubscription, null, subject, GenerateMessageBody(), null);
            }
            catch (Exception ex)
            {
                configManager.Logger.Error(ex);
            }
            configManager.Logger.Debug(EnumMethod.END);
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
            builder.Append("Hi,");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("\r\n");
            if (alertType == AlertType.EVENT_ALERT)
            {
                builder.Append("Event Alert Generated For machine :" + Environment.MachineName + " : " + configManager.SystemAnalyzerInfo.ClientInstanceName);
                builder.Append("\r\n Total RAM :" + PMAServiceProcessController.TotalPhysicalMemoryInKB);
                builder.Append("\r\n Available RAM :" + PMAServiceProcessController.TotalFreePhysicalMemoryInKB);
                builder.Append("\r\n CPU Usage : " + PMAServiceProcessController.CPUPercentageUsageAtMoment + "%");
                builder.Append("\r\n");
                builder.Append(_message);
            }
            else if (alertType == AlertType.GENERAL_ALERT)
            {
                builder.Append("Alert Generated For machine :" + Environment.MachineName + " : " + configManager.SystemAnalyzerInfo.ClientInstanceName);
                builder.Append("\r\n");
                builder.Append(configManager.GetConsolidatedError("System Alert"));
            }
            else if (alertType == AlertType.SQL_ALERT)
            {
                builder.Append("SQL Action On :" + configManager.PMAServerManagerInfo.DatabaseServer) ;
                builder.Append("\r\n");
                builder.Append("Query : " + _message);
            }
            else if (alertType == AlertType.SERVICE_ALERT)
            {
                builder.Append("Service Action On :" + configManager.PMAServerManagerInfo.DatabaseServer);
                builder.Append("\r\n");
                builder.Append("Services Effected ");
                builder.Append("\r\n");
                builder.Append(_message); 
            }
            else if (alertType == AlertType.ACTION_ALERT)
            {
                builder.Append("Command Action On : " + Environment.MachineName + ":" + configManager.SystemAnalyzerInfo.ClientInstanceName);
                builder.Append("\r\n");
                builder.Append("Actions Performed Are :");
                builder.Append("\r\n");
                builder.Append(_message);
            }
            else if (alertType == AlertType.USER_ALERT)
            {
                builder.Append("User :" + _user + " login on : "  + Environment.MachineName + ":" + configManager.SystemAnalyzerInfo.ClientInstanceName);
            }
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
