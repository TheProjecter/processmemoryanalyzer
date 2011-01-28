using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace PMA.Info
{

    public class PMAClientInfo
    {

        public static string PMA_CLIENT_INFO = "PMAClientInfo.xml";


        #region Serializing Class
        
        public string Serialize()
        {
            StringWriter sw = new StringWriter();
            XmlSerializer x = new XmlSerializer(this.GetType());
            x.Serialize(sw, this);
            return sw.ToString();
        }

        public static PMAClientInfo Deserialize(string strObject)
        {
            XmlSerializer x = new XmlSerializer(typeof(PMAClientInfo));
            return (PMAClientInfo)x.Deserialize(new StringReader(strObject));
        }

        #endregion 

    }
    
    public class PMAClientRuntimeInfo
    {
        public bool IsUserLoggedIn { get; set; }

        public PMAUserInfo UserInfo { get; set; }
    }
}
