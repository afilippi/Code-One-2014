using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Mail;
using System.Net.Mail;

namespace CodeOneFinancialManagerMK2.Controllers
{
    public class TransactionController : Controller
    {

        public class MakeTransactionsRequest
        {
            public Nullable<double> Amount;
            public string Type;
            public Nullable<System.DateTime> Date;
            public string Location;
            public string CardNumber;
            public Nullable<int> mcc;
            public Nullable<int> AccountID;
        }

        public void MakeTestTransaction()
        {

            
                
        try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("afili332@gmail.com");
                mail.To.Add("4025985573@messaging.sprintpcs.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("afili332@gmail.com", "nela8738");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
   
            }
            catch (Exception ex)
            {
                
            }


        }


        public void MakeTransaction(MakeTransactionsRequest request)
        {
            using (BenderEntities context = new BenderEntities())
            {
                Transaction transaction = new Transaction();
                transaction.Amount = request.Amount;
                transaction.Type = request.Type;
                transaction.Date = request.Date;
                transaction.Location = request.Location;
                transaction.CardNumber = request.CardNumber;
                transaction.mcc = request.mcc;
                transaction.AccountID = request.AccountID;
                context.Transactions.Add(transaction);
                context.SaveChanges();

                //List<IFTT> iftts = context.IFTTs.Where();


            }
        }


        public class GetTransactionsRequest
        {
            public int AccountID;
            public DateTime Start;
            public DateTime End;
        }

        public class GetTransactionsResponse
        {
            public Transaction[] Transactions;
        }

        public GetTransactionsResponse GetTransactions(GetTransactionsRequest request)
        {
            GetTransactionsResponse response = new GetTransactionsResponse();


            using (BenderEntities context = new BenderEntities())
            {
                response.Transactions = context.Transactions.Where(x => x.AccountID == request.AccountID && DateTime.Compare((DateTime)x.Date, request.End) <= 0 && DateTime.Compare((DateTime)x.Date, request.Start) >= 0).ToArray();
            }

            return response;
        }




























        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transaction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transaction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
