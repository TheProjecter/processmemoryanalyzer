﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Utils.smtp;
using PMA.Utils;
using PMA.Utils.ftp;
using System.IO;
using System.Diagnostics;
using PMA.ConfigManager;
using PMA.Info;
using PMA.Utils.Logger;



namespace PMA.ProcessMemoryAnalyzer
{
    public class PMATaskHandler
    {

        private string _fileName;
        private string _reportFileName;
        DateTime mailingTime;

        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;


        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="PMATaskHandler"/> class.
        /// </summary>
        public PMATaskHandler()
        {
            configManager.Logger.Debug(EnumMethod.START);
            DeserilizePMAInfo();
            _fileName = GenerateNewFileName();
            configManager.Logger.Debug(EnumMethod.END);
        }

        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Generates the new name of the file.
        /// </summary>
        /// <returns></returns>
        private string GenerateNewFileName()
        {
            configManager.Logger.Debug(EnumMethod.START);
            if (File.Exists(_fileName) && configManager.PMAInfoObj.DisposeLogFile)
            {
                File.Delete(_fileName);
            }
            if (File.Exists(_reportFileName) && configManager.PMAInfoObj.DisposeLogFile)
            {
                File.Delete(_reportFileName);
            }
            configManager.Logger.Debug(EnumMethod.END);
            return Path.Combine(configManager.PMAApplicationDirectoryMemLog, configManager.PMAInfoObj.MachineName + "_" +
                DateTime.Now.ToLongDateString() + "_" + DateTime.Now.ToShortTimeString().Replace(':', '-')) + ".txt";
        }

        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the task.
        /// </summary>
        public void RunTask()
        {
            configManager.Logger.Debug(EnumMethod.START);
            if (configManager.SystemAnalyzerInfo.SetPMA)
            {
                mailingTime = configManager.PMAInfoObj.MailingTime;
                if (DateTime.Now < mailingTime)
                {
                    if (DateTime.Now.Minute % configManager.PMAInfoObj.TriggerSeed == 0)
                    {
                        LogAllProcessMemory(_fileName);
                    }
                }
                else
                {
                    ReportingTask();
                }
            }
            configManager.Logger.Debug(EnumMethod.END);
        }

        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Reportings the task.
        /// </summary>
        public void ReportingTask()
        {
            configManager.Logger.Debug(EnumMethod.START);
            if (configManager.SystemAnalyzerInfo.SetPMA)
            {
                SMTPTransport smtpTransport = new SMTPTransport();
                FTPTransport ftpTransport = new FTPTransport();
                try
                {

                    _reportFileName = string.Empty;
                    if (File.Exists(_fileName))
                    {
                        _reportFileName = CreateAllProcessCSVReport(_fileName);
                    }
                    if (DateTime.Now > mailingTime)
                    {
                        mailingTime = mailingTime.AddHours(configManager.PMAInfoObj.ReportsIntervalHours);
                        configManager.PMAInfoObj.MailingTime = mailingTime;
                    }
                    if (File.Exists(_fileName))
                    {
                        
                        if (configManager.PMAInfoObj.UseSMTP)
                        {
                            try
                            {

                                string subject = "PMA System Alerts : PMA Report : " + configManager.SystemAnalyzerInfo.ClientInstanceName + " : " + Environment.MachineName + " : " +
                                " at " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

                                List<string> attachments = new List<string>();
                                attachments.Add(_reportFileName);
                                smtpTransport.SmtpSend(configManager.SmtpInfo, configManager.SystemAnalyzerInfo.ListPMAReportSubscription, null,
                                     subject, GenerateMailMessageBody(), attachments);
                            }
                            catch (InvalidOperationException ex)
                            {
                                configManager.Logger.Message(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                configManager.Logger.Error(ex);
                            }

                        }
                        if (configManager.PMAInfoObj.UseFTP)
                        {
                            try
                            {
                                List<string> ftpFiles = new List<string>();
                                ftpFiles.Add(_reportFileName);
                                ftpTransport.FTPSend(configManager.FtpInfo, ftpFiles);
                            }
                            catch (Exception ex)
                            {
                                configManager.Logger.Error(ex);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    configManager.Logger.Error(ex);
                }
                finally
                {
                    smtpTransport = null;
                    ftpTransport = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    _fileName = GenerateNewFileName();
                    SerializedPMAInfo();
                    configManager.Logger.Debug(EnumMethod.END);
                }
            }
        }




        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Logs all process memory.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        private static void LogAllProcessMemory(string fileName)
        {
            StringBuilder sb = new StringBuilder();

            PerformanceCounter cpuCounter;
            cpuCounter = new PerformanceCounter();

            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            cpuCounter.NextValue();


            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            System.Threading.Thread.Sleep(900);
            string currentDateTimeString = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            sb.Append("\r\nΩ" + currentDateTimeString + "|" + cpuCounter.NextValue() + "%" + "|" + ramCounter.NextValue()*1024 + "KB Free");

            Dictionary<string, int> procDic = new Dictionary<string, int>();

            PerformanceCounter processCPUCounter = new PerformanceCounter();

            cpuCounter.CategoryName = "Process";
            cpuCounter.CounterName = "% Processor Time";

            //Counter Order
            // ProcessName#PhysicalMem#Time#cpuTime#IE#VirtualMem#ThreadCount
            foreach (Process p in Process.GetProcesses())
            {
                sb.Append("\r\n" + p.ProcessName + "(" + p.Id + ")" + "#" + (  p.WorkingSet64 / (1024)).ToString() + "#" + currentDateTimeString);
                
                try
                {
                    cpuCounter.InstanceName = p.ProcessName;
                    cpuCounter.NextValue();
                    System.Threading.Thread.Sleep(10);
                    sb.Append("#" + cpuCounter.NextValue() + "%");
                }
                catch
                {
                    sb.Append("#" + "??");
                }
                if (p.ProcessName.Equals("iexplore"))
                {
                    try
                    {
                        if (p.MainWindowTitle.Contains("COSMOS") || p.MainWindowTitle.Contains("Reconciliation Framework"))
                        {
                            sb.Append("#Recon");
                        }
                        else if (p.MainWindowTitle.Contains("Google"))
                        {
                            sb.Append("#Google");
                        }
                        else sb.Append("# ");
                    }
                    catch
                    {
                        sb.Append("#?IO?");
                    }
                }
                else sb.Append("# ");

                sb.Append("#" + (p.VirtualMemorySize64 / (1024)).ToString());
                sb.Append("#" + p.Threads.Count.ToString());
            }
            File.AppendAllText(fileName, sb.ToString());
        }



        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates all process CSV report.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public static string CreateAllProcessCSVReport(string rawfileName)
        {
            string reportFile = string.Empty;
            try
            {
                List<string> rawData = File.ReadAllLines(rawfileName).ToList<string>();
                StringBuilder reportData = new StringBuilder();
                reportData.Append("TotalMemoryAvailable," + PMAServiceProcessController.TotalPhysicalMemoryInKB + " KB");
                reportData.Append("\r\nProcessNames");

                List<int> totalPhyMemoryUsageAtTime = new List<int>();
                List<int> totalVirtualMemUseAtTime = new List<int>();

                DateTime.Parse(rawData[1].Split('|')[0].Substring(1, rawData[1].Split('|')[0].Length - 1));



                //Getting Time Line
                List<string> times = (from value in rawData
                                      where value.Contains('Ω')
                                      orderby DateTime.Parse(value.Split('|')[0].Substring(1, value.Split('|')[0].Length - 1))
                                      select value.Split('#')[0].Substring(1, value.Split('|')[0].Length - 1)).ToList<string>();

                //Creating Time Line in report
                foreach (string time in times)
                {
                    reportData.Append("," + time);
                }

                reportData.Append("\r\nTotal CPU Usage");
                List<string> cpuUsageAtIntance = (from value in rawData
                                                  where value.Contains('Ω')
                                                  orderby DateTime.Parse(value.Split('|')[0].Substring(1, value.Split('|')[0].Length - 1))
                                                  select value.Split('|')[1]).ToList<string>();

                foreach (string cpuUsage in cpuUsageAtIntance)
                {
                    reportData.Append("," + cpuUsage);
                }

                reportData.Append("\r\nAvailable RAM");
                List<string> ramAvailabeAtIntance = (from value in rawData
                                                     where value.Contains('Ω')
                                                     orderby DateTime.Parse(value.Split('|')[0].Substring(1, value.Split('|')[0].Length - 1))
                                                     select value.Split('|')[2]).ToList<string>();

                foreach (string ramAvailable in ramAvailabeAtIntance)
                {
                    reportData.Append("," + ramAvailable);
                }

                //Getting All Process names
                List<string> processNames = (from value in rawData
                                             where value.Contains('#')
                                             orderby value.Split('#')[0]
                                             select value.Split('#')[0]).Distinct().ToList<string>();

                //logging 
                //PhyMemory|VirtualMem|CPU Use|Thread|Active Recon Window for process in time line
                foreach (string processName in processNames)
                {
                    reportData.Append("\r\n");
                    reportData.Append(processName);
                    var processMemUsageAtTime = (from value in rawData
                                                 where value.Contains('#') && value.Split('#')[0] == processName
                                                 orderby DateTime.Parse(value.Split('#')[2])
                                                 select new KeyValuePair<string, string>(value.Split('#')[2], value.Split('#')[1]+"|"+value.Split('#')[5] + "|" + value.Split('#')[3]
                                                     + "|" + value.Split('#')[6] + "|" + value.Split('#')[4]));

                    Dictionary<string, string> memTimeMap = new Dictionary<string, string>();
                    foreach (var item in processMemUsageAtTime)
                    {
                        memTimeMap.Add(item.Key.ToString(), item.Value.ToString());
                    }

                    foreach (string time in times)
                    {
                        if (memTimeMap.Keys.Contains<string>(time))
                        {
                            reportData.Append("," + memTimeMap[time]);
                        }
                        else reportData.Append(",");
                    }
                }

                //Getting Total Memory usaage at a time line
                long totalMemory = 0;
                reportData.Append("\r\nTotal Memory");
                foreach (string time in times)
                {

                    totalMemory = 0;
                    totalPhyMemoryUsageAtTime = (from value in rawData
                                              where value.Contains('#') && value.Split('#')[2] == time
                                              select int.Parse(value.Split('#')[1])).ToList<int>();

                    
                    
                    foreach (int mem in totalPhyMemoryUsageAtTime)
                    {
                        totalMemory = totalMemory + mem;
                    }
                    reportData.Append("," + totalMemory);
                }

                reportData.Append("\r\nTotal Virtual Memory");
                foreach (string time in times)
                {

                    totalMemory = 0;
                    totalVirtualMemUseAtTime = (from value in rawData
                                                where value.Contains('#') && value.Split('#')[2] == time
                                                select int.Parse(value.Split('#')[5])).ToList<int>();

                    foreach (int mem in totalVirtualMemUseAtTime)
                    {
                        totalMemory = totalMemory + mem;
                    }
                    reportData.Append("," + totalMemory);
                }

                reportFile = Path.GetDirectoryName(rawfileName) + "\\" + Path.GetFileNameWithoutExtension(rawfileName) + "_formated.csv";
                File.WriteAllText(reportFile, reportData.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return reportFile;

        }

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Generates the mail message body.
        /// </summary>
        /// <param name="clientInstances">The client instances.</param>
        /// <returns></returns>
        private string GenerateMailMessageBody()
        {
            configManager.Logger.Debug(EnumMethod.START);
            StringBuilder builder = new StringBuilder();
            builder.Append("Hi,");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("Please find the Process Memory information file attached.");
            builder.Append("\r\n");
            builder.Append("Please find attached Machine Process Report for " + configManager.PMAInfoObj.MachineName + " : " + configManager.SystemAnalyzerInfo.ClientInstanceName);
            builder.Append("\r\n");
            builder.Append("CELL FROMAT");
            builder.Append("\r\n");
            builder.Append("PhyMemory|VirtualMem|CPU Use|Thread|Active Recon Window for process in time line");
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append("Thanks,");
            builder.Append("\r\n");
            builder.Append("Cosmos Team.");
            return builder.ToString();
            configManager.Logger.Debug(EnumMethod.END);
        }


        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Deserilizes the infos.
        /// </summary>
        private void DeserilizePMAInfo()
        {
            configManager.Logger.Debug(EnumMethod.START);
            try
            {
                configManager.PMAInfoObj = PMAInfo.Deserialize(File.ReadAllText(Path.Combine(configManager.CurrentAppConfigDir, PMAInfo.PMA_INFO_FILE)));
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
            finally
            {
                configManager.Logger.Debug(EnumMethod.END);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Serializeds the info.
        /// </summary>
        private void SerializedPMAInfo()
        {
            configManager.Logger.Debug(EnumMethod.START);
            File.WriteAllText(Path.Combine(configManager.CurrentAppConfigDir, PMAInfo.PMA_INFO_FILE), configManager.PMAInfoObj.Serialize());
            configManager.Logger.Debug(EnumMethod.END);
        }


    }
}
