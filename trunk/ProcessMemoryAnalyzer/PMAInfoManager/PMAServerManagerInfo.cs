using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace PMA.Info
{
    public class PMAServerManagerInfo
    {

        public const string PMA_SERVER_MANAGER_INFO = "PMAServerManagerInfo.xml";
        
        public string DatabaseServer { get; set; }
        public string DatabaseUser { get; set; }
        public string DatabaseUserPassword { get; set; }

        public string SystemUser { get; set; }
        public string SystemUserPassword { get; set; }

        public List<string> ListServices { get; set; }
        public List<string> ListActions { get; set; }

        public List<string> EmailSqlRemoteActivitySubscribers { get; set; }
        public List<string> EmailActionServicesSubsubscribers { get; set; }



        public string Serialize()
        {
            StringWriter sw = new StringWriter();
            XmlSerializer x = new XmlSerializer(this.GetType());
            x.Serialize(sw, this);
            return sw.ToString();
        }

        public static PMAServerManagerInfo Deserialize(string strObject)
        {
            XmlSerializer x = new XmlSerializer(typeof(PMAServerManagerInfo));
            return (PMAServerManagerInfo)x.Deserialize(new StringReader(strObject));
        }

    }
}
