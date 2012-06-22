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

        public static Dictionary<string, bool> UsersLoggedIn { get; set; }

        static PMAUserManager()
        {
            UsersLoggedIn = new Dictionary<string, bool>();
        }

        public static PMAUserInfo GetUserInfo(string username, string password)
        {
            PMAUserInfo userInfo = (from info in PMAConfigManager.GetConfigManagerInstance.PMAUsers.ListPMAUserInfo
                                    where info.UserName == username && info.UserPassword == password
                                    select info).SingleOrDefault<PMAUserInfo>();

            if (userInfo != null)
            {
                UsersLoggedIn.Add(userInfo.UserName, true);
            }
            
            return userInfo;
        }

    }
}
