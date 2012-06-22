using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PMA.Info
{
    public class PMAEventReportInfo
    {

        public string LogName { get; set; } 
        
        public string EventType { get; set; }

        public string EventSource { get; set; }

        public string EventMessage { get; set; }

    }
}
