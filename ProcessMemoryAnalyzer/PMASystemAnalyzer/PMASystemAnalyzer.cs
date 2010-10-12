using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.SystemAnalyzer;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using PMA.ProcessMemoryAnalyzer;


namespace PMA.SystemAnalyzer
{
    public class PMASystemAnalyzer
    {

        public static DriveInfo[] GetSystemDiscs()
        {
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            return driveInfo;            
        }

        public static List<string> GetAllServicesNames()
        {
            List<string> servicenames = (from p in ServiceController.GetServices()
                                         select p.ServiceName).ToList<string>();
            return servicenames;
        }




    }
}
