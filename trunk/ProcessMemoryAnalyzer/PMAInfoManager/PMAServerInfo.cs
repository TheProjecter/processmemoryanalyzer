using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PMA.Info
{
    [DataContract]
    public class PMAServerInfo
    {

        [DataMember]
        public float CPUUsage { get; set; }

        [DataMember]
        public double TotalMemory { get; set; }

        [DataMember]
        public double FreeMemory { get; set; }

    }
}
