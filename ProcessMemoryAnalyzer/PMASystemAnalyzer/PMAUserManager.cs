using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Info;
using PMA.ConfigManager;
using System.Threading;

namespace PMA.SystemAnalyzer
{
    public class PMAUserManager 
    {

        private static Dictionary<string, PMAUserInfo> UsersLoggedIn { get; set; }

        private static PMAUserManager _userManager;


        #region Contructor
        private PMAUserManager()
        {
            UsersLoggedIn = new Dictionary<string, PMAUserInfo>();
            
            // Stating Thread to remove expired Sessions
            Thread sessionRemoveThread = new Thread(RemoveExpiredSession);
            sessionRemoveThread.IsBackground = true;
            sessionRemoveThread.Name = "RemoveExpiredSessions";
            sessionRemoveThread.Start();
        }
        #endregion 

        
      
        #region Public Methods and Properties
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


        
        public string GetSessionID(string username, string password)
        {
            PMAUserInfo userInfo = (from info in PMAConfigManager.GetConfigManagerInstance.PMAUsers.ListPMAUserInfo
                                    where info.UserName == username && info.UserPassword == password
                                    select info).SingleOrDefault<PMAUserInfo>();
            string sessionID = string.Empty;
            if (userInfo != null)
            {
                lock (UsersLoggedIn)
                {
                    sessionID = CreateSessionID(userInfo);
                    userInfo.LastLoginTime = DateTime.Now;
                }
            }
            return sessionID;
        }

        public PMAUserInfo GetUserInfo(string sessionID)
        {
            if (UsersLoggedIn.Keys.Contains<string>(sessionID))
            {
                return UsersLoggedIn[sessionID];
            }
            else return null;

        }

        public void LogoutSession(string sessionID)
        {
            RemoveSessionID(sessionID);
        }

        #endregion 



        #region PrivateMethods
        private void RemoveExpiredSession()
        {
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
        }

        private string CreateSessionID(PMAUserInfo userInfo)
        {
            string sessionID = string.Empty;
            lock (UsersLoggedIn)
            {
                UsersLoggedIn.Add(sessionID = GenerateUniqueId(), userInfo);
            }
            return sessionID;
        }

        private void RemoveSessionID(string sessionID)
        {
            if (UsersLoggedIn.Keys.Contains<string>(sessionID))
            {
                lock (UsersLoggedIn)
                {
                    UsersLoggedIn.Remove(sessionID);
                }
            }
        }

      
        
        private string GenerateUniqueId()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        #endregion 

    }
}
