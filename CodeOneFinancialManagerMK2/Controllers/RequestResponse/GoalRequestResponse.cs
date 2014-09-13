using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeOneFinancialManagerMK2.Controllers.RequestResponse
{
    public class GetGoalRequest
    {
        public int AccountID;
    }

    public class GetGoalResponse
    {
        public List<UserGoal> Goals;
    }

    public class UserGoal
    {
        public int id;
        public float Amount;
        public DateTime Date;
        public String Description;
        public float SavedAmount;
        public int AccountID;
    }

    public class PostGoalRequest
    {
        public int id;
        public float Amount;
        public DateTime Date;
        public String Description;
        public float SavedAmount;
        public int AccountID;
    }

    public class PostGoalResponse
    {
        public bool success;
    }

    public class DeleteGoalRequest
    {
        public int id;
    }

    public class DeleteGoalResponse
    {
        public bool success;
    }
}