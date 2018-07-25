using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancePlannerAPI.Models
{
    public class Accounts
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }
        public int HouseholdID { get; set; }
        public int BankID { get; set; }
        public string UserID { get; set; }
    }
}