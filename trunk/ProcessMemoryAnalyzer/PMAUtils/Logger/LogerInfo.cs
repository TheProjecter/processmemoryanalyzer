using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace PMA.Utils.Logger
{
    public class LoggerInfo
    {
        public const string LOGGER_FILE = "logger.xml";

        private string _loggerFile;

        private static string _defaultLogPath = AppDomain.CurrentDomain.BaseDirectory + "\\" + LOGGER_FILE;

        internal LoggerInfo()
        {

        }

        internal LoggerInfo(string logFilePath, EnumLogger level)
        {
            _loggerFile = logFilePath;
            Level = level;
        }

        
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
                        File.Create(_defaultLogPath);
                        _loggerFile = value;
                    }
                }
                else
                {
                    _loggerFile = value;
                }
            }
        }

        public EnumLogger Level { get; set; }

        internal string Serialize()
        {
            StringWriter sw = new StringWriter();
            XmlSerializer x = new XmlSerializer(this.GetType());
            x.Serialize(sw, this);
            return sw.ToString();
        }

        internal static LoggerInfo Deserialize(string strObject)
        {
            XmlSerializer x = new XmlSerializer(typeof(LoggerInfo));
            return (LoggerInfo)x.Deserialize(new StringReader(strObject));
        }
    }
}
