using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.Info;
using PMA.ConfigManager.Client;
using PMA.CommunicationAPI;
using System.ServiceProcess;


namespace PMA.Client
{
    public partial class PanelServicesHandler : UserControl, IUIManager
    {

        PMAClientConfigManager configManager = PMAClientConfigManager.GetClientConfigurationInstance;
        string sessionID;
        IPMACommunicationContract proxy;
        
        public PanelServicesHandler()
        {
            InitializeComponent();

            sessionID = configManager.clientRuntimeInfo.sessionID;
            proxy = configManager.GetConnectionChannel;
        }

        #region IUIManager Members

        public void UpdateUI()
        {
            BindGrid();
            
        }

        private void BindGrid()
        {
            Dictionary<string, ServiceControllerStatus> availableService = proxy.GetAvailableServices(sessionID);
            dataGridView_Services.Rows.Clear();
            DataGridViewRow row = null;
            //int rowCount;
            foreach (string service in availableService.Keys)
            {
                row = dataGridView_Services.Rows[dataGridView_Services.Rows.Add()];
                row.Cells["serviceName"].Value = service;
                row.Cells["serviceStatus"].Value = availableService[service].ToString();
                row.Cells["serviceAction"].Value = new List<string> { "START", "STOP", "RESTART" };
            }
        }

        public void UpdateConfig()
        {
            // no use here            
        }

        public bool CauseValidation()
        {
            return true;
        }

        #endregion

        private void dataGridView_Services_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }
    }
}
