﻿using System;
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

        private static string BASE_ADDRESS = "net.tcp://{0}:{1}/PMA.CommunicationAPI.PMACommunicationAPI";

        private const string CONFIG_DIR = "Config";
        private const string PMA_LOG_DIR = "PMALog";
        private const string PRE_LOADED_SCRITPS = "PreScripts";

        private string _serverName = string.Empty;
        private int _port = 0;

        public PMAClientInfo clientInfo { get; set; }

        public PMAClientRuntimeInfo clientRuntimeInfo { get; set; }

        public List<string> _errorMessage;

        private IPMACommunicationContract _proxy = null;

        public Dictionary<string,string> DicPreLoadedScripts { get; set; } 

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

        public String PreLoadedScriptsDir
        {
            get
            {
                string scriptDir = AppDomain.CurrentDomain.BaseDirectory + "\\" + PRE_LOADED_SCRITPS;
                if (!Directory.Exists(scriptDir))
                {
                    Directory.CreateDirectory(scriptDir);
                }
                return scriptDir;
            }
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

        /// <summary>
        /// Gets the get connection channel.
        /// </summary>
        /// <value>The get connection channel.</value>
        public IPMACommunicationContract GetConnectionChannel
        {
            get
            {
                try
                {
                    if (_proxy == null || !_proxy.VerfiyConnection())
                    {

                        try
                        {
                            if (_serverName == string.Empty || _port == 0)
                            {
                                throw new Exception("ServerName or port is not Specified");
                            }
                            string baseAddress = String.Format(BASE_ADDRESS, _serverName, _port.ToString());
                            NetTcpBinding netTcpBinding = new NetTcpBinding();
                            netTcpBinding.MaxBufferPoolSize = 524288;
                            netTcpBinding.MaxReceivedMessageSize = 2147483600;
                            ChannelFactory<IPMACommunicationContract> factory = new ChannelFactory<IPMACommunicationContract>(netTcpBinding, new EndpointAddress(baseAddress));
                            _proxy = factory.CreateChannel();
                        }
                        catch (Exception ex)
                        {
                            _errorMessage.Add(ex.Message);
                        }
                        return _proxy;
                    }
                    else return _proxy;
                }
                catch 
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Creates the connection channel.
        /// </summary>
        /// <param name="serverName">Name of the server.</param>
        /// <param name="port">The port.</param>
        /// <returns></returns>
        public IPMACommunicationContract CreateConnectionChannel(string serverName, int port)
        {
            _serverName = serverName;
            _port = port;
            return GetConnectionChannel;
        }

        /// <summary>
        /// Closes the connection channel.
        /// </summary>
        public void CloseConnectionChannel()
        {
            if (_proxy != null)
            {
                IClientChannel channel = _proxy as IClientChannel;
                
                if (channel.State == CommunicationState.Faulted)
                {
                    channel.Abort();
                    channel.Dispose();
                }
                else 
                {
                    channel.Close();
                    channel.Dispose();
                }
                
                _proxy = null;
            }
        }
        
        private PMAClientConfigManager()
        {
            InitilizeClientInfo();
            InitilizeClientRuntimeInfo();

            LoadPreLoadedScripts();
        }

        
        private void LoadPreLoadedScripts()
        {
            DicPreLoadedScripts = new Dictionary<string, string>();
            try
            {
                DicPreLoadedScripts.Add("--Select--", string.Empty);
                foreach (string script in Directory.GetFiles(PreLoadedScriptsDir))
                {
                    DicPreLoadedScripts.Add(Path.GetFileNameWithoutExtension(script), script);
                }
            }
            catch (Exception e)
            {
                DicPreLoadedScripts = new Dictionary<string, string>();
            }
        }


        private void InitilizeClientInfo()
        {
            if (clientInfo == null)
            {
                if (File.Exists(Path.Combine(CurrentAppConfigDir, PMAClientInfo.PMA_CLIENT_INFO)))
                {
                    clientInfo = PMAClientInfo.Deserialize(File.ReadAllText(Path.Combine(CurrentAppConfigDir, PMAClientInfo.PMA_CLIENT_INFO)));
                }
                else clientInfo = new PMAClientInfo();
            }
        }

        

        private void InitilizeClientRuntimeInfo()
        {
            clientRuntimeInfo = new PMAClientRuntimeInfo();
            clientRuntimeInfo.UserInfo = new PMAUserInfo();
        }

       


        public void SaveConfiguration()
        {
            if (clientInfo != null)
            {
                File.WriteAllText(Path.Combine(CurrentAppConfigDir, PMAClientInfo.PMA_CLIENT_INFO), clientInfo.Serialize());
            }
        }


      

    }
}
