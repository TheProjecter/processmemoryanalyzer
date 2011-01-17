using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMA.Client
{
    internal interface IUIManager
    {
        void UpdateUI();

        void UpdateConfig();

        bool CauseValidation();
    }
}
