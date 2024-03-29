﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace PMA.Info
{
    /// <summary>
    /// 
    /// </summary>
    public class PMAInfo
    {

        public const string PMA_INFO_FILE = "PMAInfo.xml";
        
        public int ReportsIntervalHours { get; set; }
        public DateTime MailingTime { get; set; }
        public string MachineName { get; set; }
        public bool DisposeLogFile { get; set; }
        public int TriggerSeed { get; set; }
        public bool UseFTP { get; set; }
        public bool UseSMTP { get; set; }


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

  

}
