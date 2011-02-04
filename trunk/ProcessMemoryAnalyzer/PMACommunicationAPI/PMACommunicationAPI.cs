using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Info;
using PMA.SystemAnalyzer;

namespace PMA.CommunicationAPI
{
    public class PMACommunicationAPI : IPMACommunicationContract
    {

        PMAUserManager userManager = PMAUserManager.GetUserManagerInstance;

        #region IPMACommunicationContract Members

        public System.Data.DataSet ExecuteQuery(string query, string sessionID)
        {
            throw new NotImplementedException();
        }

        public string ExecuteCommand(string command, string sessionID)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAvailableCommands(string sessionID)
        {
            throw new NotImplementedException();
        }

      
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

        public string ServiceAction(string serviceName, string action, string sessionID)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet ExcuteQuery(string query, string sessionID)
        {
            throw new NotImplementedException();
        }

        string IPMACommunicationContract.ExcuteNonQuery(string query, string sessionID)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
