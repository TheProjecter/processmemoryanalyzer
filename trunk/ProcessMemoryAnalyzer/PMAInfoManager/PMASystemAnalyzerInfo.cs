using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;

namespace PMA.Info
{
    /// <summary>
    /// 
    /// </summary>
    public class PMASystemAnalyzerInfo
    {

        public const string PMA_INFO_FILE = "PMASystemAnalyzerInfo.xml";

        private HashSet<string> _listDrivesToWatch = null;

        private HashSet<string> _listServiceWatcher = null;

        private List<string> _listSendMailTo = null;

        private List<string> _listPostFTPMessageOn = null;

        private List<PMACrashReportInfo> _listCrashReportInfo = null;

        //-------------------------------------------------------------------------------------------------

        #region Home Configs
        
        [DefaultValue(false)]
        public bool SetDiscWatch { get; set; }

        [DefaultValue(false)]
        public bool SetPhysicalMemWatch { get; set; }

        [DefaultValue(false)]
        public bool SetServiceWatcher { get; set; }

        [DefaultValue(false)]
        public bool SetOptimizeDB { get; set; }

        [DefaultValue(false)]
        public bool SetSendMail { get; set; }

        [DefaultValue(false)]
        public bool SetPostFTP { get; set; }

        [DefaultValue(false)]
        public bool SetPMA { get; set; }

        [DefaultValue(false)]
        public bool SetCrashReporting { get; set; }

        #endregion 

        //-------------------------------------------------------------------------------------------------
        
        #region DatabaseOptimizer

        [DefaultValue(false)]
        public bool IsWebServer { get; set; }

        [DefaultValue(false)]
        public bool SetSessionStateSizeAlerts { get; set; }

        [DefaultValue(false)]
        public bool SetTempDBSizeAlerts { get; set; }

        [DefaultValue(0)]
        public int SessionStateSizeAlertLevel { get; set; }

        [DefaultValue(0)]
        public int TempDBSizeAlertLevel { get; set; } 

        [DefaultValue("")]
        public string Database { get; set; }

        [DefaultValue("")]
        public string DBUser { get; set; }

        [DefaultValue("")]
        public string DBPassword { get; set; }
        
        #endregion 

        //-------------------------------------------------------------------------------------------------
        
        #region DriveController
        
        public HashSet<string> ListDrivesToWatch 
        {
            get
            {
                if (_listDrivesToWatch == null)
                {
                    _listDrivesToWatch = new HashSet<string>();
                }
                return _listDrivesToWatch;
            }
            set
            {
                _listDrivesToWatch = value;
            }
            
        }

        [DefaultValue(0)]
        public int LowDiscAlertAt { get; set; }
        
        #endregion 

        //-------------------------------------------------------------------------------------------------
        
        #region PhysicalMemory

        [DefaultValue(0)]
        public int SystemPhysicalMemoryAlertAt { get; set; }
        
        #endregion 

        //-------------------------------------------------------------------------------------------------
        
        #region Service Watcher

        public HashSet<string> ListServicesNames 
        {
            get
            {
                if (_listServiceWatcher == null)
                {
                    _listServiceWatcher = new HashSet<string>();
                }
                return _listServiceWatcher;
            }
            set
            {
                _listServiceWatcher = value;
            }
        
        }

        [DefaultValue(false)]
        public bool SetStartStoppedServicesAlerts { get; set; }

        [DefaultValue(0)]
        public int ProcessPhysicalMemoryAlertAt { get; set; }

        #endregion 

        //-------------------------------------------------------------------------------------------------


        #region Transport Server
        public List<string> ListSendMailTo 
        {
            get
            {
                if (_listSendMailTo == null)
                {
                    _listSendMailTo = new List<string>();
                }
                return _listSendMailTo;
            }

            set
            {
                _listSendMailTo = value;
            }
        }

        public List<string> ListPostFTPMessageOn
        {
            get
            {
                if (_listPostFTPMessageOn == null)
                {
                    _listPostFTPMessageOn = new List<string>();
                }
                return _listPostFTPMessageOn;
            }
            set
            {
                _listPostFTPMessageOn = value;
            }
        }
        #endregion 

        //--------------------------------------------------------------------------------------------------

        #region Crash Report

        public List<PMACrashReportInfo> ListCrashReportInfo 
        {
            get
            {
                if (_listCrashReportInfo == null)
                {
                    _listCrashReportInfo = new List<PMACrashReportInfo>();
                }
                return _listCrashReportInfo;
            }
            set
            {
                _listCrashReportInfo = value;
            }
        }

        #endregion 

        #region Serializer & Deserializer
        /// <summary>
        /// Serializes this instance.
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            StringWriter sw = new StringWriter();
            XmlSerializer x = new XmlSerializer(this.GetType());
            x.Serialize(sw, this);
            return sw.ToString();
        }

        /// <summary>
        /// Deserializes the specified STR object.
        /// </summary>
        /// <param name="strObject">The STR object.</param>
        /// <returns></returns>
        public static PMASystemAnalyzerInfo Deserialize(string strObject)
        {
            XmlSerializer x = new XmlSerializer(typeof(PMASystemAnalyzerInfo));
            return (PMASystemAnalyzerInfo)x.Deserialize(new StringReader(strObject));
        }
        #endregion 

    }

    

}
