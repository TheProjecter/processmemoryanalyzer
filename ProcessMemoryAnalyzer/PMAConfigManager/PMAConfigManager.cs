using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Utils.ftp;
using PMA.Utils.smtp;
using PMA.Utils.Logger;
using System.IO;
using PMA.Info;


namespace PMA.ConfigManager
{
    public class PMAConfigManager
    {

        public FTPInfo FtpInfo { get; set; }
        public SmtpInfo SmtpInfo { get; set; }
        public PMASystemAnalyzerInfo SystemAnalyzerInfo { get; set; }
        public PMAFlagInfo FlagInfo { get; set; }
        public PMAInfo PMAInfoObj { get; set; }
        public Logger Logger { get; set; }
        public PMAServerManagerInfo PMAServerManagerInfo { get; set; }

        public PMAUsers PMAUsers { get; set; }

        private List<string> _Message = null;
        private static string CONFIG_DIR = "Config";
        private static string PMA_LOG_DIR = "PMALog";
        private static string REMOTE_ACTION_LOG = "RemoteActionLog";
        private static PMAConfigManager pmaConfigManager = null;

        public string PostDir 
        {
            get
            {
                string postPath = Path.Combine(Environment.CurrentDirectory, "Post");
                if (!Directory.Exists(postPath))
                {
                    Directory.CreateDirectory(postPath);
                }
                return postPath;
            }
        } 


