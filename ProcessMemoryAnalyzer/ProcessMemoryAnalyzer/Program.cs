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
    public class Program
    {

        const int SPACE_LENGTH = 20;

        PMAInfo pmaInfo;
        Emails emailsInfo;
        SmtpInfo smtpInfo;
        
        static void Main(string[] args)
        {
            Program p = new Program();
            p.SerializeObject();
            p.DeserilizeObjects();

            //DateTime dt = DateTime.Parse(p.pmaInfo.MailingTime);

            //new PMATaskHandler().RunTask();

           // Environment.

        }

        
        private void SerializeObject()
        {
            pmaInfo = new PMAInfo();

            pmaInfo.MailingTime = DateTime.Now.ToShortDateString()+" "+ DateTime.Now.ToShortTimeString();

            pmaInfo.ReportsIntervalHours = 24;
            pmaInfo.ServicesNames = new List<string>();
            pmaInfo.ServicesNames.Add("MSSQLSERVER");

            emailsInfo = new Emails();
            emailsInfo.EmailTo = new List<string>();
            emailsInfo.EmailTo.Add("msareen@ivp.in");
            emailsInfo.EmailCC = new List<string>();
            emailsInfo.EmailCC.Add("manasvi.sareen@gmail.com");
            emailsInfo.AttachmentPath = "";
            emailsInfo.Subject = "Server Report";
            emailsInfo.BodyContent = "Please Find the Report Attached";

            smtpInfo = new SmtpInfo();
            smtpInfo.UserName = "productitsupport@cosmostech.in";
            smtpInfo.Password = "123@cosmos";
            smtpInfo.Port = 587;
            smtpInfo.SmtpServer = "smtp.gmail.com";
            smtpInfo.SSL = true;
            smtpInfo.TimeOut = 100000;

            SerializedInfo();
        }

        
        private void SerializedInfo()
        {
            File.WriteAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, PMAInfo.PMA_INFO_FILE), pmaInfo.Serialize());

            File.WriteAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, Emails.EMAILS_INFO_FILE), emailsInfo.Serialize());

            File.WriteAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, SmtpInfo.SMTP_INFO_FILE), smtpInfo.Serialize());
        }

        private void DeserilizeObjects()
        {
            pmaInfo = PMAInfo.Deserialize(File.ReadAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, PMAInfo.PMA_INFO_FILE)));

            emailsInfo = Emails.Deserialize(File.ReadAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, Emails.EMAILS_INFO_FILE)));

            smtpInfo = SmtpInfo.Deserialize(File.ReadAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, SmtpInfo.SMTP_INFO_FILE)));

        }


        
    }
}
