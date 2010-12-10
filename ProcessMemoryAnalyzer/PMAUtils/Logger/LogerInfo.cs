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

        private static string _defaultLogPath = AppDomain.CurrentDomain.BaseDirectory + "\\log";

        private static string _defaultLogFile = _defaultLogPath + "\\" + LOGGER_FILE;

        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerInfo"/> class.
        /// </summary>
        internal LoggerInfo()
        {
            LoggerFile = _defaultLogFile;
            Level = EnumLogger.OFF;
        }

        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerInfo"/> class.
        /// </summary>
        /// <param name="logFilePath">The log file path.</param>
        /// <param name="level">The level.</param>
        internal LoggerInfo(string logFilePath, EnumLogger level)
        {
            _loggerFile = logFilePath;
            Level = level;
        }


        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the logger file.
        /// </summary>
        /// <value>The logger file.</value>
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
                        if(!Directory.Exists(_defaultLogPath))
                        {
                            Directory.CreateDirectory(_defaultLogPath);
                        }
                        File.Create(_defaultLogFile);
                        _loggerFile = _defaultLogFile;
                    }
                }
                else
                {
                    _loggerFile = value;
                }
            }
        }

        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>The level.</value>
        public EnumLogger Level { get; set; }


        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Serializes this instance.
        /// </summary>
        /// <returns></returns>
        internal string Serialize()
        {
            StringWriter sw = new StringWriter();
            XmlSerializer x = new XmlSerializer(this.GetType());
            x.Serialize(sw, this);
            return sw.ToString();
        }


        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Deserializes the specified STR object.
        /// </summary>
        /// <param name="strObject">The STR object.</param>
        /// <returns></returns>
        internal static LoggerInfo Deserialize(string strObject)
        {
            XmlSerializer x = new XmlSerializer(typeof(LoggerInfo));
            return (LoggerInfo)x.Deserialize(new StringReader(strObject));
        }
    }
}
