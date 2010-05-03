using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Utils.smtp;
using PMA.Utils.ftp;
using PMA.Utils;
using System.IO;
using System.Diagnostics;
using PMA.ProcessMemoryAnalyzer;
using System.ServiceProcess;


namespace PMA.PMAConsoleApp
{
    public class Program
    {

        const int SPACE_LENGTH = 20;

        PMAInfo pmaInfo;
        Emails emailsInfo;
        SmtpInfo smtpInfo;
        FTPInfo ftpInfo; 

        static PMATaskHandler pmaTaskHandler;
        
        static void Main(string[] args)
        {
     
            string command = string.Empty;
            Program p = new Program();
            int option;
            try
            {
                p.DeserilizeObjects();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Invalid or no config Found, Creating Default");
                p.SerializeDefaultObject();
            }
            //p.SerializedInfo();
            while (command != "exit")
            {
                try
                {
                    p.DeserilizeObjects();
                    option = p.CreateUserOptions();
                    switch (option)
                    {
                        case 0:
                        {
                            Console.WriteLine();
                            Console.WriteLine("PMA Settings :");
                            
                            string serviceName = string.Empty;
                            p.pmaInfo = new PMAInfo();
                            Console.WriteLine("Enter Mailing Time(DD/MM/YYYY HH:MM) :");
                            p.pmaInfo.MailingTime = Console.ReadLine();
                            Console.WriteLine("Enter Mailing Report Interval (Hours) :");
                            p.pmaInfo.ReportsIntervalHours = int.Parse(Console.ReadLine()) ;
                            Console.WriteLine("Enter Client Name :");
                            p.pmaInfo.ClientName = Console.ReadLine();
                            
                            p.pmaInfo.ServicesNames = new List<string>();
                            Console.WriteLine("Enter Services Name(Enter ! to exit) :");
                            while (serviceName != "!")
                            {
                                serviceName = Console.ReadLine();
                                if (serviceName != "!")
                                    p.pmaInfo.ServicesNames.Add(serviceName);
                            }

                            break;
                        }
                        case 1:
                        {
                            Console.WriteLine();
                            Console.WriteLine("SMTP Settings :");
                            
                            p.smtpInfo = new SmtpInfo();
                            Console.WriteLine("Enter User Name : ");
                            p.smtpInfo.UserName = Console.ReadLine();
                            Console.WriteLine("Enter User Password : ");
                            p.smtpInfo.Password = Console.ReadLine();
                            Console.WriteLine("Enter port : ");
                            p.smtpInfo.Port = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter SMTP Name : ");
                            p.smtpInfo.SmtpServer = Console.ReadLine(); ;
                            Console.WriteLine("Enable SSL : ");
                            p.smtpInfo.SSL = bool.Parse(Console.ReadLine());
                            Console.WriteLine("Timeout : ");
                            p.smtpInfo.TimeOut = int.Parse(Console.ReadLine());
                            break;
                        }
                        
                        case 2:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Email Settings :");
                            
                            string email = string.Empty;
                            p.emailsInfo = new Emails();
                            p.emailsInfo.AttachmentPath = "";
                            Console.WriteLine("Subject Prefix :");
                            p.emailsInfo.Subject = Console.ReadLine() ;
                            Console.WriteLine("Mail Body Draft :");
                            p.emailsInfo.BodyContent = Console.ReadLine();
                            p.emailsInfo.EmailTo = new List<string>();
                            while (email != "!")
                            {
                                email = Console.ReadLine();
                                if (email != "!")
                                    p.emailsInfo.EmailTo.Add(email);
                            }
                            email = string.Empty;
                            p.emailsInfo.EmailCC = new List<string>();
                            while (email != "!")
                            {
                                email = Console.ReadLine();
                                if (email != "!")
                                    p.emailsInfo.EmailCC.Add(email);
                            }
                            break;
                        }
                        case 3:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Installing PMA Service :");
                            
                            Process process = new Process();
                            process.StartInfo.FileName = Environment.GetEnvironmentVariable("windir") + 
                                "\\Microsoft.NET\\Framework\\v3.5\\installutil.exe";
                            process.StartInfo.Arguments = PMAApplicationSettings.PMAApplicationDirectory +
                                "\\ProcessMemoryAnalyzerService.exe";
                            process.Start();
                            break;
                        }
                        
                        case 4:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Starting PMA Service :");
                            ServiceController service = new ServiceController("PMAService");
                            service.Start();
                            break;
                        }
                        
                        case 5:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Restoring Defaults :");
                            p.SerializeDefaultObject();
                            break;
                        }

