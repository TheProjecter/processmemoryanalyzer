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
            //PMAFlowController flowController = new PMAFlowController();
            //flowController.RunTask();
            
            PMACrashReporting crshReporting = new PMACrashReporting();
            crshReporting.SystemEventListener();

            
        }
    }
}
