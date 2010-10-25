using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.SystemAnalyzer;

namespace PMASysAlertsTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PMAFlowController flowController = new PMAFlowController();

            for (int i = 0; i < 3; i++)
            {
                flowController.RunTask();
            }
        }
    }
}
