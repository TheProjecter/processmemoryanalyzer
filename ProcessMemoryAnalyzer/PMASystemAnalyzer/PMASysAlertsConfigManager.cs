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

        public FTPInfo FtpInfo { get; set; }
        public SmtpInfo SmtpInfo { get; set; }
        public PMASystemAnalyzerInfo SystemAnalyzerInfo { get; set; }

        public List<string> _errorMessage = null;
        
        public List<string> ErrorMessage 
        {
            get
            {
                if (_errorMessage == null)
                {
                    _errorMessage = new List<string>();
                }
                return _errorMessage;
            }
            set
            {
                if (_errorMessage == null)
                {
                    _errorMessage = new List<string>();
                }
                _errorMessage = value;
            }
        }

        public void ClearErrorMessage()
        {
            ErrorMessage.Clear();
        }

        public string GetConsolidatedError(string caption)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(caption);
            sb.AppendLine();
            foreach (string message in ErrorMessage)
            {
                sb.AppendLine(message);
            }
            return sb.ToString();
        }

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
            if (FtpInfo == null)
            {
                if (File.Exists(Path.Combine(CurrentAppConfigDir, FTPInfo.FTP_INFO_FILE)))
                {
                    FtpInfo = FTPInfo.Deserialize(File.ReadAllText(Path.Combine(CurrentAppConfigDir, FTPInfo.FTP_INFO_FILE)));
                }
                else FtpInfo = new FTPInfo();
            }
        }

        private void InitilizeSMTPObject()
        {
            if (SmtpInfo == null)
            {
                if (File.Exists(Path.Combine(CurrentAppConfigDir, SmtpInfo.SMTP_INFO_FILE)))
                {
                    SmtpInfo = SmtpInfo.Deserialize(File.ReadAllText(Path.Combine(CurrentAppConfigDir, SmtpInfo.SMTP_INFO_FILE)));
                }
                else SmtpInfo = new SmtpInfo();
            }
        }

        private void InitilizeSystemAnalyzerObject()
        {
            if (SystemAnalyzerInfo == null)
            {
                if (File.Exists(Path.Combine(CurrentAppConfigDir, PMASystemAnalyzerInfo.PMA_INFO_FILE)))
                {
                    SystemAnalyzerInfo = PMASystemAnalyzerInfo.Deserialize(File.ReadAllText(Path.Combine(CurrentAppConfigDir, PMASystemAnalyzerInfo.PMA_INFO_FILE)));
                }
                else SystemAnalyzerInfo = new PMASystemAnalyzerInfo();
            }
        }

        
        public void SaveConfiguration()
        {
            File.WriteAllText(Path.Combine(CurrentAppConfigDir, FTPInfo.FTP_INFO_FILE), FtpInfo.Serialize());

            File.WriteAllText(Path.Combine(CurrentAppConfigDir, SmtpInfo.SMTP_INFO_FILE), SmtpInfo.Serialize());

            File.WriteAllText(Path.Combine(CurrentAppConfigDir, PMASystemAnalyzerInfo.PMA_INFO_FILE), SystemAnalyzerInfo.Serialize());
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
