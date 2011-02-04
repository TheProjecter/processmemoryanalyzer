using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Info;
using PMA.ConfigManager;

namespace PMA.SystemAnalyzer
{
    public class PMAUserManager 
    {

        private static Dictionary<string, PMAUserInfo> UsersLoggedIn { get; set; }

        private static PMAUserManager _userManager;
        
        private PMAUserManager()
        {
            UsersLoggedIn = new Dictionary<string, PMAUserInfo>();
        }

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
                UsersLoggedIn.Add(sessionID = GenerateUniqueId(), userInfo);
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
            if (UsersLoggedIn.Keys.Contains<string>(sessionID))
            {
                UsersLoggedIn.Remove(sessionID);
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

    }
}
