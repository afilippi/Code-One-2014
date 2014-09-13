using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeOneFinancialManagerMK2.Controllers.RequestResponse;

namespace CodeOneFinancialManagerMK2.Controllers
{
    public class GoalController : Controller
    {


        public GetGoalResponse GetGoal(GetGoalRequest request)
        {
            GetGoalResponse response = new GetGoalResponse();
            using (BenderEntities context = new BenderEntities())
            {
                List<UserGoal> goals = context.Goals.Where(x => x.AccountID == request.AccountID).Select(x => new UserGoal()
                {
                    id = x.Id,
                    AccountID = x.AccountID ?? 0,
                    Amount = (float)(x.Amount ?? 0),
                    Date = x.Date ?? DateTime.Now,
                    Description = x.Description,
                    SavedAmount = (float)(x.SavedAmount ?? 0),               
                }).ToList();

                response.Goals = goals;
            }
            return response;
        }

        public PostGoalResponse PostBudget(PostGoalRequest request)
        {
            PostGoalResponse response = new PostGoalResponse();
            using (BenderEntities context = new BenderEntities())
            {
                Goal goal = new Goal();

                goal.AccountID = request.AccountID;
                goal.Amount = request.Amount;
                goal.Date = request.Date;
                goal.Description = request.Description;
                goal.SavedAmount = request.SavedAmount;         
                context.Goals.Add(goal);
                context.SaveChanges();
            }

            return response;
        }

        public DeleteGoalResponse DeleteGoal(DeleteGoalRequest request)
        {
            DeleteGoalResponse response = new DeleteGoalResponse();
            using (BenderEntities context = new BenderEntities())
            {
                context.Goals.Remove(context.Goals.Where(x => x.Id == request.id).FirstOrDefault());
                context.SaveChanges();
            }

            return response;
        }





























        // GET: Goal
        public ActionResult Index()
        {
            return View();
        }

        // GET: Goal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Goal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goal/Create
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

        // GET: Goal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Goal/Edit/5
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

        // GET: Goal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Goal/Delete/5
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
