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


        public bool SendAsynchronous { get; set; }

        MailMessage mail = null;



        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Send Emails using smtp settings
        /// </summary>
        /// <param name="transportInfo">The transport info.</param>
        /// <param name="emails">The emails.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <param name="attachment">The attachments list. Send null in case there is no attachment</param>
        public void SmtpSend(SmtpInfo smtpInfo, List<string> toEmails, List<string> ccEmails, string subject, string message, List<string> attachments)
        {
            SmtpClient smtp = new SmtpClient();
            Attachment updatesAttachement = null;

            if (smtpInfo.ProtectPassword)
            {
                smtpInfo.Password = OperationUtils.EncryptDecrypt(smtpInfo.Password);
            }

            try
            {
                smtp.Credentials = new System.Net.NetworkCredential(smtpInfo.UserName, smtpInfo.Password);
                smtp.Host = smtpInfo.SmtpServer;
                smtp.Port = smtpInfo.Port;
                smtp.EnableSsl = smtpInfo.SSL;
                smtp.Timeout = smtpInfo.TimeOut;

                mail = new MailMessage();
                mail.From = new MailAddress(smtpInfo.UserName);

                foreach (string toEmail in toEmails)
                {
                    if(toEmail != string.Empty)
                        mail.To.Add(toEmail);
                }

                if (ccEmails != null)
                {
                    foreach (string ccEmail in ccEmails)
                    {
                        if(ccEmail != string.Empty)
                            mail.CC.Add(ccEmail);
                    }
                }

                mail.Subject = subject;
                mail.Body = message;
                if (attachments != null)
                {
                    foreach (string attachment in attachments)
                    {
                        if (File.Exists(attachment))
                        {
                            using (updatesAttachement = new Attachment(attachment))
                            {
                                mail.Attachments.Add(updatesAttachement);
                            }
                        }
                        else
                        {
                            throw new ArgumentException("One or more attachment provided are not valid");
                        }
                    }
                }

                if (SendAsynchronous)
                {
                    smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
                    smtp.SendAsync(mail,null);
                }
                else smtp.Send(mail);

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
                if (!SendAsynchronous)
                {
                    mail.Dispose();
                }
                if (smtpInfo.ProtectPassword)
                {
                    smtpInfo.Password = OperationUtils.EncryptDecrypt(smtpInfo.Password);
                }
            }
            
        }

        //-------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the SendCompleted event of the smtp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.AsyncCompletedEventArgs"/> instance containing the event data.</param>
        void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (mail != null)
            {
                mail.Dispose();
            }

        }

        
        
    }
 
}
