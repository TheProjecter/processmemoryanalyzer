using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.ProcessMemoryAnalyzer;
using PMA.ConfigManager;
using PMA.Info;

namespace PMASysAlertsUI
{
    public partial class PanelMemoryAnalyzer : UserControl, IUIManager
    {

        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelMemoryAnalyzer"/> class.
        /// </summary>
        public PanelMemoryAnalyzer()
        {
            InitializeComponent();
        }

        #region IUIConfigManager Members

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Updates the UI.
        /// </summary>
        public void UpdateUI()
        {
            textBox_MachineName.Text = configManager.PMAInfoObj.MachineName;
            checkBox_disposeFiles.Checked = configManager.PMAInfoObj.DisposeLogFile ;
            dateTimePicker_MailTime.Value = configManager.PMAInfoObj.MailingTime;
            numericUpDown_Trigger.Value = configManager.PMAInfoObj.TriggerSeed;
            numericUpDown_ReportInterval.Value = configManager.PMAInfoObj.ReportsIntervalHours;
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Updates the config.
        /// </summary>
        public void UpdateConfig()
        {
            configManager.PMAInfoObj.MachineName = textBox_MachineName.Text;
            configManager.PMAInfoObj.DisposeLogFile = checkBox_disposeFiles.Checked;
            configManager.PMAInfoObj.MailingTime = dateTimePicker_MailTime.Value;
            configManager.PMAInfoObj.TriggerSeed = Decimal.ToInt32(numericUpDown_Trigger.Value);
            configManager.PMAInfoObj.ReportsIntervalHours = Decimal.ToInt32(numericUpDown_ReportInterval.Value);
            configManager.PMAInfoObj.UseFTP = configManager.SystemAnalyzerInfo.SetPostFTP;
            configManager.PMAInfoObj.UseSMTP = configManager.SystemAnalyzerInfo.SetSendMail;
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Causes the validation.
        /// </summary>
        /// <returns></returns>
        public bool CauseValidation()
        {
            bool result = true;
            if (textBox_MachineName.Text == string.Empty)
            {
                result = false;
                configManager.ErrorMessage.Add("Machine Name can't be empty. Putting Machine Name");
                textBox_MachineName.Text = Environment.MachineName;
            }
            if (dateTimePicker_MailTime.Value < DateTime.Now)
            {
                dateTimePicker_MailTime.Value = DateTime.Now.AddHours(Double.Parse(numericUpDown_ReportInterval.Value.ToString()));
                //result = false;
                //configManager.ErrorMessage.Add("Please set a time later then now.");
            }

            return result;
        }

        #endregion

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the button_GetMachineName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button_GetMachineName_Click(object sender, EventArgs e)
        {
            textBox_MachineName.Text = Environment.MachineName;
        }
    }
}
