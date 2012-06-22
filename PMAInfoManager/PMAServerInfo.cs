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

        private double _cpuUsages;

        private double _totalMemory;

        private double _freeMemory; 
        
        [DataMember]
        public double CPUUsage 
        { 
            get
            {
                return _cpuUsages ;
            }
            
            set
            {
                _cpuUsages = Math.Round(value, 2);
            }
        }

        [DataMember]
        public double TotalMemory 
        {
            get
            {
                return _totalMemory;
            }
            set
            {
                _totalMemory = Math.Round(value, 2);
            }
        }

        [DataMember]
        public double FreeMemory 
        { 
            get
            {
                return _freeMemory;   
            }
            set
            {
                _freeMemory = Math.Round(value, 2);
            }
        }

    }
}
