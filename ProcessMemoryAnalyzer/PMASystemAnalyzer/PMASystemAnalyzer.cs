using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.ConfigManager;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using PMA.ProcessMemoryAnalyzer;
using PMA.Utils.ftp;
using PMA.Utils.smtp;



namespace PMA.ConfigManager
{
    
    public class PMASystemAnalyzer
    {


        private const string SERVICE_NAME = "PMAAlertService";

        
        
        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the system discs.
        /// </summary>
        /// <returns></returns>
        public static DriveInfo[] GetSystemDiscs()
        {
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            return driveInfo;            
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all services names.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllServicesNames()
        {
            List<string> servicenames = (from p in ServiceController.GetServices()
                                         select p.ServiceName).ToList<string>();
            return servicenames;
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Starts the service.
        /// </summary>
        public static string StartService()
        {
            ServiceController service = null;
            Process process = new Process();
            string serviceMessage = string.Empty;
            try
            {
                if (Environment.OSVersion.Version.Major > 5)
                {
                    process.StartInfo = new ProcessStartInfo("net","start PMAAlertService");
                    process.StartInfo.Verb = "runas";
                    process.Start();
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                    {
                        serviceMessage = "There was an error while starting servcie";
                    }
                    else serviceMessage = "Service is Started Successfully";

                }
                else
                {
                    service = new ServiceController(SERVICE_NAME);
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running,new TimeSpan(0,0,15));
                    serviceMessage = "Service Started Succesfully";    
                }
                return serviceMessage;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Stops the service.
        /// </summary>
        public static string StopService()
        {
            ServiceController service = null;
            Process process = new Process();
            string serviceMessage = string.Empty;
            try
            {
                if (Environment.OSVersion.Version.Major > 5)
                {
                    process.StartInfo = new ProcessStartInfo("net", "stop PMAAlertService");
                    process.StartInfo.Verb = "runas";
                    process.Start();
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                    {
                        serviceMessage = "There was an error while stoping servcie";
                    }
                    else serviceMessage = "Service is stopped Successfully";

                }
                else
                {
                    service = new ServiceController(SERVICE_NAME);
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 15));
                    serviceMessage = "Service stopped Succesfully";
                }
                return serviceMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            

            
        }

        
        #region DriveAlert 
        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Generates the drive space alert.
        /// </summary>
        /// <param name="listDriveNames">The list drive names.</param>
        /// <param name="alertLevel">The alert level.</param>
        /// <param name="listMessage">The list message.</param>
        /// <returns></returns>
        public static bool GenerateDriveSpaceAlert(List<string> listDriveNames, int alertLevel, out List<string> listMessage)
        {
            bool flag = false;
            
            DriveInfo driveInfo = null;
            listMessage = new List<string>();
            foreach (string driveName in listDriveNames)
            {
                driveInfo = new DriveInfo(driveName);
                if (((decimal)driveInfo.TotalFreeSpace / (decimal)driveInfo.TotalSize) * 100 < alertLevel)
                {
                    listMessage.Add("Drive " + driveName + " Free Space is less then " + alertLevel + "%");
                    flag = true;
                }
            }

            return flag;
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Generates the phy mem alert.
        /// </summary>
        /// <param name="alertlevel">The alertlevel.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static bool GeneratePhyMemAlert(int alertlevel, out string message)
        {
            if (((decimal)PMAServiceProcessController.TotalFreePhysicalMemoryInKB / (decimal)PMAServiceProcessController.TotalPhysicalMemoryInKB) * 100 < alertlevel)
            {
                message = "Physical Memory Free Space is less then " + alertlevel + "%";
                return true;
            }
            else
            {
                message = string.Empty;
                return false;
            }
        }


        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Generates the service memory alert.
        /// </summary>
        /// <param name="listServicesName">Name of the list services.</param>
        /// <param name="alertLevel">The alert level.</param>
        /// <param name="listMessage">The list message.</param>
        /// <param name="setStoppedServiceAlert">if set to <c>true</c> [set stopped service alert].</param>
        /// <returns></returns>
        public static bool GenerateServiceMemoryAlert(List<string> listServicesName, int alertLevel, out List<string> listMessage, bool setStoppedServiceAlert)
        {

            bool flag = false;
            
            ServiceController[] allSystemServices = ServiceController.GetServices();

            List<ServiceController> selectedServices = (from service in allSystemServices
                                                        where listServicesName.Contains(service.ServiceName)
                                                        select service).ToList<ServiceController>();

            listMessage = new List<string>();
            foreach(ServiceController service in selectedServices)
            {
                if (setStoppedServiceAlert && service.Status == ServiceControllerStatus.Stopped)
                {
                    flag = true;
                    listMessage.Add("Service " + service.ServiceName + " is stopped");
                }
                Process serviceProcess = PMAServiceProcessController.GetProcess(service.ServiceName);
                if (((decimal)PMAServiceProcessController.GetServiceProcessWorkingSetInKB(serviceProcess) / (decimal)PMAServiceProcessController.TotalPhysicalMemoryInKB) * 100 > alertLevel)
                {
                    flag = true;
                    listMessage.Add("Service " + service.ServiceName + " is growing more then " + alertLevel + "% of available physical memory of " + (decimal)PMAServiceProcessController.TotalPhysicalMemoryInKB/1024 + " MB");
                }
            }

            return flag;
            
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Resets the IIS.
        /// </summary>
        public static void ResetIIS()
        {
            ProcessStartInfo pInfo = new ProcessStartInfo(Environment.SystemDirectory + "\\iisreset.exe");
            if (Environment.OSVersion.Version.Major > 5)
            {
                pInfo.Verb = "runas";
            }
            Process.Start(pInfo);
        }
        #endregion 

        


    }
}
