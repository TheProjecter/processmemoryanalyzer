﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMA.Utils.smtp;
using System.IO;

namespace PMATestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string config = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + SmtpInfo.SMTP_INFO_FILE);
            SmtpInfo smtpInfo = SmtpInfo.Deserialize(config);
            SMTPTransport transport = new SMTPTransport();
            transport.SendAsynchronous = false;

            List<string> mailTo = new List<string>();
            string subject = string.Empty;
            string body = string.Empty;

            Console.WriteLine("Send Mail to :");
            mailTo.Add(Console.ReadLine());
            Console.WriteLine("Subject :");
            subject = Console.ReadLine();
            Console.WriteLine("Body :");
            body = Console.ReadLine();

            try
            {
                Console.WriteLine("Sending Mail...");
                transport.SmtpSend(smtpInfo, mailTo, null, subject, body, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
                Environment.Exit(1);
            }
            Console.WriteLine("Mail Sent");
            Console.ReadLine();
            Environment.Exit(1);


        }
    }
}