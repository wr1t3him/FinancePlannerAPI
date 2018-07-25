using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancePlannerAPI.Models
{
    public class Transactions
    {
       public int ID { get; set; }
       public string Type { get; set; }
       public string Name { get; set; }
       public string description { get; set; }
       public decimal Cost { get; set; }
       public bool verify { get; set; }
       public DateTime Created { get; set; }
       public DateTime Updated { get; set; }
       public string UserID { get; set; }
       public int AccountID { get; set; }
       public int Household_ID { get; set; }
    }
}