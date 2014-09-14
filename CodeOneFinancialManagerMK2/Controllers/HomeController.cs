using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeOneFinancialManagerMK2.Controllers.RequestResponse;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNet.SignalR;

namespace CodeOneFinancialManagerMK2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult IFTT()
        {
            return View();
        }

        public ActionResult Test()
        {



            return View();
        }

        public void Hit()
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<AlertHub>();
            hubContext.Clients.All.addNewMessageToPage("9/19", "Something Something");
        }

        public ActionResult Goals()
        {
            return View();
        }
    }
}