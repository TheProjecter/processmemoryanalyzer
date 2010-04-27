using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Utils.smtp;
using PMA.Utils;
using System.IO;
using System.Diagnostics;


namespace PMA.ProcessMemoryAnalyzer
{
    public class PMATaskHandler
    {

        public PMAInfo PMAInfoObj { get; set; }
        public Emails EmailsInfoObj { get; set; }
        public SmtpInfo SmtpInfoObj { get; set; }

        private string _fileName;
        private string _reportFileName;
        DateTime mailingTime;


        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="PMATaskHandler"/> class.
        /// </summary>
        public PMATaskHandler()
        {
            DeserilizeInfos();
            _fileName = GenerateNewFileName();
        }

        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Generates the new name of the file.
        /// </summary>
        /// <returns></returns>
        private string GenerateNewFileName()
        {
            if (File.Exists(_fileName) && PMAInfoObj.DisposeLogFile)
            {
                File.Delete(_fileName);
            }
            if (File.Exists(_reportFileName) && PMAInfoObj.DisposeLogFile)
            {
                File.Delete(_reportFileName);
            }
            return Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryMemLog, PMAInfoObj.ClientName + "_" +
                DateTime.Now.ToLongDateString() + "_" + DateTime.Now.ToShortTimeString().Replace(':', '-')) + ".txt";
        }

        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the task.
        /// </summary>
        public void RunTask()
        {
            mailingTime = DateTime.ParseExact(PMAInfoObj.MailingTime, "d/M/yyyy HH:mm", null);
            if (DateTime.Now < mailingTime)
            {
                LogAllProcessMemory(_fileName);
            }
            else
            {
                ReportingTask();
            }
        }

        /// <summary>
        /// Reportings the task.
        /// </summary>
        public void ReportingTask()
        {
            string smtpPassword = string.Empty;
            SMTPTransport smtpTransport = new SMTPTransport();
            try
            {

                _reportFileName = string.Empty;
                smtpPassword = SmtpInfoObj.Password;
                if (File.Exists(_fileName))
                {
                    _reportFileName = CreateAllProcessCSVReport(_fileName);
                }
                mailingTime = mailingTime.AddHours(PMAInfoObj.ReportsIntervalHours);
                PMAInfoObj.MailingTime = mailingTime.ToString("d/M/yyyy HH:mm");
                if (File.Exists(_fileName))
                {
                    smtpTransport.SmtpSend(SmtpInfoObj, EmailsInfoObj.EmailTo, EmailsInfoObj.EmailCC,
                        EmailsInfoObj.Subject + ":" + PMAInfoObj.ClientName, GenerateMailMessageBody(), _reportFileName);
                }
            }
            catch (Exception ex)
            {
                // Start New Loging
            }
            finally
            {
                smtpTransport = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                SmtpInfoObj.Password = smtpPassword;
                _fileName = GenerateNewFileName();
                SerializedInfo();
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

            System.Threading.Thread.Sleep(500);
            string currentDateTimeString = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            sb.Append("\r\nΩ" + currentDateTimeString + "|" + cpuCounter.NextValue() + "%" + "|" + ramCounter.NextValue() + "MB Free");

            Dictionary<string, int> procDic = new Dictionary<string, int>();

            PerformanceCounter processCPUCounter = new PerformanceCounter();

            cpuCounter.CategoryName = "Process";
            cpuCounter.CounterName = "% Processor Time";

            foreach (Process p in Process.GetProcesses())
            {
                sb.Append("\r\n" + p.ProcessName + "(" + p.Id + ")" + "#" + (p.WorkingSet64 / 1024).ToString() + "#" + currentDateTimeString);
                try
                {
                    cpuCounter.InstanceName = p.ProcessName;
                    cpuCounter.NextValue();
                    System.Threading.Thread.Sleep(5);
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
                        Process getTitle = new Process();
                        getTitle.StartInfo.Arguments = p.Id.ToString();
                        getTitle.StartInfo.FileName = PMAApplicationSettings.PMAApplicationDirectory + "\\" + "GetProcessMainWindowTitle.exe";
                        getTitle.StartInfo.CreateNoWindow = false;
                        
                        getTitle.Start();
                        getTitle.WaitForExit();
                        if (getTitle.ExitCode == 5)
                        {
                            sb.Append("#OurApp");
                        }
                        else sb.Append("# ");
                        //if (p.MainWindowTitle.Contains("COSMOS") || p.MainWindowTitle.Contains("Reconciliation Framework"))
                        //{
                        //    sb.Append("#Recon");
                        //}
                        //else if (p.MainWindowTitle.Contains("Google"))
                        //{
                        //    sb.Append("#Google");
                        //}
                        //else sb.Append("# ");
                    }
                    catch
                    {
                        sb.Append("#?IO?");
                    }
                }
                else sb.Append("# ");




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
                reportData.Append("Total Memory Available," + PMAServiceProcessController.TotalPhysicalMemoryInMB + " MB");
                reportData.Append("\r\nProcessNames");

                List<int> totalMemoryUsageAtTime = new List<int>();

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

                //logging Memory|Process Time|Active Recon Window for process in time line
                foreach (string processName in processNames)
                {
                    reportData.Append("\r\n");
                    reportData.Append(processName);
                    var processMemUsageAtTime = (from value in rawData
                                                 where value.Contains('#') && value.Split('#')[0] == processName
                                                 orderby DateTime.Parse(value.Split('#')[2])
                                                 select new KeyValuePair<string, string>(value.Split('#')[2], value.Split('#')[1] + "|" + value.Split('#')[3]
                                                     + "|" + value.Split('#')[4]));

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
                    totalMemoryUsageAtTime = (from value in rawData
                                              where value.Contains('#') && value.Split('#')[2] == time
                                              select int.Parse(value.Split('#')[1])).ToList<int>();
                    foreach (int mem in totalMemoryUsageAtTime)
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
            StringBuilder builder = new StringBuilder();
            builder.Append("Hi,");
            builder.Append("<br>");
            builder.Append("<br>");
            builder.Append(EmailsInfoObj.BodyContent);
            builder.Append("<br>");
            builder.Append("Please find attached Machine Process Report for " + PMAInfoObj.ClientName);
            builder.Append("<br>");
            builder.Append("<br>");
            builder.Append("Thanks,");
            builder.Append("<br>");
            builder.Append("Cosmos Team.");
            return builder.ToString();
        }


        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Deserilizes the infos.
        /// </summary>
        private void DeserilizeInfos()
        {
            try
            {
                PMAInfoObj = PMAInfo.Deserialize(File.ReadAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, PMAInfo.PMA_INFO_FILE)));
                EmailsInfoObj = Emails.Deserialize(File.ReadAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, Emails.EMAILS_INFO_FILE)));
                SmtpInfoObj = SmtpInfo.Deserialize(File.ReadAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, SmtpInfo.SMTP_INFO_FILE)));
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Serializeds the info.
        /// </summary>
        private void SerializedInfo()
        {
            File.WriteAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, PMAInfo.PMA_INFO_FILE), PMAInfoObj.Serialize());
            File.WriteAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, Emails.EMAILS_INFO_FILE), EmailsInfoObj.Serialize());
            File.WriteAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, SmtpInfo.SMTP_INFO_FILE), SmtpInfoObj.Serialize());
        }


    }
}
