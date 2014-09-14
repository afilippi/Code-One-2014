using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeOneFinancialManagerMK2.Controllers.RequestResponse
{
    public class GetTriggerRequest
    {
        public int AccountID { get; set; }
    }

    [Serializable]
    public class GetTriggerResponse
    {
        public List<UserTrigger> Triggers;
    }

    public class UserTrigger
    {
        public int id;
        public int AccountID;
        public String ActionID;
        public float CurrentAmount;
        public float TriggerAmount;
        public String MCC;
        public String TimeFrame;
        public DateTime StartDate;
        public String Trigger;
    }

    public class PostTriggerRequest
    {
        public int id { get; set; }
        public int AccountID { get; set; }
        public String ActionID { get; set; }
        public float CurrentAmount { get; set; }
        public float TriggerAmount { get; set; }
        public String MCC { get; set; }
        public String TimeFrame { get; set; }
        public String Trigger { get; set; }
    }

    public class PostTriggerResponse
    {
        public bool success;
    }

    public class DeleteTriggerRequest
    {
        public int id;
    }

    public class DeleteTriggerResponse
    {
        public bool success;
    }
}