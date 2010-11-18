using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMASysAlertsUI
{
    public partial class PanelCrashReporting : UserControl, IUIConfigManager
    {
        public PanelCrashReporting()
        {
            InitializeComponent();
        }



        #region IUIConfigManager Members

        public void UpdateUI()
        {
            throw new NotImplementedException();
        }

        public void UpdateConfig()
        {
            throw new NotImplementedException();
        }

        public bool CauseValidation()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
