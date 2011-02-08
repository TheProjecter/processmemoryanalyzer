using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Info;
using PMA.ConfigManager;
using System.Diagnostics;
using System.ServiceProcess;

namespace PMA.SystemAnalyzer
{
    public class PMAServerManager
    {

        private const string PRIVILEGE_SQL = "SQL_PRIVILEDGE";
        private const string PRIVILEGE_ACTION = "ACTION_PRIVILEDGE";
        private const string PRIVILEGE_SERVICE = "SERVICE_PRIVILEDGE";
       
        private static PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;

        private static PMAUserManager userManager = PMAUserManager.GetUserManagerInstance;

        public static Dictionary<string,ServiceControllerStatus> GetAvailableServicesForSession(string sessionID)
        {
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

                    }
                }
                return availableServices;
            }
            else return null;
        }

        public static List<string> GetAvailableActionsForSession(string sessionID)
        {
            if (VerifySessionPrivileges(sessionID,PRIVILEGE_ACTION))
            {
                return configManager.PMAServerManagerInfo.ListActions;
            }
            else return null;
        }

        public static Dictionary<string,string> ExecuteActions(List<string> actions, string sessionID)
        {
            Dictionary<string, string> actionMessages = new Dictionary<string, string>();
            if (VerifySessionPrivileges(sessionID, PRIVILEGE_ACTION))
            {
                foreach (string action in actions)
                {
                    actionMessages.Add(action, ExecuteAction(action));
                }
            }
            else return null;
            return actionMessages;
        }

        private static string ExecuteAction(string action)
        {
            string actionArg = string.Empty;
            string result = string.Empty;

            try
            {
                if (action != string.Empty)
                {
                    actionArg = action.Substring(action.IndexOf(' '));
                    action = action.Split(' ')[0];
                }

                Process p = new Process();
                p.StartInfo.FileName = action;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.Arguments = actionArg;

                p.Start();

                result = p.StandardOutput.ReadToEnd();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public static Dictionary<string, string> ServicesActions(Dictionary<string,string> servicesActions, string sessionID)
        {
            Dictionary<string, string> serviceMessages = new Dictionary<string, string>();
            if (VerifySessionPrivileges(sessionID, PRIVILEGE_SERVICE))
            {
                foreach (string service in servicesActions.Keys)
                {
                    serviceMessages.Add(service, ServiceAction(service, servicesActions[service]));
                }
            }
            else return null;
            return serviceMessages;
        }

        private static string ServiceAction(string serviceName, string serviceAction)
        {
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
                result = ex.Message;
            }

            return result;


        }

        

        private static bool VerifySessionPrivileges(string sessionID, string priviledge)
        {
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
            return result;

        }
        
        

    }
}
