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
using PMA.Utils.Logger;



namespace PMA.ConfigManager
{
    
    public class PMASystemAnalyzer
    {


        private const string SERVICE_NAME = "PMAAlertService";

        private static Logger logger = PMAConfigManager.GetConfigManagerInstance.Logger;
        
        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the system discs.
        /// </summary>
        /// <returns></returns>
        public static DriveInfo[] GetSystemDiscs()
        {
            logger.Debug(EnumMethod.START);
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            logger.Debug(EnumMethod.END);
            return driveInfo;
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets all services names.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllServicesNames()
        {
            logger.Debug(EnumMethod.START);
            List<string> servicenames = (from p in ServiceController.GetServices()
                                         select p.ServiceName).ToList<string>();
            logger.Debug(EnumMethod.END);
            return servicenames;
            
        }


        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Starts the service.
        /// </summary>
        public static string StartService()
        {
            logger.Debug(EnumMethod.START);
            ServiceController service = null;
            Process process = new Process();
            string serviceMessage = string.Empty;
            try
            {
                if (Environment.OSVersion.Version.Major > 5)
                {
                    process.StartInfo = new ProcessStartInfo("net", "start PMAAlertService");
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
                    service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 15));
                    serviceMessage = "Service Started Succesfully";
                }
                return serviceMessage;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ex.Message;
            }
            finally
            {
                logger.Debug(EnumMethod.END);
            }
            
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Stops the service.
        /// </summary>
        public static string StopService()
        {
            logger.Debug(EnumMethod.START);
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
                logger.Error(ex);
                serviceMessage = ex.Message;
                return serviceMessage;
            }
            finally
            {
                logger.Debug(EnumMethod.END);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the service status.
        /// </summary>
        /// <value>The service status.</value>
        public static string ServiceStatus
        {
            get
            {
                logger.Debug(EnumMethod.START);
                try
                {
                    ServiceController service = new ServiceController(SERVICE_NAME);
                    return service.Status.ToString();
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    return ex.Message;
                }
                finally
                {
                    logger.Debug(EnumMethod.END);
                }
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
            logger.Debug(EnumMethod.START);
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
            logger.Debug(EnumMethod.END);
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
            logger.Debug(EnumMethod.START);
            try
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
            finally
            {
                logger.Debug(EnumMethod.END);
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
        public static bool GenerateServiceMemoryAlert(List<string> listServicesName,bool webProcessWatch, int alertLevel, out List<string> listMessage, bool setStoppedServiceAlert)
        {

            logger.Debug(EnumMethod.START);
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

            if (webProcessWatch)
            {
                List<Process> listWebProcesses = (from process in Process.GetProcesses(".")
                                                  where process.ProcessName == "w3wp" || process.ProcessName == "w3wp*32"
                                                  select process).ToList<Process>();
                if (listWebProcesses != null && listWebProcesses.Count > 0)
                {
                    foreach (Process process in listWebProcesses)
                    {
                        if (((decimal)PMAServiceProcessController.GetServiceProcessWorkingSetInKB(process) / (decimal)PMAServiceProcessController.TotalPhysicalMemoryInKB) * 100 > alertLevel)
                        {
                            flag = true;
                            listMessage.Add("WebProcess " + process.ProcessName + ", PID " + process.Id  + "is taking more then " + (decimal)PMAServiceProcessController.GetServiceProcessWorkingSetInKB(process)/1024 +  " MB and is growing more then " + alertLevel + "% of available physical memory of " + (decimal)PMAServiceProcessController.TotalPhysicalMemoryInKB / 1024 + " MB");
                        }
                    }
                }
            }

            logger.Debug(EnumMethod.END);
            return flag;
            
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Resets the IIS.
        /// </summary>
        public static void ResetIIS()
        {
            logger.Debug(EnumMethod.START);
            ProcessStartInfo pInfo = new ProcessStartInfo(Environment.SystemDirectory + "\\iisreset.exe");
            if (Environment.OSVersion.Version.Major > 5)
            {
                pInfo.Verb = "runas";
            }
            Process.Start(pInfo);
            logger.Debug(EnumMethod.END);
        }
        #endregion 

        


    }
}
