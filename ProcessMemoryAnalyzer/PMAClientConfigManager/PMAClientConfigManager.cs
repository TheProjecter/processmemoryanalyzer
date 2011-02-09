using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PMA.Info;
using System.ServiceModel;
using System.ServiceModel.Channels;
using PMA.CommunicationAPI;

namespace PMA.ConfigManager.Client
{
    public class PMAClientConfigManager
    {

        private static PMAClientConfigManager _clientConfigurationManager;

        public PMAClientInfo clientInfo { get; set; }

        public PMAClientRuntimeInfo clientRuntimeInfo { get; set; }

        public List<string> _errorMessage;

        private IPMACommunicationContract _proxy = null;


        public IPMACommunicationContract GetConnectionChannel
        {
            get
            {
                string baseAddress = "http://localhost:8585/PMA.CommunicationAPI.PMACommunicationAPI";
                try
                {
                    ChannelFactory<IPMACommunicationContract> factory = new ChannelFactory<IPMACommunicationContract>
                        (new BasicHttpBinding(),
                        new EndpointAddress(baseAddress));
                    _proxy = factory.CreateChannel();
                }
                catch (Exception ex)
                {
                    _errorMessage.Add(ex.Message);
                }
                return _proxy;
            }
        }

        public void CloseConnectionChannel()
        {
            if (_proxy != null)
            {
                ((IClientChannel)_proxy).Close();
                ((IClientChannel)_proxy).Dispose();
                _proxy = null;
            }
        }
        
        private PMAClientConfigManager()
        {
            InitilizeClientInfo();
            InitilizeClientRuntimeInfo();
        }

        private void InitilizeClientInfo()
        {
            //if (clientInfo == null)
            //{
            //    if (File.Exists(Path.Combine(CurrentAppConfigDir, PMAUsers.PMA_USERS_FILE)))
            //    {
            //        PMAUsers = PMAUsers.Deserialize(File.ReadAllText(Path.Combine(CurrentAppConfigDir, PMAUsers.PMA_USERS_FILE)));
            //    }
            //    else
            //    {
            //        PMAUsers = new PMAUsers { ListPMAUserInfo = new List<PMAUserInfo>() };
            //    }
            //}
        }

        

        private void InitilizeClientRuntimeInfo()
        {
            clientRuntimeInfo = new PMAClientRuntimeInfo();
            clientRuntimeInfo.UserInfo = new PMAUserInfo();
        }

        /// <summary>
        /// Gets the get client configuration instance.
        /// </summary>
        /// <value>The get client configuration instance.</value>
        public static PMAClientConfigManager GetClientConfigurationInstance
        {
            get
            {
                if (_clientConfigurationManager == null)
                {
                    _clientConfigurationManager = new PMAClientConfigManager();
                    return _clientConfigurationManager;
                }
                else return _clientConfigurationManager;
            }          
        }


        public void SaveConfiguration()
        {
          //  File.WriteAllText(Path.Combine(CurrentAppConfigDir, FTPInfo.FTP_INFO_FILE), FtpInfo.Serialize());
        }


        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
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


        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Clears the error message.
        /// </summary>
        public void ClearErrorMessage()
        {
            ErrorMessage.Clear();
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
            foreach (string message in ErrorMessage)
            {
                sb.AppendLine(message);
            }
            return sb.ToString();
        }

    }
}
