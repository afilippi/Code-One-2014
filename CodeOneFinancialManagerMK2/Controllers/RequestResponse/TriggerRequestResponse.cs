using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeOneFinancialManagerMK2.Controllers.RequestResponse
{
    public class GetTriggerRequest
    {
        public int AccountID;
    }

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
        public int id;
        public int AccountID;
        public String ActionID;
        public float CurrentAmount;
        public float TriggerAmount;
        public String MCC;
        public String TimeFrame;
        public String Trigger;
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