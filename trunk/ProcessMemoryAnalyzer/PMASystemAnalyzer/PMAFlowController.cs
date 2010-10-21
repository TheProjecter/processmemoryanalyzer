using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMA.SystemAnalyzer
{
    public class PMAFlowController
    {
        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;

       
        
        public void RunTask()
        {
            if (configManager.SystemAnalyzerInfo.SetDiscWatch)
            {
                RunDBWatch();
            }
            if (configManager.SystemAnalyzerInfo.SetOptimizeDB && configManager.SystemAnalyzerInfo.IsWebServer)
            {
                RunDBOptimizer();
            }
            if (configManager.SystemAnalyzerInfo.SetPhysicalMemWatch)
            {
                RunPhysicalMemoryWatch();
            }
            if (configManager.SystemAnalyzerInfo.SetServiceWatcher)
            {
                RunServiceWatcher();
            }

        }

        private void RunServiceWatcher()
        {
            throw new NotImplementedException();
        }

        private void RunPhysicalMemoryWatch()
        {
            throw new NotImplementedException();
        }

        private void RunDBOptimizer()
        {
            throw new NotImplementedException();
        }

        private void RunDBWatch()
        {
            throw new NotImplementedException();
        }
    }
}
