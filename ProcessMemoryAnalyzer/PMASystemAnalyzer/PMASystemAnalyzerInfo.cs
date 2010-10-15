using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace PMA.SystemAnalyzer
{
    /// <summary>
    /// 
    /// </summary>
    public class PMASystemAnalyzerInfo
    {

        public const string PMA_INFO_FILE = "PMASystemAnalyzerInfo.xml";

        private HashSet<string> _listDrivesToWatch = null;

        private HashSet<string> _listServiceWatcher = null;

        //-------------------------------------------------------------------------------------------------

        #region Home Configs
        
        public bool SetDiscWatch { get; set; }

        public bool SetPhysicalMemWatch { get; set; }

        public bool SetServiceWatcher { get; set; }

        public bool SetOptimizeDB { get; set; }
        
        public bool SetSendMail { get; set; }

        public bool SetPostFTP { get; set; }

        #endregion 

        //-------------------------------------------------------------------------------------------------
        
        #region DatabaseOptimizer
        
        public bool IsWebServer { get; set; }

        public string Database { get; set; }

        public string DBUser { get; set; }

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
        public int LowDiscAlertAt { get; set; }
        
        #endregion 

        //-------------------------------------------------------------------------------------------------
        
        #region PhysicalMemory

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

        public bool SetStartStoppedServicesAlerts { get; set; }

        public int ProcessPhysicalMemoryAlertAt { get; set; }

        #endregion 

        //-------------------------------------------------------------------------------------------------


        #region Transport Server
        public List<string> ListSendMailTo { get; set; }

        public List<string> ListPostFTPMessageOn { get; set; }
        #endregion 

        //--------------------------------------------------------------------------------------------------


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
