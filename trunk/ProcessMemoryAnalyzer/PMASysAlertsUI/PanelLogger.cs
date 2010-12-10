using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.ConfigManager;
using PMA.Utils.Logger;
using System.IO;

namespace PMASysAlertsUI
{
    public partial class PanelLogger : UserControl, IUIConfigManager
    {

        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;

        const string LEVEL_ERROR = "ERROR";
        const string LEVEL_DEBUG = "DEBUG";
        const string LEVEL_OFF = "OFF";


        private string defaultLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "\\log", "PMALog.txt");

        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelLogger"/> class.
        /// </summary>
        public PanelLogger()
        {
            InitializeComponent();
            InitilizeControls();
        }

        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initilizes the controls.
        /// </summary>
        private void InitilizeControls()
        {
            comboBox_logs.Items.Add(LEVEL_OFF);
            comboBox_logs.Items.Add(LEVEL_ERROR);
            comboBox_logs.Items.Add(LEVEL_DEBUG);

            comboBox_logs.SelectedItem = LEVEL_OFF;

            checkBox_UseDefaultPath_CheckedChanged(null, null);

            saveFileDialog_log.AddExtension = true;
            saveFileDialog_log.DefaultExt = "txt";
            saveFileDialog_log.Title = "Save Logs To";
        }

        #region IUIConfigManager Members

        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Updates the UI.
        /// </summary>
        public void UpdateUI()
        {
            textBox_loggerFile.Text = configManager.Logger.LoggerInfo.LoggerFile;

            switch (configManager.Logger.LoggerInfo.Level)
            {
                case EnumLogger.DEBUG :
                    comboBox_logs.SelectedItem = LEVEL_DEBUG;
                    break;
                case EnumLogger.ERROR :
                    comboBox_logs.SelectedItem = LEVEL_ERROR;
                    break;
                case EnumLogger.OFF:
                    comboBox_logs.SelectedItem = LEVEL_OFF;
                    break;
                default : 
                    comboBox_logs.SelectedItem = LEVEL_OFF;
                    break;
            }
        }

        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Updates the config.
        /// </summary>
        public void UpdateConfig()
        {
            configManager.Logger.LoggerInfo.LoggerFile = textBox_loggerFile.Text;
            switch (comboBox_logs.SelectedItem.ToString())
            {
                case LEVEL_DEBUG :
                    configManager.Logger.LoggerInfo.Level = EnumLogger.DEBUG;
                    break;
                case LEVEL_ERROR:
                    configManager.Logger.LoggerInfo.Level = EnumLogger.ERROR;
                    break;
                case LEVEL_OFF:
                    configManager.Logger.LoggerInfo.Level = EnumLogger.OFF;
                    break;
            }
        }

        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Causes the validation.
        /// </summary>
        /// <returns></returns>
        public bool CauseValidation()
        {
            bool result = false;
            if (!File.Exists(textBox_loggerFile.Text))
            {
                try
                {
                    File.Create(textBox_loggerFile.Text);
                    result = true;
                }
                catch(Exception ex)
                {
                    configManager.ErrorMessage.Add(ex.Message);
                    result = false;
                }
            }
            else result = true;

            return result;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the CheckedChanged event of the checkBox_UseDefaultPath control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void checkBox_UseDefaultPath_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_UseDefaultPath.Checked)
            {
                textBox_loggerFile.Text = defaultLogPath;
                textBox_loggerFile.Enabled = false;
                button_saveFile.Enabled = false;
            }
            else
            {
                textBox_loggerFile.Enabled = true;
                button_saveFile.Enabled = true;
            }
        }

        private void button_saveFile_Click(object sender, EventArgs e)
        {
            saveFileDialog_log.ShowDialog();
            textBox_loggerFile.Text = saveFileDialog_log.FileName;
        }
    }
}
