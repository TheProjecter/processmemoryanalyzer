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

            System.Threading.Thread th = new System.Threading.Thread(EvenLogTask);
            th.IsBackground = true;
            th.Name = "EventMonitor";
            th.Start();
            th.Join();
        }

        private static void EvenLogTask()
        {
            try
            {
                PMAEventReporting crashReporting = new PMAEventReporting();
                crashReporting.SystemEventListener();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
