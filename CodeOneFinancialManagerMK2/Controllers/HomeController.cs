using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeOneFinancialManagerMK2.Controllers.RequestResponse;
using System.Net.Mail;
using System.Net;

namespace CodeOneFinancialManagerMK2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void MakeTestTransaction()
        {
               var fromAddress = new MailAddress("firstnationalautomatedsystem@gmail.com", "Bank");
               var toAddress = new MailAddress("4025602967@vtext.com", "Huehue");
               const string fromPassword = "hackathon";
               const string subject = "Important Message";
               const string body = "Good Morning, Nerd";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
        }

        public ActionResult About()
        {

            using (BenderEntities context = new BenderEntities())
            {
                String message = context.Users.Where(x => x.Id == 1).FirstOrDefault().Full_Name;

                ViewBag.Message = message;
            }
            
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public String Temp()
        {
            return "Hi there!";
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Analysis()
        {
            List<Transaction> recentTransactions;
            using (BenderEntities context = new BenderEntities())
            {
                DateTime fiveMonthsAgo = DateTime.Now.AddMonths(-5);
                recentTransactions = context.Transactions.Where(x => x.Date.Value >= fiveMonthsAgo).ToList();
            }

            return View(recentTransactions);
        }
    }
}