using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.SystemAnalyzer;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using PMA.ProcessMemoryAnalyzer;
using PMA.Utils.ftp;
using PMA.Utils.smtp;


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

        
        #region DriveAlert 
        public static bool GenerateDriveSpaceAlert(string drivename, int alertLevel)
        {
            DriveInfo driveInfo = new DriveInfo(drivename);
            if ((driveInfo.TotalFreeSpace / driveInfo.TotalSize) / 100 < alertLevel)
            {
                return true;
            }
            else return false;
        }
        #endregion 

        


    }
}
