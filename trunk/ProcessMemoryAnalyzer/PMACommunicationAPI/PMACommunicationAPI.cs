using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Info;
using PMA.SystemAnalyzer;
using PMA.ConfigManager;
using System.ServiceProcess;


namespace PMA.CommunicationAPI
{
    public class PMACommunicationAPI : IPMACommunicationContract
    {

        PMAUserManager userManager = PMAUserManager.GetUserManagerInstance;

        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;

        #region IPMACommunicationContract Members

        public bool VerfiyConnection()
        {
            return true;
        }



        #region Actions
        public string ExecuteActions(List<string> actions, string sessionID)
        {
            return PMAServerManager.ExecuteActions(actions, sessionID);
        }

        public List<string> GetAvailableActions(string sessionID)
        {
            return PMAServerManager.GetAvailableActionsForSession(sessionID);
        }
        #endregion 


        #region Services
        public Dictionary<string,ServiceControllerStatus> GetAvailableServices(string sessionID)
        {
            return PMAServerManager.GetAvailableServicesForSession(sessionID);
        }

        public string ServiceActions(Dictionary<string, string> servicesActions, string sessionID)
        {
            return PMAServerManager.ServicesActions(servicesActions, sessionID);
        }
        #endregion 

        #region UserManagement
        public string GetSessionID(string username, string password)
        {
            return userManager.GetSessionID(username, password);
        }

        public PMAUserInfo GetUserInfo(string sessionID)
        {
            return userManager.GetUserInfo(sessionID);
        }

        public void LogoutSession(string sessionID)
        {
            userManager.LogoutSession(sessionID);
        }
        #endregion


        #region SQL
        public System.Data.DataSet ExcuteQuery(string query, string sessionID)
        {
            throw new NotImplementedException();
        }

        string IPMACommunicationContract.ExcuteNonQuery(string query, string sessionID)
        {
            throw new NotImplementedException();
        }

        #endregion 

        #endregion
      
    }
}
