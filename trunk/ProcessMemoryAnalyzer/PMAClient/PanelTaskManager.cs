using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.Client;
using PMA.ConfigManager.Client;
using PMA.CommunicationAPI;
using PMA.Info;


namespace PMA.Client
{
    public partial class PanelTaskManager : UserControl, IUIManager
    {

        PMAClientConfigManager configManager = PMAClientConfigManager.GetClientConfigurationInstance;

        IPMACommunicationContract proxy;
        string sessionID;

        System.Timers.Timer timer;

        public PanelTaskManager()
        {
            InitializeComponent();
            sessionID = configManager.clientRuntimeInfo.sessionID;
            proxy = configManager.GetConnectionChannel;
            //GridRefreshTimer();
        }

        private void GridRefreshTimer()
        {
            timer = new System.Timers.Timer(10000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(RefreshGridTimerEvent);
            timer.Start();
        }

        void RefreshGridTimerEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            BindGrid();
        }

        #region IUIManager Members

        public void UpdateUI()
        {
            BindGrid();
            BindData();
        }

        private void BindData()
        {
            PMAServerInfo serverInfo = proxy.GetServerInfo(sessionID);
            textBox_CPU.Enabled = false;
            textBox_TotalMemory.Enabled = false;
            textBox_FreeMemory.Enabled = false;

            textBox_CPU.Text = serverInfo.CPUUsage.ToString() + "%";
            textBox_TotalMemory.Text = serverInfo.TotalMemory.ToString() + " MB" ;
            textBox_FreeMemory.Text = serverInfo.FreeMemory.ToString() + " MB";
            
        }

        private void BindGrid()
        {
            dataGridView_TaskManager.DataSource = proxy.GetAllProcessesInfo(sessionID);
            dataGridView_TaskManager.AutoSize = true;
        }

        public void UpdateConfig()
        {
            //throw new NotImplementedException();
        }

        public bool ChangeView()
        {
            return true;
        }

        #endregion

        
    }
}
