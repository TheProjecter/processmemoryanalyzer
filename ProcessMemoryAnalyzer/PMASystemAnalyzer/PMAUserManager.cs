using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Info;
using PMA.ConfigManager;
using System.Threading;
using PMA.Utils.Logger;

namespace PMA.SystemAnalyzer
{
    public class PMAUserManager 
    {

        private static Dictionary<string, PMAUserInfo> UsersLoggedIn { get; set; }

        private static PMAUserManager _userManager;

        private static PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        private static Logger logger = configManager.Logger;


        #region Contructor
        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="PMAUserManager"/> class.
        /// </summary>
        private PMAUserManager()
        {
            logger.Debug(EnumMethod.START);
            UsersLoggedIn = new Dictionary<string, PMAUserInfo>();
            
            // Stating Thread to remove expired Sessions
            Thread sessionRemoveThread = new Thread(RemoveExpiredSession);
            sessionRemoveThread.IsBackground = true;
            sessionRemoveThread.Name = "RemoveExpiredSessions";
            logger.Message("Starting new background thread");
            sessionRemoveThread.Start();
 
            logger.Debug(EnumMethod.END);
        }
        #endregion 

        
      
        #region Public Methods and Properties
        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the get user manager instance.
        /// </summary>
        /// <value>The get user manager instance.</value>
        public static PMAUserManager GetUserManagerInstance
        {
            get
            {
                if (_userManager == null)
                {
                    _userManager = new PMAUserManager();
                }
                return _userManager;
            }
        }



        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the session ID.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public string GetSessionID(string username, string password)
        {
            logger.Debug(EnumMethod.START);
           
            PMAUserInfo userInfo = null;
            foreach (PMAUserInfo tempUserInfo in configManager.PMAUsers.ListPMAUserInfo)
            {
                if (tempUserInfo.UserName == username && tempUserInfo.UserPassword == password)
                {
                    userInfo = tempUserInfo;
                    break;
                }
            }
            
            string sessionID = string.Empty;
            if (userInfo != null)
            {
                lock (UsersLoggedIn)
                {
                    sessionID = CreateSessionID(userInfo);
                    userInfo.LastLoginTime = DateTime.Now;
                    configManager.UpdateUserInformation();
                }
            }
            logger.Debug(EnumMethod.END);
            if (sessionID != null && sessionID != string.Empty)
            {
                string message = "User " + userInfo.UserName + " Has Logged into system";
                PMAMailController mailController = new PMAMailController(message, AlertType.USER_ALERT, userInfo.UserName);
                mailController.SendMail();
            }
            return sessionID;
        }

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the user info.
        /// </summary>
        /// <param name="sessionID">The session ID.</param>
        /// <returns></returns>
        public PMAUserInfo GetUserInfo(string sessionID)
        {
            logger.Debug(EnumMethod.START);
            if (UsersLoggedIn.Keys.Contains<string>(sessionID))
            {
                logger.Debug(EnumMethod.END);
                return UsersLoggedIn[sessionID];
            }
            else
            {
                logger.Debug(EnumMethod.END);
                return null;
            }

        }

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Logouts the session.
        /// </summary>
        /// <param name="sessionID">The session ID.</param>
        public void LogoutSession(string sessionID)
        {
            logger.Debug(EnumMethod.START);
            RemoveSessionID(sessionID);
            logger.Debug(EnumMethod.END);
        }

        #endregion 



        #region PrivateMethods
        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Removes the expired session.
        /// </summary>
        private void RemoveExpiredSession()
        {
            logger.Debug(EnumMethod.START);
            PMAUserInfo userInfo = null;
            List<string> expiredSessions = new List<string>();
            foreach (string sessionID in UsersLoggedIn.Keys)
            {
                userInfo = UsersLoggedIn[sessionID];
                if ((userInfo.LastLoginTime - DateTime.Now).Hours > 6)
                {
                    expiredSessions.Add(sessionID);
                }
            }

            foreach (string sessionID in expiredSessions)
            {
                RemoveSessionID(sessionID);
            }
            Thread.Sleep(60000);
            logger.Debug(EnumMethod.END);
        }

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates the session ID.
        /// </summary>
        /// <param name="userInfo">The user info.</param>
        /// <returns></returns>
        private string CreateSessionID(PMAUserInfo userInfo)
        {
            logger.Debug(EnumMethod.START);
            string sessionID = string.Empty;
            lock (UsersLoggedIn)
            {
                UsersLoggedIn.Add(sessionID = GenerateUniqueId(), userInfo);
            }
            logger.Debug(EnumMethod.END);
            return sessionID;
        }

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Removes the session ID.
        /// </summary>
        /// <param name="sessionID">The session ID.</param>
        private void RemoveSessionID(string sessionID)
        {
            logger.Debug(EnumMethod.START);
            if (UsersLoggedIn.Keys.Contains<string>(sessionID))
            {
                lock (UsersLoggedIn)
                {
                    UsersLoggedIn.Remove(sessionID);
                }
            }
            logger.Debug(EnumMethod.END);
        }


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Generates the unique id.
        /// </summary>
        /// <returns></returns>
        private string GenerateUniqueId()
        {
            logger.Debug(EnumMethod.START);
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            logger.Debug(EnumMethod.END);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        #endregion 

    }
}
