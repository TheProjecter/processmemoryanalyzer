using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using PMA.Utils;

namespace PMA.Utils.smtp
{
    
    public class SmtpInfo
    {
        public const string SMTP_INFO_FILE = "SMTPInfo.xml";

        private string _password;

        public string UserName { get; set;}
        public string Password 
        {
            get
            {
                return OperationUtils.EncryptDecrypt(_password, 129);
            }
            set
            {
                _password = OperationUtils.EncryptDecrypt(value, 129);
            }
        }
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
