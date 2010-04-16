using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace PMA.ProcessMemoryAnalyzer
{
    /// <summary>
    /// 
    /// </summary>
    public class PMAInfo
    {

        public const string PMA_INFO_FILE = "PMAInfo.xml";
        
        public List<string> ServicesNames { get; set; }
        public int LogingTimeInterval { get; set; }
        //public string ReportsInterval { get; set; }
        public string MailingTime { get; set; }

        public string Serialize()
        {
            StringWriter sw = new StringWriter();
            XmlSerializer x = new XmlSerializer(this.GetType());
            x.Serialize(sw, this);
            return sw.ToString();
        }

        public static PMAInfo Deserialize(string strObject)
        {
            XmlSerializer x = new XmlSerializer(typeof(PMAInfo));
            return (PMAInfo)x.Deserialize(new StringReader(strObject));
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class Emails
    {
        public const string EMAILS_INFO_FILE = "EMAILSInfo.xml";

        public List<string> EmailTo { get; set;}
        public List<string> EmailCC { get; set; }

        public string Subject { get; set; }
        public string AttachmentPath { get; set; }
        public string BodyContent { get; set; }

        public string Serialize()
        {
            StringWriter sw = new StringWriter();
            XmlSerializer x = new XmlSerializer(this.GetType());
            x.Serialize(sw, this);
            return sw.ToString();
        }

        public static Emails Deserialize(string strObject)
        {
            XmlSerializer x = new XmlSerializer(typeof(Emails));
            return (Emails)x.Deserialize(new StringReader(strObject));
        }
    }

}
