using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Utils.smtp;
using PMA.Utils;
using System.IO;
using GoogleChartSharp;
using System.Diagnostics;


namespace PMA.ProcessMemoryAnalyzer
{
    public class PMATaskHandler
    {

        public PMAInfo PMAInfoObj { get; set; }
        public Emails EmailsInfoObj { get; set; }
        public SmtpInfo SmtpInfoObj { get; set; }

        public string _fileName;
        

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
            return Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryMemLog, 
                DateTime.Now.ToLongDateString() + "_" + DateTime.Now.ToShortTimeString().Replace(':','-')) + ".txt";
        }

        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Runs the task.
        /// </summary>
        public void RunTask()
        {
            DateTime mailingTime = DateTime.Parse(PMAInfoObj.MailingTime);
            if (DateTime.Now < mailingTime)
            {
                LogAllProcessMemory(_fileName);
            }
            else
            {
                string Report = CreateAllProcessCSVReport(_fileName);
                Transport.SmtpSend(SmtpInfoObj, EmailsInfoObj.EmailTo, EmailsInfoObj.EmailCC, EmailsInfoObj.Subject, EmailsInfoObj.BodyContent, Report);
                _fileName = GenerateNewFileName();
                mailingTime = mailingTime.AddHours(PMAInfoObj.ReportsIntervalHours);
                PMAInfoObj.MailingTime = mailingTime.ToShortDateString() + " " + mailingTime.ToShortTimeString();
                SerializedInfo();
            }

        }


        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates the service persent usage graph.
        /// </summary>
        /// <param name="pmaInfo">The pma info.</param>
        private static void CreateServicePersentUsageGraph(PMAInfo pmaInfo)
        {

            GoogleChartSharp.LineChart lc = new LineChart(600, 500, LineChartType.MultiDataSet);
            List<int> mu = new List<int>();
            List<int> ti = new List<int>();

            PMAServiceProcessController spc = new PMAServiceProcessController(pmaInfo.ServicesNames[0]);

            for (int i = 0; i < 20; i++)
            {
                mu.Add((int)(((spc.GetServiceProcessWorkingSet * 100)) / (PMAServiceProcessController.TotalPhysicalMemory)));
                ti.Add(i);
                Console.WriteLine(i);
            }

            List<int[]> datasets = new List<int[]>();
            datasets.Add(ti.ToArray());
            datasets.Add(mu.ToArray());

            lc.SetData(datasets);
           
            string url = lc.GetUrl();

            Process pro = new Process();
            pro.StartInfo.FileName = "firefox";
            pro.StartInfo.Arguments = url;

            pro.Start();

        }


        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Logs all process memory.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        private static void LogAllProcessMemory(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> procDic = new Dictionary<string, string>();
            sb.AppendLine("Ω" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            foreach (Process p in Process.GetProcesses())
            {
                if (procDic.ContainsKey(p.ProcessName))
                {
                    string duplicateProcessName = p.ProcessName;

                    int i = 0;
                    LogDuplicateProcess(ref duplicateProcessName, procDic, ref i);
                    while (procDic.ContainsKey(duplicateProcessName))
                    {
                        duplicateProcessName = duplicateProcessName + "_" + i;
                        procDic.Add(p.ProcessName, (p.WorkingSet64 / 1024).ToString());
                        i++;
                    }
                }
                else procDic.Add(p.ProcessName, (p.WorkingSet64 / 1024).ToString());
            }

            foreach (string key in procDic.Keys)
            {
                sb.AppendLine(key + "#" + procDic[key]);
            }
            //sb.AppendLine(p.ProcessName + "#" + p.WorkingSet64/1024);

            File.AppendAllText(fileName, sb.ToString());
        }

        private static void LogDuplicateProcess(ref string processName, Dictionary<string,string> procDic, ref int i)
        {
            if(procDic.ContainsKey(processName))
            {
                processName = processName + "_" + i;
                i++;
                LogDuplicateProcess(ref processName, procDic, ref i);
            }
        }


        //----------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates all process CSV report.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        private static string CreateAllProcessCSVReport(string rawfileName)
        {
            List<string> rawData = File.ReadAllLines(rawfileName).ToList<string>();
            StringBuilder reportData = new StringBuilder();

            reportData.Append("ProcessNames");
            List<string> times = (from value in rawData
                                  where value.Contains('Ω')
                                  select value).ToList<string>();
            foreach (string time in times)
            {
                reportData.Append("," + time.Substring(1,time.Length-1));
            }

            List<string> processNames = (from value in rawData
                                         where value.Contains('#')
                                         select value.Split('#')[0]).Distinct().ToList<string>();

            foreach (string processName in processNames)
            {
                reportData.Append("\r\n");
                reportData.Append(processName);
                List<string> processMemUsage = (from value in rawData
                                                where value.Contains('#') && value.Split('#')[0] == processName
                                                select value.Split('#')[1]).ToList<string>();
                foreach (string memusage in processMemUsage)
                {
                    reportData.Append("," + memusage);
                }

            }

            File.WriteAllText(Path.GetDirectoryName(rawfileName)+"\\"+ Path.GetFileNameWithoutExtension(rawfileName) + "_formated.csv", reportData.ToString());

            return Path.GetFileNameWithoutExtension(rawfileName) + "_formated.csv";                     

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
