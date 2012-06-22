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
        public string GetSessionID(string username, string passwordMD5)
        {
            return userManager.GetSessionID(username, passwordMD5);
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
        public System.Data.DataSet ExcuteQuery(string query,string database,int numberOfRecords, string sessionID)
        {
            return PMAServerManager.ExcuteQuery(query, database, numberOfRecords,sessionID);
        }

        public string ExcuteNonQuery(string query,string database, string sessionID)
        {
            return PMAServerManager.ExcuteNonQuery(query, database, sessionID);
        }


        public List<string> GetDatabasesNames(string sessionID)
        {
            return PMAServerManager.GetDatabaseNames(sessionID);
        }

        public string GetSQLServerName(string sessionID)
        {
            return PMAServerManager.GetSQLServerName(sessionID);
        }

        #endregion 

       
        #region TaskManager
        public List<PMAProcessInfo> GetAllProcessesInfo(string sessionID)
        {
            return PMAServerManager.GetAllProcessInformation(sessionID);
        }

        public PMAServerInfo GetServerInfo(string sessionID)
        {
            return PMAServerManager.GetServerInfo(sessionID);
        }

        public List<string> KillProcesses(List<int> listPID, string sessionID)
        {
            return PMAServerManager.KillProcess(listPID, sessionID);
        }
        #endregion

        

        public DateTime GetServerDateTime(string sessionID)
        {
            return DateTime.Now;
        }

        public bool SetServerDateTime(DateTime dateTime, string sessionID)
        {
            return PMAServerManager.SetServerDateTime(dateTime, sessionID);
        }

        #endregion
    }
}
