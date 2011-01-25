using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.Utils.ftp;
using PMA.Utils.smtp;
using PMA.ConfigManager;
using PMA.SystemAnalyzer;

namespace PMASysAlertsUI
{
    
        
    public partial class PMASysAlertsUI : Form
    {

               
        ENUMPanel PANEL;
        
        PMAConfigManager configManager = null;
        
        #region Panels Declaration 
        PanelDriveController panelDriveController = null;
        PanelPhyMemWatcher panelPhyMemController = null;
        PanelServiceWatcher panelServiceWatcher = null;
        PanelDatabaseWatcher panelDatabaseWatcher = null;
        PanelTransportController panelTransportController = null;
        PanelSMTPSettings panelSMTPSettings = null;
        PanelFTPSettings panelFTPSettings = null;
        PanelHome panelHome = null;
        PanelLogger panelLogger = null;
        PanelMemoryAnalyzer panelMemoryAnalyzer = null;
        PanelEventReporting panelCrashReporting = null;
        PanelSystemInformation panelSystemInformation = null;
        PanelUserControl panelUserController = null;
        PanelActionController panelActionController = null;
        PanelSQLController panelSQLContoller = null;
        PanelServiceController panelServiceController = null;

        #endregion


        private bool CauseValidation()
        {
            bool result = false;
            configManager.ErrorMessage.Clear();
            switch (PANEL)
            {
                case ENUMPanel.PANEL_DATABASE_WATCHER:
                    result = panelDatabaseWatcher.CauseValidation();
                    break;
                case ENUMPanel.PANEL_DRIVE_CONTROLLER:
                    result = panelDriveController.CauseValidation();
                    break;
                case ENUMPanel.PANEL_FTP_SETTINGS:
                    result = panelFTPSettings.CauseValidation();
                    break;
                case ENUMPanel.PANEL_HOME:
                    result = panelHome.CauseValidation();
                    break;
                case ENUMPanel.PANEL_PHY_MEM_WATCHER:
                    result = panelPhyMemController.CauseValidation();
                    break;
                case ENUMPanel.PANEL_SERVICE_WATCHER:
                    result = panelServiceWatcher.CauseValidation();
                    break;
                case ENUMPanel.PANEL_SMTP_SETTINGS:
                    result = panelSMTPSettings.CauseValidation();
                    break;
                case ENUMPanel.PANEL_TRANSPORT_CONTROLLER:
                    result = panelTransportController.CauseValidation();
                    break;
                case ENUMPanel.PANEL_LOGGER :
                    result = panelLogger.CauseValidation();
                    break;
                case ENUMPanel.PANEL_MEMEORY_ANALYZER :
                    result = panelMemoryAnalyzer.CauseValidation();
                    break;
                case ENUMPanel.PANEL_EVENT_REPORTING :
                    result = panelCrashReporting.CauseValidation();
                    break;
                case ENUMPanel.PANEL_SYSTEM_INFORMATION:
                    result = panelSystemInformation.CauseValidation();
                    break;
                case ENUMPanel.PANEL_USER_CONTROLLER :
                    result = panelUserController.CauseValidation();
                    break;
                case ENUMPanel.PANEL_ACTION_CONTROLLER :
                    result = panelActionController.CauseValidation();
                    break;
                case ENUMPanel.PANEL_SQL_CONTROLLER :
                    result = panelSQLContoller.CauseValidation();
                    break;
                case ENUMPanel.PANEL_SERVICE_CONTROLLER:
                    result = panelServiceController.CauseValidation();
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
                case ENUMPanel.PANEL_DATABASE_WATCHER:
                    panelDatabaseWatcher.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_DRIVE_CONTROLLER:
                    panelDriveController.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_FTP_SETTINGS:
                    panelFTPSettings.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_HOME:
                    panelHome.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_PHY_MEM_WATCHER:
                    panelPhyMemController.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_SERVICE_WATCHER:
                    panelServiceWatcher.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_SMTP_SETTINGS:
                    panelSMTPSettings.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_TRANSPORT_CONTROLLER:
                    panelTransportController.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_LOGGER:
                    panelLogger.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_MEMEORY_ANALYZER :
                    panelMemoryAnalyzer.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_EVENT_REPORTING :
                    panelCrashReporting.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_SYSTEM_INFORMATION:
                    panelSystemInformation.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_USER_CONTROLLER:
                    panelUserController.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_ACTION_CONTROLLER:
                    panelActionController.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_SQL_CONTROLLER:
                    panelSQLContoller.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_SERVICE_CONTROLLER:
                    panelServiceController.UpdateConfig();
                    break;
            }

        }

