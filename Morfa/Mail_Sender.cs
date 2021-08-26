using System;
using System.Net;
using System.Net.Mail;

namespace Morfa
{
    class Mail_Sender
    {
        public void sendmail(string Sender, string[] Receiver, string Subject, string Body, string username, string password, string Atachment)
        {
            MailMessage mailMessage = new MailMessage();
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                mailMessage.From = new MailAddress(Sender);
                foreach (string addresses in Receiver)
                {
                    mailMessage.To.Add(addresses);
                }

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(Atachment);
                mailMessage.Attachments.Add(attachment);

                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = Subject;
                mailMessage.Body = Body;
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(username, password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                mail.From = mailMessage.From;
                mail.To.Add(mailMessage.To.ToString());
                mail.Subject = "Operation Error";
                mail.Body = ex.Message;
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(username, password);
                smtp.EnableSsl = true;
            }
        }
    }
}
