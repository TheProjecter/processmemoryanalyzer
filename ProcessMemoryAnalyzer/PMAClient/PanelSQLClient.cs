﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMA.Client
{
    public partial class PanelSQLClient : UserControl, IUIManager
    {
        public PanelSQLClient()
        {
            InitializeComponent();
        }

        #region IUIManager Members

        public void UpdateUI()
        {
            
        }

        public void UpdateConfig()
        {
            
        }

        public bool CauseValidation()
        {
            return true;
        }

        #endregion
    }
}
