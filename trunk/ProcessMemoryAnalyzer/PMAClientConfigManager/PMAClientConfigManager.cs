using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PMA.Info;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace PMA.ConfigManager.Client
{
    public class PMAClientConfigManager
    {

        private static PMAClientConfigManager _clientConfigurationManager;

        public PMAClientInfo clientInfo { get; set; }

        public PMAClientRuntimeInfo clientRuntimeInfo { get; set; }


        //public MyContractClient GetConnectionPorxy
        //{
        //    get
        //    {
        //        //Binding wsBinding = new WSHttpBinding();
        //        ////EndpointAddress endpointAddress = new
        //        ////   EndpointAddress("http://localhost:8000/MyService/");
        //        //MyContractClient proxy =
        //        //   new MyContractClient(wsBinding, endpointAddress);
        //        //proxy.MyMethod();
        //        //proxy.Close();

        //    }



        //}
        
        private PMAClientConfigManager()
        {
            InitilizeClientInfo();
            InitilizeClientRuntimeInfo();
        }

        private void InitilizeClientInfo()
        {
            //if (PMAUsers == null)
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

        



    }
}
