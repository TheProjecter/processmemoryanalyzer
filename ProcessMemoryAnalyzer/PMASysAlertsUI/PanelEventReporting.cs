using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.ConfigManager;
using PMA.Info;
using System.Diagnostics;

namespace PMASysAlertsUI
{
    public partial class PanelEventReporting : UserControl, IUIConfigManager
    {

        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        
        public PanelEventReporting()
        {
            InitializeComponent();
        }

        #region IUIConfigManager Members

        public void UpdateUI()
        {
            dataGridView_CrashReporting.AutoGenerateColumns = false;
            configManager.SystemAnalyzerInfo.ListCrashReportInfo.ForEach(INFO => 
                {
                    dataGridView_CrashReporting.Rows.Add(INFO.LogName, INFO.EventType, INFO.EventSource, INFO.EventMessage);
                });
        }

        public void UpdateConfig()
        {
            List<PMACrashReportInfo> tempList = new List<PMACrashReportInfo>();
            
            PMACrashReportInfo crashReportInfo = null;
            foreach (DataGridViewRow row in dataGridView_CrashReporting.Rows)
            {
                if (row.Index != dataGridView_CrashReporting.Rows.Count - 1)
                {
                    crashReportInfo = new PMACrashReportInfo();
                    if (row.Cells[0].Value == null)
                    {
                        row.Cells[0].Value = "System";
                    }
                    else crashReportInfo.LogName = row.Cells[0].Value.ToString();

                    if (row.Cells[1].Value == null)
                    {
                        row.Cells[1].Value = "Information";
                    }
                    else crashReportInfo.EventType = row.Cells[1].Value.ToString();
                    if (row.Cells[2].Value == null)
                    {
                        crashReportInfo.EventSource = string.Empty;
                    }
                    else crashReportInfo.EventSource = row.Cells[2].Value.ToString();
                    if (row.Cells[3].Value == null)
                    {
                        crashReportInfo.EventMessage = string.Empty;
                    }
                    else crashReportInfo.EventMessage = row.Cells[3].Value.ToString(); ;
                    tempList.Add(crashReportInfo);
                }
            }
            configManager.SystemAnalyzerInfo.ListCrashReportInfo = tempList;

        }

        public bool CauseValidation()
        {
            return true;
        }

        #endregion

       
    }
}
