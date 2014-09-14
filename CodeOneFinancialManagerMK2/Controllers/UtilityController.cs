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
            public int Id { get; set; }
            public string Descrption { get; set; }
            public DateTime Date { get; set; }
            public int AccountID { get; set; }
        }

        [Serializable]
        public class GetAlertRequest
        {
            public int AccountID { get; set; }       
        }

        [Serializable]
        public class GetAlertResponse
        {
            public EventAlert[] Alerts;
        }



        [HttpPost]
        public ActionResult GetAlerts(GetAlertRequest request)
        {
            GetAlertResponse response = new GetAlertResponse();
            using (BenderEntities context = new BenderEntities())
            {
                int alert = context.Actions.Where(x => x.Type.Equals("Alert")).FirstOrDefault().Id;
                response.Alerts = context.Alerts.Where(x => x.AccountID == request.AccountID).Select(y => new EventAlert()
                {
                   Id = y.Id,
                   Descrption = y.Descrption,
                   Date = y.Date ??  DateTime.Now,
                   AccountID = y.AccountID ?? 1,
                  
                }).ToArray();
            }
            return Json(response, JsonRequestBehavior.AllowGet);
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
