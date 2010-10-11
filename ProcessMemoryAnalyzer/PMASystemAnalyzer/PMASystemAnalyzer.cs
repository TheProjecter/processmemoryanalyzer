using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using PMA.ProcessMemoryAnalyzer;
using System.Diagnostics;
using System.IO;

namespace PMA.SystemAnalyzer
{
    public class PMASystemAnalyzer
    {

        public static DriveInfo[] GetSystemDisc()
        {
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            return driveInfo;            
        }


    }
}