        private void ShowPanel(ENUMPanel enumPanel)
        {
            PANEL = enumPanel;
            switch (enumPanel)
            {
                case ENUMPanel.PANEL_DATABASE_WATCHER:
                    HideAllControls();
                    panelDatabaseWatcher.Show();
                    break;
                case ENUMPanel.PANEL_DRIVE_CONTROLLER:
                    HideAllControls();
                    panelDriveController.Show();
                    break;
                case ENUMPanel.PANEL_FTP_SETTINGS:
                    HideAllControls();
                    panelFTPSettings.Show();
                    break;
                case ENUMPanel.PANEL_HOME:
                    HideAllControls();
                    panelHome.Show();
                    break;
                case ENUMPanel.PANEL_PHY_MEM_WATCHER:
                    HideAllControls();
                    panelPhyMemController.Show();
                    break;
                case ENUMPanel.PANEL_SERVICE_WATCHER:
                    HideAllControls();
                    panelServiceWatcher.Show();
                    break;
                case ENUMPanel.PANEL_SMTP_SETTINGS:
                    HideAllControls();
                    panelSMTPSettings.Show();
                    break;
                case ENUMPanel.PANEL_TRANSPORT_CONTROLLER:
                    HideAllControls();
                    panelTransportController.Show();
                    break;
                case ENUMPanel.PANEL_LOGGER:
                    HideAllControls();
                    panelLogger.Show();
                    break;
                case ENUMPanel.PANEL_MEMEORY_ANALYZER :
                    HideAllControls();
                    panelMemoryAnalyzer.Show();
                    break;
                case ENUMPanel.PANEL_EVENT_REPORTING :
                    HideAllControls();
                    panelCrashReporting.Show();
                    break;
                case ENUMPanel.PANEL_SYSTEM_INFORMATION:
                    HideAllControls();
                    panelSystemInformation.Show();
                    break;

                case ENUMPanel.PANEL_USER_CONTROLLER:
                    HideAllControls();
                    panelUserController.Show();
                    break;
                case ENUMPanel.PANEL_ACTION_CONTROLLER:
                    HideAllControls();
                    panelActionController.Show();
                    break;
                case ENUMPanel.PANEL_SQL_CONTROLLER:
                    HideAllControls();
                    panelSQLContoller.Show();
                    break;
                case ENUMPanel.PANEL_SERVICE_CONTROLLER:
                    HideAllControls();
                    panelServiceController.Show();
                    break;
            }

        }


        #region Initilize Form

        public PMASysAlertsUI()
        {
            InitializeComponent();
            InitializeAllPanels();
            ShowPanel(ENUMPanel.PANEL_HOME);
            configManager = PMAConfigManager.GetConfigManagerInstance;
        }

        

        private void InitializeAllPanels()
        {
            panelHome = new PanelHome();
            panel_MainContainer.Controls.Add(panelHome);
            
            panelDriveController = new PanelDriveController();
            panel_MainContainer.Controls.Add(panelDriveController);

            panelPhyMemController = new PanelPhyMemWatcher();
            panel_MainContainer.Controls.Add(panelPhyMemController);

            panelServiceWatcher = new PanelServiceWatcher();
            panel_MainContainer.Controls.Add(panelServiceWatcher);

            panelDatabaseWatcher = new PanelDatabaseWatcher();
            panel_MainContainer.Controls.Add(panelDatabaseWatcher);

            panelTransportController = new PanelTransportController();
            panel_MainContainer.Controls.Add(panelTransportController);

            panelSMTPSettings = new PanelSMTPSettings();
            panel_MainContainer.Controls.Add(panelSMTPSettings);

            panelFTPSettings = new PanelFTPSettings();
            panel_MainContainer.Controls.Add(panelFTPSettings);

            panelLogger = new PanelLogger();
            panel_MainContainer.Controls.Add(panelLogger);

            panelMemoryAnalyzer = new PanelMemoryAnalyzer();
            panel_MainContainer.Controls.Add(panelMemoryAnalyzer);

            panelCrashReporting = new PanelEventReporting();
            panel_MainContainer.Controls.Add(panelCrashReporting);

            panelSystemInformation = new PanelSystemInformation();
            panel_MainContainer.Controls.Add(panelSystemInformation);

            panelUserController = new PanelUserControl();
            panel_MainContainer.Controls.Add(panelUserController);

            panelActionController = new PanelActionController();
            panel_MainContainer.Controls.Add(panelActionController);
            
            panelSQLContoller = new PanelSQLController();
            panel_MainContainer.Controls.Add(panelSQLContoller);
            
            panelServiceController = new PanelServiceController();
            panel_MainContainer.Controls.Add(panelServiceController);

            HideAllControls();

            LoadConfigs();

            ChangeCursorStyle();
        }

