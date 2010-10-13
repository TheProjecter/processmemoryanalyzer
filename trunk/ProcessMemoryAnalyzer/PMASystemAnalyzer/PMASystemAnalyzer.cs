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

        public static bool GenerateAlertForDrive(List<string> listDriveLetter, out Dictionary<string,string> dicMessages)
        {
            dicMessages = new Dictionary<string,string>();
            return false;
        }

        public static bool GenerateAlertForServices(List<string> serviceNames, out Dictionary<string, string> dicMessages)
        {
            dicMessages = new Dictionary<string, string>();
            return false;
        }

        public static bool GenerateAlertForPhysicalMemory(out string message)
        {
            message = string.Empty;
            return false;
        }

        public static void OptimizeSessionState(string dbstring)
        {
            
        }


        public static string MessageBodyCreator()
        {
            return null;
        }

        public static void SendMail()
        {

        }

        public static void PostFTPMessage()
        {

        }

    }
}