                        case 6:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Show Settings :");
                            Console.WriteLine();
                            Console.WriteLine("PMA Settings :");
                            Console.WriteLine(p.pmaInfo.Serialize());
                            Console.WriteLine();
                            Console.WriteLine("SMTP Settings :");
                            Console.WriteLine(p.smtpInfo.Serialize());
                            Console.WriteLine();
                            Console.WriteLine("Email Settings :");
                            Console.WriteLine(p.emailsInfo.Serialize());
                            break;
                        }
                        case 7:
                        {
                            RunTest();
                            break;
                        }
     
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception :");
                    Console.WriteLine(ex.Message);
                }
                p.SerializedInfo();
                
            }
        }

        private static void RunTest()
        {

            if (pmaTaskHandler == null)
            {
                pmaTaskHandler = new PMATaskHandler();
            }
            pmaTaskHandler.RunTask();
            
            //PMATaskHandler.CreateAllProcessCSVReport("G:\\PMAService\\Memlog\\IVP_23 April 2010_01-20-54.txt");
            //PMATaskHandler.CreateAllProcessCSVReport("D:\\My Applications\\ProcessMemoryAnalyzer\\PMATestApp\\bin\\Debug\\Memlog\\IVP_29 April 2010_20-14.txt");


        }

        private int CreateUserOptions()
        {
            int i = -1;
            while (i == -1)
            {
                Console.WriteLine("Press 0 to Edit/Create PMA Setting");
                Console.WriteLine("Press 1 to Edit/Create SMTP Setting");
                Console.WriteLine("Press 2 to Edit/Create Email Setting");
                Console.WriteLine("Press 3 to install PMA Service");
                Console.WriteLine("Press 4 to Start PMA Service");
                Console.WriteLine("Press 5 to Restore Default Setting Files");
                Console.WriteLine("Press 6 to Show Settings");
                Console.WriteLine("Press 7 to runTest code");

                try
                {
                    i = int.Parse(Console.ReadKey().KeyChar.ToString());
                    if (i < 0 && i > 7)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid Option");
                    i = -1;
                }

            }
            return i;

        }

        
        private void SerializeDefaultObject()
        {
            //PMAInfo
            pmaInfo = new PMAInfo();
            pmaInfo.MailingTime = DateTime.Now.ToString("d/M/yyyy HH:mm");
            pmaInfo.ReportsIntervalHours = 24;
            pmaInfo.ServicesNames = new List<string>();
            pmaInfo.ServicesNames.Add("MSSQLSERVER");
            pmaInfo.ClientName = "IVP";
            pmaInfo.DisposeLogFile = false;
            pmaInfo.TriggerSeed = 5;
            pmaInfo.UseFTP = true;
            pmaInfo.UseSMTP = false;

            // EMAIL INFO
            emailsInfo = new Emails();
            emailsInfo.EmailTo = new List<string>();
            emailsInfo.EmailTo.Add("msareen@ivp.in");
            emailsInfo.EmailCC = new List<string>();
            emailsInfo.EmailCC.Add("manasvi.sareen@gmail.com");
            emailsInfo.AttachmentPath = "";
            emailsInfo.Subject = "Server Report";
            emailsInfo.BodyContent = "Please Find the Report Attached";

            // SMTP Info
            smtpInfo = new SmtpInfo();
            smtpInfo.ProtectPassword = true;
            smtpInfo.UserName = "productitsupport@cosmostech.in";
            smtpInfo.Password = "123@cosmos";
            smtpInfo.Port = 587;
            smtpInfo.SmtpServer = "smtp.gmail.com";
            smtpInfo.SSL = true;
            smtpInfo.TimeOut = 100000;

            //FTP Info
            ftpInfo = new FTPInfo();
            ftpInfo.FTPServer = "202.54.213.231";
            ftpInfo.FTPServerFolder = "PerformanceReports";
            ftpInfo.Password = "568@partners";
            ftpInfo.Port = 21;
            ftpInfo.ProtectPassword = false;
            ftpInfo.SSL = false;
            ftpInfo.TimeOut = 100000;
            ftpInfo.UserName = "ftpuser";
            

            SerializedInfo();
        }

        

        
        private void SerializedInfo()
        {
            try
            {
                File.WriteAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, PMAInfo.PMA_INFO_FILE), pmaInfo.Serialize());
                File.WriteAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, Emails.EMAILS_INFO_FILE), emailsInfo.Serialize());
                File.WriteAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, SmtpInfo.SMTP_INFO_FILE), smtpInfo.Serialize());
                File.WriteAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, FTPInfo.FTP_INFO_FILE), ftpInfo.Serialize());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeserilizeObjects()
        {
            try
            {
                pmaInfo = PMAInfo.Deserialize(File.ReadAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, PMAInfo.PMA_INFO_FILE)));
                emailsInfo = Emails.Deserialize(File.ReadAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, Emails.EMAILS_INFO_FILE)));
                smtpInfo = SmtpInfo.Deserialize(File.ReadAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, SmtpInfo.SMTP_INFO_FILE)));
                ftpInfo = FTPInfo.Deserialize(File.ReadAllText(Path.Combine(PMAApplicationSettings.PMAApplicationDirectoryConfig, FTPInfo.FTP_INFO_FILE)));
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }


        
    }
}
