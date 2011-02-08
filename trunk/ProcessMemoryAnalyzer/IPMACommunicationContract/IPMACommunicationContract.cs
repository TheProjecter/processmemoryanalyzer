using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Data;
using PMA.Info;
using System.ServiceProcess;

namespace PMA.CommunicationAPI
{
    [ServiceContract]
    public interface IPMACommunicationContract
    {

        [OperationContract]
        bool VerfiyConnection();

        [OperationContract]
        string ExecuteActions(List<string> actions, string sessionID);

        [OperationContract]
        List<string> GetAvailableActions(string sessionID);

        [OperationContract]
        Dictionary<string, ServiceControllerStatus> GetAvailableServices(string sessionID);

        [OperationContract]
        string GetSessionID(string username, string password);

        [OperationContract]
        PMAUserInfo GetUserInfo(string sessionID);

        [OperationContract]
        void LogoutSession(string sessionID);

        [OperationContract]
        string ServiceActions(Dictionary<string,string> servicesActions, string sessionID);

        [OperationContract]
        DataSet ExcuteQuery(string query, string sessionID);

        [OperationContract]
        string ExcuteNonQuery(string query, string sessionID);
    }
}
