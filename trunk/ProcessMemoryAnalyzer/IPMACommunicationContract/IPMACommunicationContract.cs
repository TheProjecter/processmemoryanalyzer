using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Data;
using PMA.Info;

namespace PMA.CommunicationAPI
{
    [ServiceContract]
    public interface IPMACommunicationContract
    {

        [OperationContract]
        DataSet ExecuteQuery(string query,string sessionID);

        [OperationContract]
        string ExecuteCommand(string command, string sessionID);

        [OperationContract]
        List<string> GetAvailableCommands(string sessionID);

        [OperationContract]
        string GetSessionID(string username, string password);

        [OperationContract]
        PMAUserInfo GetUserInfo(string sessionID);

        [OperationContract]
        void LogoutSession(string sessionID);

        [OperationContract]
        string ServiceAction(string serviceName, string action, string sessionID);

        [OperationContract]
        DataSet ExcuteQuery(string query, string sessionID);

        [OperationContract]
        string ExcuteNonQuery(string query, string sessionID);
    }
}
