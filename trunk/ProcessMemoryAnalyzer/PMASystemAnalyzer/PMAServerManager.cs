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
                    actionMessages.AppendLine(action + " : " + ExecuteAction(action));
                }
            }
            else
            {
                logger.Debug(EnumMethod.END);
                return null;
            }
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
                    serviceMessages.AppendLine(service + " : " + ServiceAction(service, servicesActions[service]));
                }
            }
            else
            {
                logger.Debug(EnumMethod.END);
                return null;
            }
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
            
            try
            {
                databaseController = new PMADatabaseController(configManager.SystemAnalyzerInfo.Database, configManager.SystemAnalyzerInfo.DBUser, configManager.SystemAnalyzerInfo.DBPassword);
                if (VerifySessionPrivileges(sessionID, PRIVILEGE_SQL))
                {
                    return databaseController.ExecuteQuery(query, database, numberOfRows);
                }
                else return null;
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

            try
            {
                databaseController = new PMADatabaseController(configManager.SystemAnalyzerInfo.Database, configManager.SystemAnalyzerInfo.DBUser, configManager.SystemAnalyzerInfo.DBPassword);
                if (VerifySessionPrivileges(sessionID, PRIVILEGE_SQL))
                {
                    return databaseController.ExecuteNonQuery(query, database);
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
                 databaseController = new PMADatabaseController(configManager.SystemAnalyzerInfo.Database, configManager.SystemAnalyzerInfo.DBUser, configManager.SystemAnalyzerInfo.DBPassword);
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


       
        
        

    }
}
