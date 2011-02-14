using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Security.Cryptography;


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
    [DataContract] 
    public class PMAUserInfo
    {

        private string _userPassword;

        [DataMember]
        public string UserName { get; set; }

        public string UserPassword 
        {
            set
            {
                _userPassword = EncodePasswordToMD5(value);
            }
            get
            {
                return _userPassword;
            }
              
        }

        [DataMember]
        public bool IsSQLUser { get; set; }

        [DataMember]
        public bool IsActionUser { get; set; }

        [DataMember]
        public bool IsServiceUser { get; set; }

        [DataMember]
        public DateTime LastLoginTime { get; set; }

        
        /// <summary>
        /// Encodes the password to md5.
        /// </summary>
        /// <param name="originalPassword">The original password.</param>
        /// <returns></returns>
        public static string EncodePasswordToMD5(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }
       
    }


}
