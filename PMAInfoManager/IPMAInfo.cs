using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMA.Info
{
    interface IPMAInfo
    {
        string ConfigFile { get; set; }

        string Serialize();

        IPMAInfo Deserialize();
    }
}
