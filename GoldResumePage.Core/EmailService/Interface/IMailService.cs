using GoldResumePage.EmailService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldResumePage.EmailService.Interface
{
    public interface IMailService
    {
        void SendEmail(MailRequest mailRequest);
    }
}
