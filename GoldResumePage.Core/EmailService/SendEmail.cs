using GoldResumePage.EmailService.Interface;
using GoldResumePage.EmailService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldResumePage.EmailService
{
    public class SendEmail
    {
        private readonly IMailService _mailService;
        public SendEmail(IMailService mailService)
        {
            _mailService = mailService;
        }

        public void Send(MailRequest request)
        {
            try
            {
                _mailService.SendEmail(request);
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
