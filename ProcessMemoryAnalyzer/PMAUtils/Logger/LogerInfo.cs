using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace PMA.Logger
{
    public class LoggerInfo
    {
        const string LOGGER_FILE = "logger.xml";

        private string _loggerFile;

        const string defaultLogPath = AppDomain.CurrentDomain.BaseDirectory + "\\" + LOGGER_FILE;

        
        public string LoggerFile 
        {
            get
            {
                return _loggerFile;
            }
            set
            {
                if (!File.Exists(value))
                {
                    try
                    {
                        File.Create(value);
                        _loggerFile = value;
                    }
                    catch
                    {
                        File.Create(defaultLogPath);
                        _loggerFile = value;
                    }
                }
                else
                {
                    _loggerFile = value;
                }
            }
        }

        public bool Level { get; set; }

        public string Serialize()
        {
            StringWriter sw = new StringWriter();
            XmlSerializer x = new XmlSerializer(this.GetType());
            x.Serialize(sw, this);
            return sw.ToString();
        }

        public static LoggerInfo Deserialize(string strObject)
        {
            XmlSerializer x = new XmlSerializer(typeof(LoggerInfo));
            return (LoggerInfo)x.Deserialize(new StringReader(strObject));
        }
    }
}
