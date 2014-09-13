using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeOneFinancialManagerMK2.Controllers
{
    public class UtilityController : Controller
    {


        public String[] GetActions()
        {
            String[] outputArray;
            using (BenderEntities context = new BenderEntities())
            {
                outputArray = context.Actions.Select(x => x.Type).ToArray();
            }

            return outputArray;       
        }

        public String[] GetTriggers()
        {
            String[] outputArray;
            using (BenderEntities context = new BenderEntities())
            {
                outputArray = context.Triggers.Select(x => x.Type).ToArray();
            }

            return outputArray;
        }

        public String[] GetMCC()
        {
            String[] outputArray;
            using (BenderEntities context = new BenderEntities())
            {
                outputArray = context.MCCs.Select(x => x.Type).ToArray();
            }

            return outputArray;
        }

        public String[] GetTimeFrame()
        {
            String[] outputArray;
            using (BenderEntities context = new BenderEntities())
            {
                outputArray = context.TimeFrames.Select(x => x.Type).ToArray();
            }

            return outputArray;
        }

        public User[] GetUsers(int id)
        {
            User[] outputArray;
            using (BenderEntities context = new BenderEntities())
            {
                List<int> userIDs = context.CreditCards.Where(x => x.AccountID == id).Select(y => y.UserID ?? 0).ToList();
                outputArray = context.Users.Where(y => userIDs.Contains(y.Id)).ToArray();
            }

            return outputArray;
        }

        public CreditCard[] GetCards(int id)
        {
            CreditCard[] outputArray;
            using (BenderEntities context = new BenderEntities())
            {
                outputArray = context.CreditCards.Where(x => x.AccountID == id).ToArray();
            }

            return outputArray;
        }

      


        public class EventAlert
        {
            public int id;
            public int AccountID;
            public String ActionID;
            public float CurrentAmount;
            public float TriggerAmount;
            public String MCC;
            public String TimeFrame;
            public DateTime DateOccured;
            public String Trigger;
        }

        public class GetAlertRequest
        {
           public int AccountID;        
        }

        public class GetAlertResponse
        {
            public EventAlert[] Alerts;
        }


        public GetAlertResponse GetAlerts(GetAlertRequest request)
        {
            GetAlertResponse response = new GetAlertResponse();
            using (BenderEntities context = new BenderEntities())
            {
                int alert = context.Actions.Where(x => x.Type.Equals("Alert")).FirstOrDefault().Id;
                response.Alerts = context.IFTTs.Where(x => x.TriggerAmount <= x.CurrentAmount && x.ActionID == alert).Select(y => new EventAlert()
                {
                   id = y.Id,
                   AccountID = y.AccountID ?? 0,
                   ActionID = context.Actions.Where(z => z.Id == y.ActionID).FirstOrDefault().Type,
                   CurrentAmount = (float)y.CurrentAmount,
                   TriggerAmount = (float)y.TriggerAmount,
                   MCC = context.MCCs.Where(z => z.Id == y.MCC).FirstOrDefault().Type,
                   TimeFrame = context.TimeFrames.Where(z => z.Id == y.TimeFrameID).FirstOrDefault().Type,
                   DateOccured = y.StartDate ?? DateTime.Now,
                   Trigger = context.Triggers.Where(z => z.Id == y.TriggerID).FirstOrDefault().Type,        
                }).ToArray();
            }
            return response;
        }




































        // GET: Utility
        public ActionResult Index()
        {
            return View();
        }

        // GET: Utility/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Utility/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utility/Create
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

        // GET: Utility/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Utility/Edit/5
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

        // GET: Utility/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Utility/Delete/5
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