        public string PMAApplicationDirectoryMemLog
        {
            get
            {
                string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\" + PMA_LOG_DIR;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }

        public string GetFileNameForRemoteAction(string preText)
        {

            if (preText == null)
            {
                preText = string.Empty;
            }
            string path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + "\\" + REMOTE_ACTION_LOG;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string file = Path.Combine(path, preText + "_" + DateTime.Now.Date.ToShortDateString().Replace('/', '-') + "_" + DateTime.Now.ToLongTimeString().Replace(':', '-'));
            return file;   
        }


        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public List<string> Message
        {
            get
            {
                if (_Message == null)
                {
                    _Message = new List<string>();
                }
                return _Message;
            }
            set
            {
                if (_Message == null)
                {
                    _Message = new List<string>();
                }
                _Message = value;
            }
        }


        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Clears the error message.
        /// </summary>
        public void ClearMessageList()
        {
            Message.Clear();
        }

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the consolidated error.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <returns></returns>
        public string GetConsolidatedError(string caption)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(caption);
            sb.AppendLine();
            foreach (string message in Message)
            {
                sb.AppendLine(message);
            }
            return sb.ToString();
        }


        #region initilize properties
        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the current app config dir.
        /// </summary>
        /// <value>The current app config dir.</value>
        public String CurrentAppConfigDir
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

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Initilizes the FTP object.
        /// </summary>
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

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Initilizes the SMTP object.
        /// </summary>
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

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Initilizes the system analyzer object.
        /// </summary>
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

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Initilizes the logger object.
        /// </summary>
        private void InitilizeLoggerObject()
        {
            if (Logger == null)
            {
                if (File.Exists(Path.Combine(CurrentAppConfigDir, LoggerInfo.LOGGER_FILE)))
                {
                    Logger = Logger.GetDeserializedInstance(File.ReadAllText(Path.Combine(CurrentAppConfigDir, LoggerInfo.LOGGER_FILE)));
                }
                else Logger = Logger.GetInstance();
                     
            }

        }

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Initilizes the PMA object.
        /// </summary>
        private void InitilizePMAObject()
        {
            if (PMAInfoObj == null)
            {
                if (File.Exists(Path.Combine(CurrentAppConfigDir, PMAInfo.PMA_INFO_FILE)))
                {
                    PMAInfoObj = PMAInfo.Deserialize(File.ReadAllText(Path.Combine(CurrentAppConfigDir, PMAInfo.PMA_INFO_FILE)));
                }
                else
                {
                    PMAInfoObj = new PMAInfo();
                    PMAInfoObj.MailingTime = DateTime.Now;
                    PMAInfoObj.TriggerSeed = 1;
                    PMAInfoObj.ReportsIntervalHours = 1;
                }
            }
        }

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Initilizes the flag info.
        /// </summary>
        private void InitilizeFlagInfo()
        {
            if (FlagInfo == null)
            {
                FlagInfo = new PMAFlagInfo();
            }
        }

        private void InitilizeUsers()
        {
            if (PMAUsers == null)
            {
                if (File.Exists(Path.Combine(CurrentAppConfigDir, PMAUsers.PMA_USERS_FILE)))
                {
                    PMAUsers = PMAUsers.Deserialize(File.ReadAllText(Path.Combine(CurrentAppConfigDir, PMAUsers.PMA_USERS_FILE)));
                }
                else
                {
                    PMAUsers = new PMAUsers { ListPMAUserInfo = new List<PMAUserInfo>() };
                }
            }
        }

        private void InitilizeServerManagerInfo()
        {
            if (PMAServerManagerInfo == null)
            {
                if (File.Exists(Path.Combine(CurrentAppConfigDir, PMAServerManagerInfo.PMA_SERVER_MANAGER_INFO)))
                {
                    PMAServerManagerInfo = PMAServerManagerInfo.Deserialize(File.ReadAllText(Path.Combine(CurrentAppConfigDir, PMAServerManagerInfo.PMA_SERVER_MANAGER_INFO)));
                }
                else
                {
                    PMAServerManagerInfo = new PMAServerManagerInfo {
                        ListActions = new List<string>(),
                        ListServices = new List<string>(),
                        DatabaseServer = string.Empty,
                        DatabaseUser = string.Empty,
                        DatabaseUserPassword = string.Empty,
                        SystemUser = string.Empty,
                        SystemUserPassword = string.Empty,
                        EmailActionServicesSubsubscribers = new List<string>(),
                        EmailSqlRemoteActivitySubscribers = new List<string>()
                    };
                }
            }
        }
        #endregion


        #region Serialize & save configuration
        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Saves the configuration.
        /// </summary>
        public void SaveConfiguration()
        {
            File.WriteAllText(Path.Combine(CurrentAppConfigDir, FTPInfo.FTP_INFO_FILE), FtpInfo.Serialize());

            File.WriteAllText(Path.Combine(CurrentAppConfigDir, SmtpInfo.SMTP_INFO_FILE), SmtpInfo.Serialize());

            File.WriteAllText(Path.Combine(CurrentAppConfigDir, PMASystemAnalyzerInfo.PMA_INFO_FILE), SystemAnalyzerInfo.Serialize());

            File.WriteAllText(Path.Combine(CurrentAppConfigDir, LoggerInfo.LOGGER_FILE), Logger.SerializedLoggerInstance());

            File.WriteAllText(Path.Combine(CurrentAppConfigDir, PMAInfo.PMA_INFO_FILE), PMAInfoObj.Serialize());

            if (PMAUsers.ListPMAUserInfo != null)
            {
                File.WriteAllText(Path.Combine(CurrentAppConfigDir, PMAUsers.PMA_USERS_FILE), PMAUsers.Serialize());
            }

            File.WriteAllText(Path.Combine(CurrentAppConfigDir, PMAServerManagerInfo.PMA_SERVER_MANAGER_INFO), PMAServerManagerInfo.Serialize());
        }

        /// <summary>
        /// Updates the user information.
        /// </summary>
        public void UpdateUserInformation()
        {
            if (PMAUsers.ListPMAUserInfo != null)
            {
                File.WriteAllText(Path.Combine(CurrentAppConfigDir, PMAUsers.PMA_USERS_FILE), PMAUsers.Serialize());
            }
        }
        #endregion


        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="PMAConfigManager"/> class.
        /// </summary>
        private PMAConfigManager()
        {
            InitilizeFTPObject();
            InitilizeSMTPObject();
            InitilizeSystemAnalyzerObject();
            InitilizeFlagInfo();
            InitilizeLoggerObject();
            InitilizePMAObject();
            InitilizeUsers();
            InitilizeServerManagerInfo();
        }


        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the get config manager instance.
        /// </summary>
        /// <value>The get config manager instance.</value>
        public static PMAConfigManager GetConfigManagerInstance
        {
            get
            {
                if (pmaConfigManager == null)
                    pmaConfigManager = new PMAConfigManager();
                return pmaConfigManager;
            }
        }


    }
}
