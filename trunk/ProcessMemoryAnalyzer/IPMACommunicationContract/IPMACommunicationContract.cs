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
        DataSet ExecuteQuery(string query);

        [OperationContract]
        string ExecuteCommand(string command);

        [OperationContract]
        List<string> GetAvailableCommands();

        [OperationContract]
        PMAUserInfo GetUserInfo(string username, string password);

    }
}
