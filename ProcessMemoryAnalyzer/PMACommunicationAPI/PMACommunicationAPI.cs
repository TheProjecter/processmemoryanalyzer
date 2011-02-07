using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Info;
using PMA.SystemAnalyzer;
using PMA.ConfigManager;


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
            throw new NotImplementedException();
        }

        public List<string> GetAvailableActions(string sessionID)
        {
            return PMAServerManager.GetAvailableActionsForSession(sessionID);
        }
        #endregion 


        #region Services
        public List<string> GetAvailableServices(string sessionID)
        {
            return PMAServerManager.GetAvailableServicesForSession(sessionID);
        }

        public string ServiceActions(Dictionary<string, EnumServiceAction> servicesActions, string sessionID)
        {
            throw new NotImplementedException();
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
        public System.Data.DataSet ExecuteQuery(string query, string sessionID)
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
