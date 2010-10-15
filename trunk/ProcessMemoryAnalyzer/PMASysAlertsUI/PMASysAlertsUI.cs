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
        PanelDatabaseOptimizer panelDatabaseOptimizer = null;
        PanelTransportController panelTransportController = null;
        PanelSMTPSettings panelSMTPSettings = null;
        PanelFTPSettings panelFTPSettings = null;
        PanelHome panelHome = null;
        #endregion

        #region Show Functions For Panels
        private void ShowPanelHome()
        {
            HideAllControls();
            panelHome.Show();
        }


        private void ShowPanelDriveController()
        {
            PANEL = ENUMPanel.PANEL_DRIVE_CONTROLLER;
            panelDriveController.UpdateConfig();
            HideAllControls();
            panelDriveController.Show();
        }

        private void ShowPanelPhyMemWatcher()
        {
            PANEL = ENUMPanel.PANEL_PHY_MEM_WATCHER;
            panelPhyMemController.UpdateConfig();
            HideAllControls();
            panelPhyMemController.Show();
        }

        private void ShowPanelServiceWatcher()
        {
            PANEL = ENUMPanel.PANEL_SERVICE_WATCHER;
            panelServiceWatcher.UpdateConfig();
            HideAllControls();
            panelServiceWatcher.Show();
        }

        private void ShowPanelDatabaseOptimizer()
        {
            PANEL = ENUMPanel.PANEL_DATABASE_OPTIMIZER;
            panelDatabaseOptimizer.Show();
            HideAllControls();
            panelDatabaseOptimizer.Show();
        }

        private void ShowPanelTransportController()
        {
            PANEL = ENUMPanel.PANEL_TRANSPORT_CONTROLLER;
            panelTransportController.UpdateConfig();
            HideAllControls();
            panelTransportController.Show();
        }

        private void ShowPanelSMTPSettings()
        {
            PANEL = ENUMPanel.PANEL_SMTP_SETTINGS;
            panelSMTPSettings.Show();
            HideAllControls();
            panelSMTPSettings.Show();
        }

        private void ShowPanelFTPSettings()
        {
            PANEL = ENUMPanel.PANEL_FTP_SETTINGS;
            panelFTPSettings.UpdateConfig();
            HideAllControls();
            panelFTPSettings.Show();
        }
        #endregion

        #region Initilize Form

        public PMASysAlertsUI()
        {
            InitializeComponent();
            InitializeAllPanels();
            ShowPanelHome();

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

            panelDatabaseOptimizer = new PanelDatabaseOptimizer();
            panel_MainContainer.Controls.Add(panelDatabaseOptimizer);

            panelTransportController = new PanelTransportController();
            panel_MainContainer.Controls.Add(panelTransportController);

            panelSMTPSettings = new PanelSMTPSettings();
            panel_MainContainer.Controls.Add(panelSMTPSettings);

            panelFTPSettings = new PanelFTPSettings();
            panel_MainContainer.Controls.Add(panelFTPSettings);

            HideAllControls();

            ChangeCursorStyle();

            
        }

        public void CauseValidation()
        {
            
            switch (PANEL)
            {
                case ENUMPanel.PANEL_DATABASE_OPTIMIZER:
                    //panelDatabaseOptimizer.CauseValidation();
                    break;
                case ENUMPanel.PANEL_DRIVE_CONTROLLER:
                    //panelDriveController.CauseValidation();
                    break;
                case ENUMPanel.PANEL_FTP_SETTINGS:
                    //panelFTPSettings.CauseValidation();
                    break;
                case ENUMPanel.PANEL_HOME:
                    //panelHome.CauseValidation();
                    break;
                case ENUMPanel.PANEL_PHY_MEM_WATCHER:
                    //panelPhyMemController.CauseValidation();
                    break;
                case ENUMPanel.PANEL_SERVICE_WATCHER:
                    //panelServiceWatcher.CauseValidation();
                    break;
                case ENUMPanel.PANEL_SMTP_SETTINGS:
                    //panelSMTPSettings.CauseValidation();
                    break;
                case ENUMPanel.PANEL_TRANSPORT_CONTROLLER:
                    //panelTransportController.CauseValidation();
                    break;
            }
            
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

        #region Events
        private void stopServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
        private void label_Home_Click(object sender, EventArgs e)
        {
            ShowPanelHome();
        }

        private void label_Drives_Click(object sender, EventArgs e)
        {
            ShowPanelDriveController();
        }

        private void label_Service_Click(object sender, EventArgs e)
        {
            ShowPanelServiceWatcher();
        }

        private void label_PhysicalMemory_Click(object sender, EventArgs e)
        {
            ShowPanelPhyMemWatcher();
        }

        private void label_DatabaseOptimizer_Click(object sender, EventArgs e)
        {
            ShowPanelDatabaseOptimizer();
        }

        private void label_Transport_Click(object sender, EventArgs e)
        {
            ShowPanelTransportController();
        }

        private void sMTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanelSMTPSettings();
        }

        private void fTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanelFTPSettings();
        }
        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }


    }
}
