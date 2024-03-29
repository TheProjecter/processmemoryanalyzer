﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace PMA.Utils.Logger
{
    
    public class Logger
    {

        private static object _lockObject = new object();
        
        private static Logger _logger = null;

        private LoggerInfo _loggerInfo;

        public LoggerInfo LoggerInfo
        {
            get
            {
                return _loggerInfo;
            }
            set
            {
                _loggerInfo = value;
            }
        }

        //----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        private Logger()
        {
            _loggerInfo = new LoggerInfo();
        }

        //----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="logFilePath">The log file path.</param>
        /// <param name="level">The level.</param>
        private Logger(string logFilePath,EnumLogger level)
        {
            _loggerInfo = new LoggerInfo(logFilePath,level);
        }


        //----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the get instance.
        /// </summary>
        /// <value>The get instance.</value>
        public static Logger GetInstance()
        {
              if (_logger == null)
              {
                  _logger = new Logger();
              }
              return _logger;
        }

        //----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="logFilePath">The log file path.</param>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        public static Logger GetInstance(string logFilePath, EnumLogger level)
        {
            if (_logger == null)
            {
                _logger = new Logger(logFilePath, level);
            }
            return _logger;
        }


        //----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the deserialized instance.
        /// </summary>
        /// <param name="xmlData">The XML data.</param>
        /// <returns></returns>
        public static Logger GetDeserializedInstance(string xmlData)
        {
            if (_logger == null)
            {
                _logger = new Logger();
                _logger._loggerInfo = LoggerInfo.Deserialize(xmlData);
            }
            return _logger;
        }


        //----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the serialized logger instance.
        /// </summary>
        /// <returns></returns>
        public string SerializedLoggerInstance()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }
            return _logger._loggerInfo.Serialize();
        }


        //----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(EnumMethod enumMethod)
        {
            StackTrace st = new StackTrace();
            string whoCalledMe = st.GetFrame(1).GetMethod().Name;
            string position = string.Empty;
            if (enumMethod != EnumMethod.NONE)
            {
                if (enumMethod == EnumMethod.START)
                {
                    position = "--> Start";
                }
                else if (enumMethod == EnumMethod.END)
                {
                    position = "--> End";
                }
            }

            if (_loggerInfo.Level == EnumLogger.DEBUG)
            {
                
                string log = ("Debug :" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToShortDateString() + "-->" + whoCalledMe  + position);
                WriteFile("\r\n" + log);
            }
        }

        //----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Message(string message)
        {
            StackTrace st = new StackTrace();
            string whoCalledMe = st.GetFrame(1).GetMethod().Name;
            string position = string.Empty;
            if (_loggerInfo.Level == EnumLogger.DEBUG)
            {

                string log = ("Message :" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToShortDateString() + "-->" + whoCalledMe + " : " + message);
                WriteFile("\r\n" + log);
            }
        }


       
        //----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Errors the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public void Error(Exception ex)
        {
            if (_loggerInfo.Level == EnumLogger.DEBUG || _loggerInfo.Level == EnumLogger.ERROR)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ERROR :" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToShortDateString() + "-->" + ex.Message);
                sb.AppendLine("Stack Trace");
                sb.AppendLine(ex.StackTrace);
                WriteFile("\r\n" + sb.ToString());
            }
        }


        //----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Writes the file.
        /// </summary>
        /// <param name="message">The message.</param>
        private void WriteFile(string message)
        {
            string file = _loggerInfo.LoggerFile;
            lock (_lockObject)
            {
                if (Thread.CurrentThread.IsBackground)
                {
                    if (Thread.CurrentThread.Name == null && Thread.CurrentThread.Name == string.Empty)
                    {
                        file = file + ".UnknownBackgroundThread" + ".txt";
                    }
                    else file = file + "." + Thread.CurrentThread.Name + ".txt";
                }

                if (!File.Exists(file))
                {
                    try
                    {
                        FileStream fs = File.Create(file);
                        fs.Dispose();
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("PMALogger", ex.Message);
                    }
                }
                File.AppendAllText(file, message);
            }
        }

}
}

