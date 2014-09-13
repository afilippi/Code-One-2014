using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeOneFinancialManagerMK2.Controllers.RequestResponse
{
    public class GetBudgetRequest
    {
        public int AccountID;
    }

    public class GetBudgetResponse
    {
        public List<UserBudget> Budgets;
    }

    public class UserBudget
    {
        public int id;
        public int AccountID;
        public String JSON;
        public String TimeFrame;
    }

    public class PostBudgetRequest
    {
        public int id;
        public int AccountID;
        public String JSON;
        public String TimeFrame;
    }

    public class PostBudgetResponse
    {
        public bool success;
    }

    public class DeleteBudgetRequest
    {
        public int id;
    }

    public class DeleteBudgetResponse
    {
        public bool success;
    }


}