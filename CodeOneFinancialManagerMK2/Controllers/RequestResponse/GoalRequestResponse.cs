using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace CodeOneFinancialManagerMK2.Controllers.RequestResponse
{
    public class GetGoalRequest
    {
        public int AccountID { get; set; }
    }

    [Serializable]
    public class GetGoalResponse
    {
        public List<UserGoal> Goals { get; set; }
    }

    [Serializable]
    public class UserGoal
    {
        public int id { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public float SavedAmount { get; set; }
        public int AccountID { get; set; }
    }

    [Serializable]
    public class PostGoalRequest
    {
        [DisplayName("id")]
        public int id { get; set; }

        [DisplayName("Amount")]
        public float Amount { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }

        [DisplayName("Description")]
        public String Description { get; set; }

        [DisplayName("SavedAmount")]
        public float SavedAmount { get; set; }

        [DisplayName("AccountID")]
        public int AccountID { get; set; }
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