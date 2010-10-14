using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Utils.ftp;
using PMA.Utils.smtp;
using System.IO;

namespace PMA.SystemAnalyzer
{
    public class PMAConfigManager
    {

        private FTPInfo ftpInfo = null;
        private SmtpInfo smtpInfo = null;
        private PMASystemAnalyzerInfo systemAnalyzerInfo = null;

        private static string CONFIG_DIR = "Config";

        private static PMAConfigManager pmaConfigManager = null;

        private String CurrentAppConfigDir
        {
            get
            {
                string configDir = AppDomain.CurrentDomain.BaseDirectory + "\\" + CONFIG_DIR;
                if (!Directory.Exists(configDir))
                {
                    Directory.CreateDirectory(configDir);
                }
                return configDir;
            }
        }

        private void InitilizeFTPObject()
        {
            if (ftpInfo == null)
            {
                if (File.Exists(Path.Combine(CurrentAppConfigDir, FTPInfo.FTP_INFO_FILE)))
                {
                    ftpInfo = FTPInfo.Deserialize(Path.Combine(CurrentAppConfigDir, FTPInfo.FTP_INFO_FILE));
                }
                else ftpInfo = new FTPInfo();
            }
        }

        private void InitilizeSMTPObject()
        {
            if (smtpInfo == null)
            {
                if (File.Exists(Path.Combine(CurrentAppConfigDir, SmtpInfo.SMTP_INFO_FILE)))
                {
                    smtpInfo = SmtpInfo.Deserialize(Path.Combine(CurrentAppConfigDir, SmtpInfo.SMTP_INFO_FILE));
                }
                else smtpInfo = new SmtpInfo();
            }
        }

        private void InitilizeSystemAnalyzerObject()
        {
            if (systemAnalyzerInfo == null)
            {
                if (File.Exists(Path.Combine(CurrentAppConfigDir, PMASystemAnalyzerInfo.PMA_INFO_FILE)))
                {
                    systemAnalyzerInfo = PMASystemAnalyzerInfo.Deserialize(Path.Combine(CurrentAppConfigDir, PMASystemAnalyzerInfo.PMA_INFO_FILE));
                }
                else systemAnalyzerInfo = new PMASystemAnalyzerInfo();
            }
        }

        
        public void SaveConfiguration()
        {
            File.WriteAllText(Path.Combine(CurrentAppConfigDir,FTPInfo.FTP_INFO_FILE), ftpInfo.Serialize());

            File.WriteAllText(Path.Combine(CurrentAppConfigDir, SmtpInfo.SMTP_INFO_FILE), smtpInfo.Serialize());

            File.WriteAllText(Path.Combine(CurrentAppConfigDir, PMASystemAnalyzerInfo.PMA_INFO_FILE), systemAnalyzerInfo.Serialize());
        }

        
        private PMAConfigManager()
        {
            InitilizeFTPObject();
            InitilizeSMTPObject();
            InitilizeSystemAnalyzerObject();
        }

        public static PMAConfigManager GetConfigManagerInstance
        {
            get
            {
                if(pmaConfigManager == null)
                    pmaConfigManager = new PMAConfigManager();
                return pmaConfigManager;
            }
        }


    }
}
