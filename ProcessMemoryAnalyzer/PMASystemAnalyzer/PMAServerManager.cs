using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Info;
using PMA.ConfigManager;
using System.Diagnostics;

namespace PMA.SystemAnalyzer
{
    public class PMAServerManager
    {

        private const string PRIVILEGE_SQL = "SQL_PRIVILEDGE";
        private const string PRIVILEGE_ACTION = "ACTION_PRIVILEDGE";
        private const string PRIVILEGE_SERVICE = "SERVICE_PRIVILEDGE";
       
        private static PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;

        private static PMAUserManager userManager = PMAUserManager.GetUserManagerInstance;

        public static List<string> GetAvailableServicesForSession(string sessionID)
        {
            if (VerifySessionPrivileges(sessionID, PRIVILEGE_SERVICE))
            {
                return configManager.PMAServerManagerInfo.ListServices;
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
                return null;
            }
            else return null;

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

        }
        
        

    }
}
