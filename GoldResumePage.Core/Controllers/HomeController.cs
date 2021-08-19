using GoldResumePage.Core.Models;
using GoldResumePage.Data;
using GoldResumePage.EmailService;
using GoldResumePage.EmailService.Models;
using GoldResumePage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GoldResumePage.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;
        private readonly SendEmail _sendEmail;
        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext, SendEmail sendEmail)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _sendEmail = sendEmail;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactMe model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "I couldn't receive your message due to some errors while filling the form";
                //return View("Index", model);
                return View(model);
            }
            // send email to me
            MailRequest mailRequest = new MailRequest 
            { 
                ToEmail = "golden.idiki@gmail.com",
                Subject = $"{ model.FullName } Contacted You",
                Body = $"Email : {model.Email}\nPhone Number : {model.PhoneNumber}\n{model.Message}"
            };
            _sendEmail.Send(mailRequest);

            _appDbContext.ContactMeTbl.Add(model);
            await _appDbContext.SaveChangesAsync();
            TempData["Success"] = "Thank you for contacting me. I will get in touch with you";
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
