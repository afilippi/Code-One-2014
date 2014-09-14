﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Mail;
using System.Net.Mail;
using System.Net;
using Twilio;

namespace CodeOneFinancialManagerMK2.Controllers
{
    public class TransactionController : Controller
    {

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


                int spendID = context.Triggers.Where(x => x.Type.Equals("OverSpend")).FirstOrDefault().Id;
                int withdrawalID = context.Triggers.Where(x => x.Type.Equals("Withdrawal")).FirstOrDefault().Id;
                int deposit = context.Triggers.Where(x => x.Type.Equals("Deposit")).FirstOrDefault().Id;
                int goalMetID = context.Triggers.Where(x => x.Type.Equals("GoalMet")).FirstOrDefault().Id;

                List<IFTT> iftts;

                switch (request.Type)
                {
                    case "Deposit":
                        iftts = context.IFTTs.Where(x => x.TriggerID == deposit || x.TriggerID == goalMetID).ToList();
                        ProcessDeposits(iftts);
                        break;
                    case "Withdrawal":
                        iftts = context.IFTTs.Where(x => x.TriggerID == withdrawalID).ToList();
                        ProcessWithdrawals(iftts);
                        break;
                    case "Purchase":
                        iftts = context.IFTTs.Where(x => x.TriggerID == spendID).ToList();
                        ProcessPurchases(iftts);
                        break;          
                }
            }
        }

        public void ProcessWithdrawals(List<IFTT> iftts)
        {

            using (BenderEntities context = new BenderEntities())
            {
                /*Email
                Text
                Call
                Alert*/
                foreach (IFTT thing in iftts)
                {
                    int userID = context.Accounts.Where(x => x.Id == thing.Id).FirstOrDefault().AccountOwnerID;
                    switch (thing.ActionID)
                    {
                        case 1:
                            MakeEmail(context.Users.Where(x => x.Id == userID).FirstOrDefault().Email, context.Triggers.Where(x => x.Id == thing.TriggerID).FirstOrDefault().Type);
                            break;
                        case 2:
                            MakeText(context.Users.Where(x => x.Id == userID).FirstOrDefault().Phone_Number, context.Triggers.Where(x => x.Id == thing.TriggerID).FirstOrDefault().Type);
                            break;
                        case 3:
                            MakeCall(context.Users.Where(x => x.Id == userID).FirstOrDefault().Phone_Number, context.Triggers.Where(x => x.Id == thing.TriggerID).FirstOrDefault().Type);
                            break;
                        case 4:
                            var iftt = context.IFTTs.Where(x => x.Id == thing.Id).FirstOrDefault();
                            iftt.CurrentAmount = iftt.TriggerAmount;
                            context.SaveChanges();
                            break;
                    }
                }
            }
        }

        public void ProcessDeposits(List<IFTT> iftts)
        {
            using (BenderEntities context = new BenderEntities())
            {
                /*Email
                Text
                Call
                Alert*/
                foreach (IFTT thing in iftts)
                {
                    int userID = context.Accounts.Where(x => x.Id == thing.Id).FirstOrDefault().AccountOwnerID;
                    switch (thing.ActionID)
                    {
                        case 1:
                            MakeEmail(context.Users.Where(x => x.Id == userID).FirstOrDefault().Email, context.Triggers.Where(x => x.Id == thing.TriggerID).FirstOrDefault().Type);
                            break;
                        case 2:
                            MakeText(context.Users.Where(x => x.Id == userID).FirstOrDefault().Phone_Number, context.Triggers.Where(x => x.Id == thing.TriggerID).FirstOrDefault().Type);
                            break;
                        case 3:
                            MakeCall(context.Users.Where(x => x.Id == userID).FirstOrDefault().Phone_Number, context.Triggers.Where(x => x.Id == thing.TriggerID).FirstOrDefault().Type);
                            break;
                        case 4:
                            var iftt = context.IFTTs.Where(x => x.Id == thing.Id).FirstOrDefault();
                            iftt.CurrentAmount = iftt.TriggerAmount;
                            context.SaveChanges();
                            break;
                    }
                }
            }
        }

        public void ProcessPurchases(List<IFTT> iftts)
        {
            using (BenderEntities context = new BenderEntities())
            {
                /*Email
                Text
                Call
                Alert*/
                foreach (IFTT thing in iftts)
                {
                    int userID = context.Accounts.Where(x => x.Id == thing.Id).FirstOrDefault().AccountOwnerID;
                    switch (thing.ActionID)
                    {
                        case 1:
                            MakeEmail(context.Users.Where(x => x.Id == userID).FirstOrDefault().Email, context.Triggers.Where(x => x.Id == thing.TriggerID).FirstOrDefault().Type);
                            break;
                        case 2:
                            MakeText(context.Users.Where(x => x.Id == userID).FirstOrDefault().Phone_Number, context.Triggers.Where(x => x.Id == thing.TriggerID).FirstOrDefault().Type);
                            break;
                        case 3:
                            MakeCall(context.Users.Where(x => x.Id == userID).FirstOrDefault().Phone_Number, context.Triggers.Where(x => x.Id == thing.TriggerID).FirstOrDefault().Type);
                            break;
                        case 4:
                            var iftt = context.IFTTs.Where(x => x.Id == thing.Id).FirstOrDefault();
                            iftt.CurrentAmount = iftt.TriggerAmount;
                            context.SaveChanges();
                            break;
                    }
                }
            }
        }

        public void Alert(IFTT iftt, String type)
        {
            switch (type)
            {
                case "OverSpend":
                   // iftts = context.IFTTs.Where(x => x.TriggerID == spendID).ToList();
                    break;
                case "Withdrawal":
                   // iftts = context.IFTTs.Where(x => x.TriggerID == withdrawalID).ToList();
                    break;
                case "Deposit":
                   // iftts = context.IFTTs.Where(x => x.TriggerID == deposit).ToList();
                    break;
                case "GoalMet":
                   // iftts = context.IFTTs.Where(x => x.TriggerID == goalMetID).ToList();
                    break;
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

      

        public void MakeText(String number, String type)
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account
            string AccountSid = "AC683a7dd9c5c40a812c3a747e2ae8f98c";
            string AuthToken = "4367acd7e12a1b928eed027a18538aa6";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            String messageBody = "";

            switch (type)
            {
                case "OverSpend":
                    messageBody = "Hello, This is First National Informing you that you have overspent on one of your budgets.";
                    break;
                case "Withdrawal":
                    messageBody = "Hello, This is First National Informing you that you have had a withdrawal.";
                    break;
                case "Deposit":
                    messageBody = "Hello, This is First National Informing you that you have had a deposit.";
                    break;
                case "GoalMet":
                    messageBody = "Hello, This is First National Informing you that you have met one of your goals.";
                    break;
            } 
        
            var message = twilio.SendMessage("+18559769895", number, messageBody);

            Console.WriteLine(message.Sid);  
        }


        public void MakeCall(String number, String type)
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account
            string AccountSid = "AC683a7dd9c5c40a812c3a747e2ae8f98c";
            string AuthToken = "4367acd7e12a1b928eed027a18538aa6";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var options = new CallOptions();           
            switch (type)
            {
                case "OverSpend":
                    options.Url = "https://raw.githubusercontent.com/afilippi/Code-One-2014/develop/CodeOneFinancialManagerMK2/Views/Home/Overspend.xml";
                    break;
                case "Withdrawal":
                    options.Url = "https://raw.githubusercontent.com/afilippi/Code-One-2014/develop/CodeOneFinancialManagerMK2/Views/Home/WithdrawalSpeech.xml";
                    break;
                case "Deposit":
                    options.Url = "https://raw.githubusercontent.com/afilippi/Code-One-2014/develop/CodeOneFinancialManagerMK2/Views/Home/Deposit.xml";
                    break;
                case "GoalMet":
                    options.Url = "https://raw.githubusercontent.com/afilippi/Code-One-2014/develop/CodeOneFinancialManagerMK2/Views/Home/GoalMet.xml";
                    break;
            }         
            
            options.To = number;
            options.From = "+18559769895";
            var call = twilio.InitiateOutboundCall(options);

            Console.WriteLine(call.Sid);
        }

        public void MakeEmail(String address, String type)
        {
            var fromAddress = new MailAddress("firstnationalautomatedsystem@gmail.com", "Bank");
            var toAddress = new MailAddress(address, "First National");
            const string fromPassword = "hackathon";
            const string subject = "First National Messaging";

            string body = "";        

            switch (type)
            {
                case "OverSpend":
                    body = "Hello, This is First National Informing you that you have overspent on one of your budgets.";
                    break;
                case "Withdrawal":
                    body = "Hello, This is First National Informing you that you have had a withdrawal.";
                    break;
                case "Deposit":
                    body = "Hello, This is First National Informing you that you have had a deposit.";
                    break;
                case "GoalMet":
                    body = "Hello, This is First National Informing you that you have met one of your goals.";
                    break;
            } 

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


        public void MakeTestEmail()
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

        public void MakeTestCall()
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account
            string AccountSid = "AC683a7dd9c5c40a812c3a747e2ae8f98c";
            string AuthToken = "4367acd7e12a1b928eed027a18538aa6";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);


            var options = new CallOptions();
            options.Url = "https://raw.githubusercontent.com/afilippi/Code-One-2014/develop/CodeOneFinancialManagerMK2/Views/Home/Speech.xml";
            /*options.Url = "<?xml version='1.0' encoding='UTF-8'?>" +
    "<Response>" +
    "<Say voice='woman' language='f'>Chapeau!</Say>" + 
"</Response>";*/
            options.To = "+14025985573";
            options.From = "+18559769895";
            var call = twilio.InitiateOutboundCall(options);

            Console.WriteLine(call.Sid);


        }

        public void MakeTestText(String number, String type)
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account
            string AccountSid = "AC683a7dd9c5c40a812c3a747e2ae8f98c";
            string AuthToken = "4367acd7e12a1b928eed027a18538aa6";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);

            String messageBody = "";
            type = "OverSpend";

            switch (type)
            {
                case "OverSpend":
                    messageBody = "Hello, This is First National Informing you that one of your credit cards has spent $200 while its budget was set to $100.";
                    break;
                case "Withdrawal":
                    messageBody = "Hello, This is First National Informing you that you have had a withdrawal.";
                    break;
                case "Deposit":
                    messageBody = "Hello, This is First National Informing you that you have had a deposit.";
                    break;
                case "GoalMet":
                    messageBody = "Hello, This is First National Informing you that you have met one of your goals.";
                    break;
            }

            var message = twilio.SendMessage("+18559769895", "+14025985573", messageBody);

            Console.WriteLine(message.Sid);
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
