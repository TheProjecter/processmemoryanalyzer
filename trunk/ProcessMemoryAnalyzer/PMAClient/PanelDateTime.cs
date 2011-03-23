using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMA.Client
{
    public partial class PanelDateTime : UserControl, IUIManager
    {
        public PanelDateTime()
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

        public bool ChangeView()
        {
            return true;
        }

        #endregion
    }
}
