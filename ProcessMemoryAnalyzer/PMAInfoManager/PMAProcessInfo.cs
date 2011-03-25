using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace PMA.Info
{
    [DataContract]
    public class PMAProcessInfo
    {

        public PMAProcessInfo()
        {

        }

        public PMAProcessInfo(int pid)
        {
            Process process = Process.GetProcessById(pid);
            if (process != null)
            {
                PID = pid;
                ProcessName = process.ProcessName;
                ThreadCount = process.Threads.Count;
                MemoryKB = process.WorkingSet64 / 1024;
            }
            else
            {
                return;
            }

        }

        [DataMember]
        public string ProcessName { get; set; }

        [DataMember]
        public long MemoryKB { get; set; }
        
        [DataMember]
        public int PID { get; set; }

        [DataMember]
        public int ThreadCount { get; set; }

    }
}
