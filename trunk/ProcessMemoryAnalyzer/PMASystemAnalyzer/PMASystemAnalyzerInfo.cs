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

        /// <summary>
        /// Gets or sets the services names.
        /// </summary>
        /// <value>The services names.</value>
        public List<string> ServicesNames { get; set; }
        
        
        /// <summary>
        /// Gets or sets the disc to analyze.
        /// </summary>
        /// <value>The disc to analyze.</value>
        public List<string> DiscsToAnalyze { get; set; }
        
        
        /// <summary>
        /// Gets or sets a value indicating whether [generate low disc alert].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [generate low disc alert]; otherwise, <c>false</c>.
        /// </value>
        public bool GenerateLowDiscAlert { get; set; }
        
        
        /// <summary>
        /// Gets or sets a value indicating whether [generate stopped service alert].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [generate stopped service alert]; otherwise, <c>false</c>.
        /// </value>
        public bool GenerateStoppedServiceAlert { get; set; }
        
        
        /// <summary>
        /// Gets or sets a value indicating whether [generate process physical mem alerts].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [generate process physical mem alerts]; otherwise, <c>false</c>.
        /// </value>
        public bool GenerateProcessPhysicalMemAlerts { get; set; }

        /// <summary>
        /// Gets or sets the generate low disc alert On Crossing Provided Value in %.
        /// </summary>
        /// <value>The generate low disc alert at.</value>
        public int GenerateLowDiscAlertAt { get; set; }
       
        
        /// <summary>
        /// Gets or sets the generate process physical memory alert On Crossing Provided Value in %.
        /// </summary>
        /// <value>The generate process physical memory alert at.</value>
        public int GenerateProcessPhysicalMemoryAlertAt { get; set; }

        public bool SendMail { get; set; }

        public bool PostFTP { get; set; }

        public List<string> SendMailTo { get; set; }

        public List<string> PostFTPMessageOn { get; set; }



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

    }

    

}
