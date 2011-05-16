using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.Info;
using PMA.ConfigManager.Client;
using PMA.CommunicationAPI;


namespace PMA.Client
{
    public partial class PMAClientUI : Form
    {

        ENUMPanel PANEL;

        PMAClientConfigManager configManager = PMAClientConfigManager.GetClientConfigurationInstance;

        PanelExecuteCommand panelExecuteCommand = null;
        PanelSQLClient panelSQLClient = null;
        PanelServicesHandler panelServiceHandler = null;
        PanelTaskManager panelTaskManager = null;

        string sessionID;

        IPMACommunicationContract proxy;

        System.Timers.Timer timer;

        LoginForm loginForm;

        delegate void ServerClock();

        ServerClock serverClock;

        public PMAClientUI()
        {
            InitializeComponent();
        }

        private bool CauseValidation()
        {
            bool result = false;
            configManager.ErrorMessage.Clear();
            switch (PANEL)
            {
                case ENUMPanel.PANEL_ACTION_HANDLER:
                    result = panelExecuteCommand.ChangeView();
                    break;
                case ENUMPanel.PANEL_SERVICES_HANDLER:
                    result = panelServiceHandler.ChangeView();
                    break;
                case ENUMPanel.PANEL_SQL_CLIENT:
                    result = panelSQLClient.ChangeView();
                    break;
                case ENUMPanel.PANEL_TASK_MANAGER:
                    result = panelTaskManager.ChangeView();
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }

        private void UpdateConfig(ENUMPanel enumPanel)
        {

            switch (enumPanel)
            {
                case ENUMPanel.PANEL_ACTION_HANDLER:
                    panelExecuteCommand.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_SERVICES_HANDLER:
                    panelServiceHandler.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_SQL_CLIENT:
                    panelSQLClient.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_TASK_MANAGER:
                    panelTaskManager.UpdateConfig();
                    break;
            }

        }

        private void ShowPanel(ENUMPanel enumPanel)
        {
            PANEL = enumPanel;
            switch (enumPanel)
            {
                case ENUMPanel.PANEL_ACTION_HANDLER:
                    HideAllControls();
                    panelExecuteCommand.Show();
                    break;
                case ENUMPanel.PANEL_SERVICES_HANDLER:
                    HideAllControls();
                    panelServiceHandler.Show();
                    break;
                case ENUMPanel.PANEL_SQL_CLIENT:
                    HideAllControls();
                    panelSQLClient.Show();
                    break;
                case ENUMPanel.PANEL_TASK_MANAGER:
                    HideAllControls();
                    panelTaskManager.Show();
                    break;
            }

        }


        private void InitilizeUI()
        {
            proxy = configManager.GetConnectionChannel;
            sessionID = configManager.clientRuntimeInfo.sessionID;
            InitializeAllPanels();
            HideAllControls();
            LoadConfigs();
            ChangeCursorStyle();
            DisableLeftMenu();
            SetAccessibilityForUser();
            InitializeServerClock();
            label_TaskManager.Focus();
            ShowPanel(ENUMPanel.PANEL_TASK_MANAGER);
        }

        
        private void SetAccessibilityForUser()
        {
            if (configManager.clientRuntimeInfo.UserInfo != null)
            {
                label_Actions.Enabled = configManager.clientRuntimeInfo.UserInfo.IsActionUser;
                dateTimePicker_ServerTime.Enabled = configManager.clientRuntimeInfo.UserInfo.IsActionUser;
                button_SetServerTime.Enabled = configManager.clientRuntimeInfo.UserInfo.IsActionUser;
                label_Services.Enabled = configManager.clientRuntimeInfo.UserInfo.IsServiceUser;
                label_SQL.Enabled = configManager.clientRuntimeInfo.UserInfo.IsSQLUser;
                label_TaskManager.Enabled = true;
            }
        }

        private void InitializeAllPanels()
        {
            panelExecuteCommand = new PanelExecuteCommand();
            panel_MainContainer.Controls.Add(panelExecuteCommand);

            panelSQLClient = new PanelSQLClient();
            panel_MainContainer.Controls.Add(panelSQLClient);

            panelServiceHandler = new PanelServicesHandler();
            panel_MainContainer.Controls.Add(panelServiceHandler);

            panelTaskManager = new PanelTaskManager();
            panel_MainContainer.Controls.Add(panelTaskManager);

        }

      
        private void InitializeServerClock()
        {
            GetDateTime();
            serverClock = new ServerClock(GetDateTime);
            timer = new System.Timers.Timer();
            timer.Interval = 10000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            dateTimePicker_ServerTime.Invoke(serverClock);
        }

        private void GetDateTime()
        {
            DateTime dateTime = proxy.GetServerDateTime(sessionID);
            dateTimePicker_ServerTime.Value = dateTime;
        }


      

        private void LoadConfigs()
        {
            panelServiceHandler.UpdateUI();
            panelExecuteCommand.UpdateUI();
            panelSQLClient.UpdateUI();
            panelTaskManager.UpdateUI();
        }

        private void HideAllControls()
        {
            foreach (Control control in panel_MainContainer.Controls)
            {
                control.Hide();
            }
        }


        private void PMAClientUI_Shown(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            loginForm = new LoginForm();
            loginForm.ShowDialog(this);
            if (configManager.clientRuntimeInfo.sessionID != null)
            {
                InitilizeUI();
            }
            loginForm.Dispose();
        }


        private void ChangeCursorStyle()
        {
            foreach (Control control in tableLayoutPanel_LeftMenu.Controls)
            {
                if (control is Label)
                {
                    Label label = control as Label;
                    label.Cursor = Cursors.Hand;
                }
            }
        }

        private void DisableLeftMenu()
        {
            foreach (Control control in tableLayoutPanel_LeftMenu.Controls)
            {
                if (control is Label)
                {
                    Label label = control as Label;
                    label.Enabled = false;
                }
                else if (control is Button)
                {
                    Button button = control as Button;
                    button.Enabled = false;
                }
                else if (control is DateTimePicker)
                {
                    DateTimePicker dtPicker = control as DateTimePicker;
                    dtPicker.Enabled = false;
                }
            }
        }

        private void label_SQL_Click(object sender, EventArgs e)
        {
            label_SQL.Focus();
            ChangePanel(ENUMPanel.PANEL_SQL_CLIENT);
        }

        private void label_Services_Click(object sender, EventArgs e)
        {
            label_Services.Focus();
            ChangePanel(ENUMPanel.PANEL_SERVICES_HANDLER);
        }

        private void label_Actions_Click(object sender, EventArgs e)
        {
            label_Actions.Focus();
            ChangePanel(ENUMPanel.PANEL_ACTION_HANDLER);
        }

        private void label_TaskManager_Click(object sender, EventArgs e)
        {
            label_TaskManager.Focus();
            ChangePanel(ENUMPanel.PANEL_TASK_MANAGER);
        }

        private void ChangePanel(ENUMPanel panel)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(panel);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout();
            DisableLeftMenu();
            ShowLoginForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Logout()
        {
            if (configManager.GetConnectionChannel != null)
            {
                ClearRuntimeInfo();
                configManager.GetConnectionChannel.LogoutSession(configManager.clientRuntimeInfo.sessionID);
                configManager.CloseConnectionChannel();
                configManager.SaveConfiguration();
            }
        }

        private void ClearRuntimeInfo()
        {
            configManager.clientRuntimeInfo.sessionID = string.Empty;
            configManager.clientRuntimeInfo.IsUserLoggedIn = false;
            configManager.clientRuntimeInfo.UserInfo = null;
        }

       
        private void PMAClientUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logout();
        }

        private void button_SetServerTime_Click(object sender, EventArgs e)
        {
            if (sessionID != null)
            {
                if (proxy.SetServerDateTime(dateTimePicker_ServerTime.Value, sessionID))
                {
                    MessageBox.Show(this,"Server time is setted succesfully");
                }
            }
        }

        

          
        
        
    }
}
