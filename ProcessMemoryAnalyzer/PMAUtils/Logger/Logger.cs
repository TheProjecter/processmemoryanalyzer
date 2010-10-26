using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PMA.Logger
{
    
    public class Logger
    {

        private static Logger _logger = null;

        private LoggerInfo loggerInfo;

        private Logger()
        {
            loggerInfo = new LoggerInfo();
        }

        public static Logger GetInstance
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logger();
                    return _logger;
                }
                else return _logger;
            }
        }

        
        public void Debug(string message)
        {
            if (loggerInfo.Level)
            {
                string log = ("Debug :" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToShortDateString() + "-->" + message);
                File.AppendAllText(loggerInfo.LoggerFile, log);
            }
        }

        public void Error(Exception ex)
        {
            if (loggerInfo.Level)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ERROR :" + DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToShortDateString() + "-->" + ex.Message);
                sb.AppendLine("Stack Trace");
                sb.AppendLine(ex.StackTrace);
                File.AppendAllText(loggerInfo.LoggerFile, sb.ToString());
            }
        }

}
}

