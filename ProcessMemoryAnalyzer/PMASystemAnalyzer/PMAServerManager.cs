﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Info;
using PMA.ConfigManager;
using System.Diagnostics;
using System.ServiceProcess;
using System.Data;
using PMA.Utils.Logger;
using PMA.Utils.smtp;

namespace PMA.SystemAnalyzer
{
    public class PMAServerManager
    {

        private const string PRIVILEGE_SQL = "SQL_PRIVILEDGE";
        private const string PRIVILEGE_ACTION = "ACTION_PRIVILEDGE";
        private const string PRIVILEGE_SERVICE = "SERVICE_PRIVILEDGE";
       
        private static PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        private static Logger logger = configManager.Logger;

        private static PMAUserManager userManager = PMAUserManager.GetUserManagerInstance;
        

        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the available services for session.
        /// </summary>
        /// <param name="sessionID">The session ID.</param>
        /// <returns></returns>
        public static Dictionary<string,ServiceControllerStatus> GetAvailableServicesForSession(string sessionID)
        {
            logger.Debug(EnumMethod.START);
            Dictionary<string, ServiceControllerStatus> availableServices = new Dictionary<string, ServiceControllerStatus>();
            if (VerifySessionPrivileges(sessionID, PRIVILEGE_SERVICE))
            {
                ServiceController serviceControls = null;
                foreach(string service in configManager.PMAServerManagerInfo.ListServices)
                {
                    try
                    {
                        serviceControls = new ServiceController(service);
                        if (serviceControls != null)
                        {
                            availableServices.Add(service, serviceControls.Status);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    finally
                    {
                        logger.Debug(EnumMethod.END);
                    }
                }
                return availableServices;
            }
            else return null;
        }

        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the available actions for session.
        /// </summary>
        /// <param name="sessionID">The session ID.</param>
        /// <returns></returns>
        public static List<string> GetAvailableActionsForSession(string sessionID)
        {
            logger.Debug(EnumMethod.START);
            try
            {
                if (VerifySessionPrivileges(sessionID, PRIVILEGE_ACTION))
                {
                    return configManager.PMAServerManagerInfo.ListActions;
                }

                else return null;
            }
            finally
            {
                logger.Debug(EnumMethod.END); 
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Executes the actions.
        /// </summary>
        /// <param name="actions">The actions.</param>
        /// <param name="sessionID">The session ID.</param>
        /// <returns></returns>
        public static string ExecuteActions(List<string> actions, string sessionID)
        {
            logger.Debug(EnumMethod.START);
            StringBuilder actionMessages = new StringBuilder();
            if (VerifySessionPrivileges(sessionID, PRIVILEGE_ACTION))
            {
                foreach (string action in actions)
                {
                    if (configManager.PMAServerManagerInfo.ListActions.Contains(action))
                    {
                        actionMessages.AppendLine(action + " : " + ExecuteAction(action));
                    }
                    else return action + " Does not exist on PMA server action definetion";
                }
            }
            else
            {
                logger.Debug(EnumMethod.END);
                return null;
            }

            SendMail(actionMessages.ToString(), AlertType.ACTION_ALERT, sessionID);

            logger.Debug(EnumMethod.END);
            return actionMessages.ToString() ;
        }

        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        private static string ExecuteAction(string action)
        {
            logger.Debug(EnumMethod.START);
            string actionArg = string.Empty;
            string result = string.Empty;

            try
            {
                if (action != string.Empty)
                {
                    if (action.Split(' ').Length > 1)
                    {
                        actionArg = action.Substring(action.IndexOf(' '));
                        action = action.Split(' ')[0];
                    }
                }

                Process p = new Process();
                p.StartInfo.FileName = action;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.Arguments = actionArg;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;

                p.Start();
                while (!p.HasExited)
                {
                    result += p.StandardOutput.ReadToEnd();
                }

                if (p.ExitCode != 0)
                {
                    result += p.StandardError.ReadToEnd();
                }
                else
                {
                    result += p.StandardOutput.ReadToEnd();                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                result = ex.Message;
            }
            logger.Debug(EnumMethod.END);
            return result;
        }

        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Serviceses the actions.
        /// </summary>
        /// <param name="servicesActions">The services actions.</param>
        /// <param name="sessionID">The session ID.</param>
        /// <returns></returns>
        public static string ServicesActions(Dictionary<string,string> servicesActions, string sessionID)
        {
            logger.Debug(EnumMethod.START);
            StringBuilder serviceMessages = new StringBuilder();
            if (VerifySessionPrivileges(sessionID, PRIVILEGE_SERVICE))
            {
                foreach (string service in servicesActions.Keys)
                {
                    if (configManager.PMAServerManagerInfo.ListServices.Contains(service))
                    {
                        serviceMessages.AppendLine(service + " : " + ServiceAction(service, servicesActions[service]));
                    }
                    else serviceMessages.AppendLine(service + " Does not exist on PMA server service definetion");
                }
            }
            else
            {
                logger.Debug(EnumMethod.END);
                return null;
            }
            
            SendMail(serviceMessages.ToString(), AlertType.SERVICE_ALERT, sessionID);
            
            logger.Debug(EnumMethod.END);
            return serviceMessages.ToString();
        }

        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Services the action.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="serviceAction">The service action.</param>
        /// <returns></returns>
        private static string ServiceAction(string serviceName, string serviceAction)
        {
            logger.Debug(EnumMethod.START);
            string result = string.Empty;
            try
            {
                ServiceController service = new ServiceController(serviceName);
                if (serviceAction == "START")
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
                    result = "Service is started";
                }
                else if (serviceAction == "STOP")
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                    result = "Service is stoped";
                }
                else if (serviceAction == "RESTART")
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                    result = "Service is Stoped";
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
                    result = result + "Service is started again";
                }

                
            }
            catch (Exception ex)
            {
                logger.Error(ex) ;
                result = ex.Message;
            }
            logger.Debug(EnumMethod.END);
            return result;


        }

        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Excutes the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="database">The database.</param>
        /// <param name="sessionID">The session ID.</param>
        /// <returns></returns>
        public static DataSet ExcuteQuery(string query, string database,int numberOfRows, string sessionID)
        {
            logger.Debug(EnumMethod.START);
            PMADatabaseController databaseController = null;
            DataSet ds = null;
            try
            {
                databaseController = new PMADatabaseController(configManager.PMAServerManagerInfo.DatabaseServer, configManager.PMAServerManagerInfo.DatabaseUser, configManager.PMAServerManagerInfo.DatabaseUserPassword);
                if (VerifySessionPrivileges(sessionID, PRIVILEGE_SQL))
                {
                    ds = databaseController.ExecuteQuery(query, database, numberOfRows);
                    SendMail(query, AlertType.SQL_ALERT, sessionID);
                }
                return ds;
            }
            finally
            {
                logger.Debug(EnumMethod.END);
                if (databaseController != null)
                    databaseController.Dispose();
            }

        }

        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Excutes the non query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="database">The database.</param>
        /// <param name="sessionID">The session ID.</param>
        /// <returns></returns>
        public static string ExcuteNonQuery(string query, string database, string sessionID)
        {
            logger.Debug(EnumMethod.START);
            PMADatabaseController databaseController = null;
            string result = string.Empty ;
            try
            {
                databaseController = new PMADatabaseController(configManager.PMAServerManagerInfo.DatabaseServer, configManager.PMAServerManagerInfo.DatabaseUser, configManager.PMAServerManagerInfo.DatabaseUserPassword);
                if (VerifySessionPrivileges(sessionID, PRIVILEGE_SQL))
                {
                    result = databaseController.ExecuteNonQuery(query, database);
                    SendMail(query, AlertType.SQL_ALERT, sessionID);
                }
                return result;   
            }
            finally
            {
                if (databaseController != null)
                    databaseController.Dispose();
                logger.Debug(EnumMethod.END);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the database names.
        /// </summary>
        /// <param name="sessionID">The session ID.</param>
        /// <returns></returns>
        public static List<string> GetDatabaseNames(string sessionID)
        {
            logger.Debug(EnumMethod.START); 
            PMADatabaseController databaseController = null;

             try
             {
                 databaseController = new PMADatabaseController(configManager.PMAServerManagerInfo.DatabaseServer, configManager.PMAServerManagerInfo.DatabaseUser, configManager.PMAServerManagerInfo.DatabaseUserPassword);
                 if (VerifySessionPrivileges(sessionID, PRIVILEGE_SQL))
                 {
                     return databaseController.GetDatabaseNames();
                 }
                 else return null;
             }
             finally
             {
                 if (databaseController != null)
                     databaseController.Dispose();
                 logger.Debug(EnumMethod.END);
             }

        }

        public static string GetSQLServerName(string sessionID)
        {
            if (VerifySessionPrivileges(sessionID, PRIVILEGE_SQL))
            {
                return configManager.PMAServerManagerInfo.DatabaseServer + " on " + Environment.MachineName;
            }
            else return string.Empty;
        }


        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Verifies the session privileges.
        /// </summary>
        /// <param name="sessionID">The session ID.</param>
        /// <param name="priviledge">The priviledge.</param>
        /// <returns></returns>
        private static bool VerifySessionPrivileges(string sessionID, string priviledge)
        {
            logger.Debug(EnumMethod.START);
            PMAUserInfo userInfo = null;
            bool result = false;
            if((userInfo = userManager.GetUserInfo(sessionID))!= null)
            {
                switch (priviledge)
                {
                    case PRIVILEGE_ACTION:
                        result = userInfo.IsActionUser;
                        break;
                    case PRIVILEGE_SERVICE:
                        result = userInfo.IsServiceUser;
                        break;
                    case PRIVILEGE_SQL:
                        result = userInfo.IsSQLUser;
                        break;
                    default:
                        result = false;
                        break;
                }
            }
            logger.Debug(EnumMethod.END);
            return result;

        }

        private static void SendMail(string message,AlertType alertType, string sessionID)
        {
            PMAMailController mailController = new PMAMailController(message, AlertType.SERVICE_ALERT, userManager.GetUserInfo(sessionID).UserName);
            mailController.SendMail();
        }


        //-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sends the mail.
        /// </summary>
        //private void SendMail(string alertType, string alertMessage, string userName)
        //{
        //    configManager.Logger.Debug(EnumMethod.START);
        //    string subject = "PMA System Alerts : "+  alertType + ": " + configManager.SystemAnalyzerInfo.ClientInstanceName + " : " + Environment.MachineName + " : " + " at " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        //    SMTPTransport smtp = new SMTPTransport();
        //    try
        //    {
        //        smtp.SendAsynchronous = false;
        //        smtp.SmtpSend(configManager.SmtpInfo, configManager.SystemAnalyzerInfo.ListAlertMailSubscription, null, subject, GenerateMessageBody(alertMessage,userName), null);
        //    }
        //    catch (Exception ex)
        //    {
        //        configManager.Logger.Error(ex);
        //    }
        //    configManager.Logger.Debug(EnumMethod.END);
        //}

        ////-------------------------------------------------------------------------------------------------
        ///// <summary>
        ///// Generates the message body.
        ///// </summary>
        ///// <returns></returns>
        //private string GenerateMessageBody(string message,string forUser)
        //{
        //    configManager.Logger.Debug(EnumMethod.START);
        //    StringBuilder builder = new StringBuilder();
        //    builder.Append("Hi,");
        //    builder.Append("\r\n");
        //    builder.Append("\r\n");
        //    builder.Append("\r\n");
        //    builder.Append("Alert Generated For machine :" + Environment.MachineName + " : " + configManager.SystemAnalyzerInfo.ClientInstanceName);
        //    builder.Append("\r\n");
        //    builder.Append(message);
        //    builder.Append("\r\n");
        //    builder.Append("Alert Is Generated by : " + forUser);
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



       
        
        

    }
}