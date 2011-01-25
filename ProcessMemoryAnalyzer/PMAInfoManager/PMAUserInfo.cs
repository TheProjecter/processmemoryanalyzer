using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace PMA.Info
{

    /// <summary>
    /// Class containing list of user and able to serialize
    /// </summary>
    public class PMAUsers
    {

        public const string PMA_USERS_FILE = "PMAUserInfo.xml";

        public List<PMAUserInfo> ListPMAUserInfo { get; set; }


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
        public static PMAUsers Deserialize(string strObject)
        {
            XmlSerializer x = new XmlSerializer(typeof(PMAUsers));
            return (PMAUsers)x.Deserialize(new StringReader(strObject));
        }
    }

    /// <summary>
    /// UserInfo Class defining attributes of single users
    /// </summary>
    public class PMAUserInfo
    {
        
        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public bool IsSQLUser { get; set; }

        public bool IsActionUser { get; set; }

        public bool IsServiceUser { get; set; }
       
    }
}
