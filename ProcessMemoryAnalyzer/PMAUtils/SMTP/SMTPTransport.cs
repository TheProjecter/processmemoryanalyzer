using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Net.Mail;
using PMA.Utils;


namespace PMA.Utils.smtp
{
    public class SMTPTransport
    {


        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Send Emails using smtp settings
        /// </summary>
        /// <param name="transportInfo">The transport info.</param>
        /// <param name="emails">The emails.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <param name="attachment">The attachment. send empty in case nothing to attach</param>
        public void SmtpSend(SmtpInfo smtpInfo, List<string> toEmails, List<string> ccEmails, string subject, string message, string attachment)
        {
            SmtpClient smtp = new SmtpClient();
            MailMessage mail = new MailMessage();
            Attachment updatesAttachement = null;

            if (smtpInfo.ProtectPassword)
            {
                smtpInfo.Password = OperationUtils.EncryptDecrypt(smtpInfo.Password, 22);
            }

            try
            {
                smtp.Credentials = new System.Net.NetworkCredential(smtpInfo.UserName, smtpInfo.Password);
                smtp.Host = smtpInfo.SmtpServer;
                smtp.Port = smtpInfo.Port;
                smtp.EnableSsl = true;
                smtp.Timeout = smtpInfo.TimeOut;

                mail = new MailMessage();
                mail.From = new MailAddress(smtpInfo.UserName);

                foreach (string toEmail in toEmails)
                {
                    mail.To.Add(toEmail);
                }

                if (ccEmails != null)
                {
                    foreach (string ccEmail in ccEmails)
                    {
                        mail.CC.Add(ccEmail);
                    }
                }

                mail.Subject = subject;
                mail.Body = message;
                if (attachment != null && attachment != string.Empty)
                {
                    if (File.Exists(attachment))
                    {
                        updatesAttachement = new Attachment(attachment);
                        mail.Attachments.Add(updatesAttachement);
                    }
                }

                smtp.Send(mail);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                mail.Dispose();
            }
            
        }

        
        
    }
 
}
