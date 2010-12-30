using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMA.Info
{
    public class PMAServerManagerInfo
    {
        public string DatabaseServer { get; set; }
        public string DatabaseUser { get; set; }
        public string DatabaseUserPassword { get; set; }

        public string SystemUser { get; set; }
        public string SystemUserPassword { get; set; }

        public Dictionary<string, string> ApplicationRemoteUsers { get; set; }
        public int ListenPort { get; set; }

        public bool SetServiceAdminstration { get; set; }
        public List<string> ListServices { get; set; }

        public bool SetCommandPrivileges { get; set; }
        public List<string> ListCommands { get; set; }

        public bool SetDBAccess { get; set; }


    }
}
