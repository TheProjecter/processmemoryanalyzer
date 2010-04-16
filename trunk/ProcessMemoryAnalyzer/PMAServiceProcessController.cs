using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ServiceProcess;
using System.Management;
using System.ComponentModel;


namespace PMA.ProcessMemoryAnalyzer
{
    public class PMAServiceProcessController
    {

        private Process _process;

        private static double _totalPageFileSpace;
        private static double _totalPhysicalMemory;
        private static double _totalVirtualMemory;
        private static double _availableVirtualMemory;


        //-------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="PMAServiceProcessController"/> class.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        public PMAServiceProcessController(string serviceName)
        {
            _process = GetProcess(serviceName);
        }

        static PMAServiceProcessController()
        {
            ObjectQuery winQuery = new ObjectQuery("SELECT * FROM Win32_LogicalMemoryConfiguration");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(winQuery);

            foreach (ManagementObject item in searcher.Get())
            {
                _totalPageFileSpace = double.Parse(item["TotalPageFileSpace"].ToString());
                _totalPhysicalMemory = double.Parse(item["TotalPhysicalMemory"].ToString());
                _totalVirtualMemory = double.Parse(item["TotalVirtualMemory"].ToString());
                _availableVirtualMemory = double.Parse(item["AvailableVirtualMemory"].ToString()); 

            }

        }


        //-------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the process.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns></returns>
        private Process GetProcess(string serviceName)
        {
            string query = string.Format("SELECT ProcessId FROM Win32_Service WHERE Name='{0}'", serviceName);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject obj in searcher.Get())
            {
                uint processId = (uint)obj["ProcessId"];
                try
                {
                    return Process.GetProcessById((int)processId);
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }


        //-------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the total physical memory.
        /// </summary>
        /// <value>The total physical memory.</value>
        public static double TotalPhysicalMemory
        {
            get { return _totalPhysicalMemory; }
        }

      
        //-------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the get service process working set.
        /// </summary>
        /// <value>The get service process working set.</value>
        public double GetServiceProcessWorkingSet
        {
            get { return _process.WorkingSet64/1024; }
        }

        
        

    }
}
