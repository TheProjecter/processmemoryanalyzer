using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.ConfigManager;

namespace PMASysAlertsTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PMAFlowController flowController = new PMAFlowController();

            //PMACrashReporting crshReporting = new PMACrashReporting();
            //crshReporting.SystemEventListener();

            flowController.RunTask();
        }
    }
}
