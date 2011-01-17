using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMA.CommunicationAPI
{
    public class PMACommunicationAPI : IPMACommunicationContract
    {

        #region IPMACommunicationContract Members

        public System.Data.DataSet ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }

        public string ExecuteCommand(string command)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAvailableCommands()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