        private void LoadConfigs()
        {
            panelHome.UpdateUI();
            panelDriveController.UpdateUI();
            panelPhyMemController.UpdateUI();
            panelServiceWatcher.UpdateUI();
            panelDatabaseWatcher.UpdateUI();
            panelTransportController.UpdateUI();
            panelSMTPSettings.UpdateUI();
            panelFTPSettings.UpdateUI();
            panelLogger.UpdateUI();
            panelMemoryAnalyzer.UpdateUI();
            panelCrashReporting.UpdateUI();
            panelSystemInformation.UpdateUI();

            panelUserController.UpdateUI();
            panelActionController.UpdateUI();
            panelSQLContoller.UpdateUI();
            panelServiceController.UpdateUI();
            
        }


       
        private void HideAllControls()
        {
            foreach (Control control in panel_MainContainer.Controls)
            {
                control.Hide();
            }
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

        #endregion

        #region Butten Events
        

        
        private void label_Home_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_HOME);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
            }
        }

        private void label_Drives_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_DRIVE_CONTROLLER);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
            }
        }

        private void label_Service_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_SERVICE_WATCHER);
            }
            else
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
        }

        private void label_PhysicalMemory_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_PHY_MEM_WATCHER);
            }
            else
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
        }

        private void label_DatabaseWatcher_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_DATABASE_WATCHER);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
            }

        }

        private void label_Transport_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_TRANSPORT_CONTROLLER);
            }
            else
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
        }

        private void sMTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_SMTP_SETTINGS);
            }
            else
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
        }

        private void fTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_FTP_SETTINGS);
            }
            else
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
        }

        private void loggerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_LOGGER);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
            }
        }

        private void systemInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_SYSTEM_INFORMATION);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
            }
        }


        private void label_PMA_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_MEMEORY_ANALYZER);
            }
            else
            {
                MessageBox.Show(this,configManager.GetConsolidatedError("PMA Error"));
            }
        }

        private void label_crash_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_EVENT_REPORTING);
            }
            else
            {
                MessageBox.Show(this,configManager.GetConsolidatedError("Event Setup Error"));
            }
        }

        private void userControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_USER_CONTROLLER);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("Invalid User Info"));
            }
        }

        private void actionControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_ACTION_CONTROLLER);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("Invalid Action"));
            }
        }

        private void sQLContollerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_SQL_CONTROLLER);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("PLEASE Set Correct SQL Controller Information"));
            }
        }

        private void serviceContollerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_SERVICE_CONTROLLER);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("Invalid Service Information "));
            }
        }
        #endregion

        private void stopServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateConfig(PANEL);
            configManager.SaveConfiguration();
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateConfig(PANEL);
            configManager.SaveConfiguration();
            notifyIconSystemAnalyzer.Visible = false;
            Environment.Exit(0);
        }

        private void PMASysAlertsUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateConfig(PANEL);
            configManager.SaveConfiguration();
            notifyIconSystemAnalyzer.Visible = false;
        }

        
        private void startServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateConfig(PANEL);
            configManager.SaveConfiguration();
            MessageBox.Show(PMASystemAnalyzer.StartService());

        }

        private void stopServiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateConfig(PANEL);
            configManager.SaveConfiguration();
            MessageBox.Show(PMASystemAnalyzer.StopService());
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBoxPMAAlerts aboutBox = new AboutBoxPMAAlerts();
            aboutBox.ShowDialog(this);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            WindowState = FormWindowState.Normal;
            this.Show();
            this.Focus();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            this.Visible = false;
            this.Hide();
            notifyIconSystemAnalyzer.ShowBalloonTip(3000);
        }

        private void iISResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PMASystemAnalyzer.ResetIIS();
        }

        private void PMASysAlertsUI_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                Hide();
                notifyIconSystemAnalyzer.ShowBalloonTip(100);
            }
        }

        private void notifyIconSystemAnalyzer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateConfig(PANEL);
            configManager.SaveConfiguration();
            notifyIconSystemAnalyzer.Visible = false;
            Environment.Exit(0);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(PMASystemAnalyzer.ServiceStatus);
        }

       

       
      
       
    }
}
