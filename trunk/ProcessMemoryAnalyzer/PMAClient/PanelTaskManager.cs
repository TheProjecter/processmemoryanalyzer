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

        List<PMAProcessInfo> listProcessInfoCached = null;
        
        List<PMAProcessInfo> listProcessInfo = null;

        IPMACommunicationContract proxy;
        string sessionID;

        System.Timers.Timer timer;

        delegate void delegateRefreshControls();

        public PanelTaskManager()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(10000);
            sessionID = configManager.clientRuntimeInfo.sessionID;
            proxy = configManager.GetConnectionChannel;

            if (configManager.clientRuntimeInfo.UserInfo.IsTaskManagerAdminUser)
            {
                dataGridView_TaskManager.ContextMenuStrip = new ContextMenuStrip();
                dataGridView_TaskManager.ContextMenuStrip.Items.Add("Kill Process");
                dataGridView_TaskManager.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridView_TaskManager_RowHeaderMouseClick);
            }
        }

        void dataGridView_TaskManager_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                dataGridView_TaskManager.ContextMenuStrip.Show(e.X, e.Y);
            }
        }

     
       
        private void GridRefreshTimer()
        {
            if (!timer.Enabled)
            {
                timer.Elapsed += new System.Timers.ElapsedEventHandler(RefreshGridTimerEvent);
                timer.Start();
            }
        }

        void RefreshGridTimerEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            delegateRefreshControls refreshGrid = new delegateRefreshControls(BindGrid);
            dataGridView_TaskManager.BeginInvoke(refreshGrid);
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
           
            label_CPUUsageValue.Text = serverInfo.CPUUsage.ToString() + "%";
            label_MemoryValue.Text = serverInfo.TotalMemory.ToString() + " MB" ;
            label_FreeMemoryValue.Text = serverInfo.FreeMemory.ToString() + " MB";
            
        }

        private void BindGrid()
        {
            listProcessInfoCached = proxy.GetAllProcessesInfo(sessionID);
            if (textBox_Search.Text.Trim() == string.Empty)
            {
                listProcessInfo = (from processInfo in listProcessInfoCached
                                   where processInfo.ProcessName.Contains(textBox_Search.Text)
                                   select processInfo).ToList<PMAProcessInfo>();
            }

            dataGridView_TaskManager.DataSource = listProcessInfo;
            dataGridView_TaskManager.AutoSize = true;
        }

        public void UpdateConfig()
        {
            //throw new NotImplementedException();
        }

        public bool ChangeView()
        {
            if (timer != null)
            {
                timer.Stop();
            }
            return true;
        }

        #endregion

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Search.Text.Trim() != string.Empty)
            {
                listProcessInfo = (from processInfo in listProcessInfoCached
                                   where processInfo.ProcessName.ToLower().Contains(textBox_Search.Text.ToLower())
                                   select processInfo).ToList<PMAProcessInfo>();
               
            }
            else
            {
                listProcessInfo = proxy.GetAllProcessesInfo(sessionID);
            }
            dataGridView_TaskManager.DataSource = listProcessInfo;
          
        }

        
        private void checkBox_Refresh_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Refresh.Checked)
            {
                if (!timer.Enabled)
                {
                    timer.Start();
                }
            }
            else
            {
                if (timer.Enabled)
                {
                    timer.Stop();
                }
            }
        }

        
    }
}
