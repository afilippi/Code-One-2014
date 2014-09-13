using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeOneFinancialManagerMK2.Controllers.RequestResponse
{
    public class GetAccountRequest
    {
        public int AccountID;
    }

    public class GetAccountResponse
    {
        public Account Account;
    }

    public class PostAccountRequest
    {
        public int Id;
        public int AccountOwnerID;
        public string AccountType;
        public Nullable<double> Balance;
        public Nullable<double> SavingBalance;
    }

    public class PostAccountResponse
    {
        public bool success;
    }

    public class DeleteAccountRequest
    {
        public int id;
    }

    public class DeleteAccountResponse
    {
        public bool success;
    }
}