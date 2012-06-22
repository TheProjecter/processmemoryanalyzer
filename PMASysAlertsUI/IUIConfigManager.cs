using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMASysAlertsUI
{
    internal interface IUIManager 
    {
        void UpdateUI();

        void UpdateConfig();

        bool CauseValidation();
    }
}
