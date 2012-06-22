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

       

        //-------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the process.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns></returns>
        public static Process GetProcess(string serviceName)
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
        public static double TotalPhysicalMemoryInKB
        {
            get 
            {
                return (double)new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / (1024);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the total free physical memory in KB.
        /// </summary>
        /// <value>The total free physical memory in KB.</value>
        public static double TotalFreePhysicalMemoryInKB
        {
            get
            {
                return (double)new Microsoft.VisualBasic.Devices.ComputerInfo().AvailablePhysicalMemory / (1024);
            }
        }

      
        //-------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the get service process working set.
        /// </summary>
        /// <value>The get service process working set.</value>
        public static double GetServiceProcessWorkingSetInKB(Process process)
        {
            return process.WorkingSet64/1024;
        }

        /// <summary>
        /// Gets the CPU usage at moment.
        /// </summary>
        /// <returns></returns>
        public static float CPUPercentageUsageAtMoment
        {
            get
            {
                PerformanceCounter cpuCounter;
                cpuCounter = new PerformanceCounter();

                cpuCounter.CategoryName = "Processor";
                cpuCounter.CounterName = "% Processor Time";
                cpuCounter.InstanceName = "_Total";
                cpuCounter.NextValue();

                return cpuCounter.NextValue();
            }

        }

        
        

    }
}
