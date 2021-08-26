using GoldResumePage.EmailService.Interface;
using GoldResumePage.EmailService.Models;
//using MailKit.Net.Smtp;
using System.Net.Mail;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace GoldResumePage.EmailService.Implementation
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public void SendEmail(MailRequest mailRequest)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(_mailSettings.Mail);
            message.To.Add("Recipient Email");
            message.Subject = mailRequest.Subject;
            message.IsBodyHtml = true;
            message.Body = mailRequest.Body;
            message.BodyEncoding = Encoding.UTF8;


            //var email = new MimeMessage();
            //email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            //email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            //email.Subject = mailRequest.Subject;
            //var builder = new BodyBuilder();
            //builder.HtmlBody = mailRequest.Body;
            //email.Body = builder.ToMessageBody();

            //using var smtp = new SmtpClient();
            //smtp.Connect("smtp.gmail.com", _mailSettings.Port, SecureSocketOptions.StartTls);
            //smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            //await smtp.SendAsync(email);
            //smtp.Disconnect(true);

            SmtpClient client = new SmtpClient(_mailSettings.Host, _mailSettings.Port); //Gmail smtp    
            try
            {
                System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(message);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                client.Dispose();
            }
            
            


        }
    }
}


