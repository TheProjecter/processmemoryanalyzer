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
                Memory = process.WorkingSet64;
            }
            else
            {
                return;
            }

        }
        
        [DataMember]
        public int PID { get; set; }

        [DataMember]
        public string ProcessName { get; set; }

        [DataMember]
        public int ThreadCount { get; set; }

        [DataMember]
        public long Memory { get; set; }


    }
}
