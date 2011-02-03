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

        public static Dictionary<string, string> UsersLoggedIn { get; set; }

        static PMAUserManager()
        {
            UsersLoggedIn = new Dictionary<string, string>();
        }

        public static PMAUserInfo GetUserInfo(string username, string password)
        {
            PMAUserInfo userInfo = (from info in PMAConfigManager.GetConfigManagerInstance.PMAUsers.ListPMAUserInfo
                                    where info.UserName == username && info.UserPassword == password
                                    select info).SingleOrDefault<PMAUserInfo>();

            if (userInfo != null)
            {
                if (!UsersLoggedIn.ContainsKey(userInfo.UserName))
                {
                    UsersLoggedIn.Add(GenerateId(),userInfo.UserName );
                }
            }
            
            return userInfo;
        }

        private static string GenerateId()
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
