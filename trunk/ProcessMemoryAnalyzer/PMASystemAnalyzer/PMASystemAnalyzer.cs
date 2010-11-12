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
            try
            {
                service = new ServiceController(SERVICE_NAME);
                service.Start();
                return "Service Started Succesfully";
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
            try
            {
                service = new ServiceController(SERVICE_NAME);
                service.Stop();
                return "Service Stopped Succesfully";
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
                    listMessage.Add("Drive " + driveName + " is exceeding set alert level");
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
                message = "Physical Memory cumsumtion is more then set alert level";
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
                    listMessage.Add("Service " + service.ServiceName + " is growing more then alert levels");
                }
            }

            return flag;
            
        }
        #endregion 

        


    }
}
