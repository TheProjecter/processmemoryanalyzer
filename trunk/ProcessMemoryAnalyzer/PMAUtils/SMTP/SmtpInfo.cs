using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace PMA.Utils.smtp
{
    
    public class SmtpInfo
    {
        public const string SMTP_INFO_FILE = "SMTPInfo.xml";

        public string UserName { get; set;}
        public string Password { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public int TimeOut { get; set; }
        public bool SSL { get; set; }

        public string Serialize()
        {
            StringWriter sw = new StringWriter();
            XmlSerializer x = new XmlSerializer(this.GetType());
            x.Serialize(sw, this);
            return sw.ToString();
        }

        public static SmtpInfo Deserialize(string strObject)
        {
            XmlSerializer x = new XmlSerializer(typeof(SmtpInfo));
            return (SmtpInfo)x.Deserialize(new StringReader(strObject));
        }
    }

    
}
