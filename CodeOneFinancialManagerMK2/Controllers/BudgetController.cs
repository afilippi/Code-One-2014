using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeOneFinancialManagerMK2.Controllers.RequestResponse;

namespace CodeOneFinancialManagerMK2.Controllers
{
    public class BudgetController : Controller
    {
        public GetBudgetResponse GetBudget(GetBudgetRequest request)
        {     
            GetBudgetResponse response = new GetBudgetResponse();
             using (BenderEntities context = new BenderEntities())
            {
                List<UserBudget> budgets = context.Budgets.Where(x => x.AccountID == request.AccountID).Select(x => new UserBudget()
                    {
                        id = x.Id,
                        AccountID = x.AccountID ?? 0,
                        JSON = x.JSON,
                        TimeFrame = context.TimeFrames.Where(y => y.Id == x.TimeFrameID).FirstOrDefault().Type,
                    }).ToList();     
     
                 response.Budgets = budgets;
            }
            return response;
        }

        public PostBudgetResponse PostBudget(PostBudgetRequest request)
        {
            PostBudgetResponse response = new PostBudgetResponse();
            using (BenderEntities context = new BenderEntities())
            {

                Budget budget = new Budget();
                budget.TimeFrameID = context.TimeFrames.Where(x => x.Type.Equals(request.TimeFrame)).FirstOrDefault().Id;
                budget.JSON = request.JSON;
                budget.AccountID = request.AccountID;
                context.Budgets.Add(budget);
                context.SaveChanges();
            }

            return response;
        }

        public DeleteBudgetResponse DeleteBudget(DeleteBudgetRequest request)
        {
            DeleteBudgetResponse response = new DeleteBudgetResponse();
            using (BenderEntities context = new BenderEntities())
            {
                context.Budgets.Remove(context.Budgets.Where(x => x.Id == request.id).FirstOrDefault());
                context.SaveChanges();
            }

            return response;
        }


        // GET: Budget
        public ActionResult Index()
        {
            return View();
        }

        // GET: Budget/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Budget/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Budget/Create
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

        // GET: Budget/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Budget/Edit/5
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

        // GET: Budget/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Budget/Delete/5
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
