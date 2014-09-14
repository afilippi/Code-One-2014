using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeOneFinancialManagerMK2.Controllers.RequestResponse;
using Newtonsoft.Json;


namespace CodeOneFinancialManagerMK2.Controllers
{
    public class TriggerController : Controller
    {


        [HttpPost]
        public ActionResult GetTrigger(GetTriggerRequest request)
        {
            GetTriggerResponse response = new GetTriggerResponse();
            using (BenderEntities context = new BenderEntities())
            {
                List<UserTrigger> triggers = context.IFTTs.Where(x => x.AccountID == request.AccountID).Select(x => new UserTrigger()
                {
                  id = x.Id,
                  AccountID = x.AccountID ?? 0,
                  ActionID = context.Actions.Where(y => y.Id == x.Id).FirstOrDefault().Type,
                  CurrentAmount = (float)x.CurrentAmount,
                  TriggerAmount = (float)x.TriggerAmount,
                  MCC = context.MCCs.Where(y => y.Id == x.MCC).FirstOrDefault().Type,
                  TimeFrame = context.TimeFrames.Where(y => y.Id == x.TimeFrameID).FirstOrDefault().Type,
                  StartDate = x.StartDate ??  DateTime.Now,
                  Trigger = context.Triggers.Where(y => y.Id == x.TriggerID).FirstOrDefault().Type,


                }).ToList();

                response.Triggers = triggers;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public PostTriggerResponse PostTrigger(PostTriggerRequest request)
        {
            PostTriggerResponse response = new PostTriggerResponse();
            try
            {
                using (BenderEntities context = new BenderEntities())
                {
                    IFTT trigger = new IFTT();
                    trigger.Id = context.IFTTs.Count() + 1;
                    trigger.TriggerAmount = request.TriggerAmount;
                    trigger.TimeFrameID = context.TimeFrames.Where(x => x.Type.Equals(request.TimeFrame)).FirstOrDefault().Id;
                    trigger.StartDate = DateTime.Now;
                    trigger.CurrentAmount = request.CurrentAmount;
                    trigger.AccountID = request.AccountID;
                    trigger.ActionID = context.Actions.Where(x => x.Type.Equals(request.ActionID)).FirstOrDefault().Id;
                    trigger.MCC = context.MCCs.Where(x => x.Type.Equals(request.MCC)).FirstOrDefault().Id;
                    trigger.TriggerID = context.Triggers.Where(x => x.Type.Equals(request.Trigger)).FirstOrDefault().Id;


                    context.IFTTs.Add(trigger);
                    context.SaveChanges();
                }
            }
            catch(Exception e)
            {

            }

            return response;
        }

        public DeleteTriggerResponse DeleteTrigger(DeleteTriggerRequest request)
        {
            DeleteTriggerResponse response = new DeleteTriggerResponse();
            using (BenderEntities context = new BenderEntities())
            {
                context.Triggers.Remove(context.Triggers.Where(x => x.Id == request.id).FirstOrDefault());
                context.SaveChanges();
            }

            return response;
        }




























        // GET: Trigger
        public ActionResult Index()
        {
            return View();
        }

        // GET: Trigger/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Trigger/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trigger/Create
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

        // GET: Trigger/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trigger/Edit/5
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

        // GET: Trigger/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trigger/Delete/5
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
