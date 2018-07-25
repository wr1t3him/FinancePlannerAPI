using FinancePlannerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinancePlannerAPI.Controllers
{
    [RoutePrefix("api/Service")]
    public class ServicesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Here are four methods that call the "Add" type of Stored Proc...Inserting new records in our DB
        /// <summary>
        /// Add a new Account Function
        /// </summary>
        /// <param name="category">Account Type</param>
        /// <param name="bank">BankID</param>
        /// <param name="Home">HouseholdID</param>
        /// <param name="total">Total amount in the account</param>
        /// <param name="User">Account UserID</param>
        /// <returns>Integer indicating if Insert was successful</returns>
        [Route("AddAccount")]
        [AcceptVerbs("GET")]
        public int AddAccount(decimal total, string category, int houseID, int bank, string userID)
        {
            return db.AddAccount(total, category, houseID, bank, userID);
        }

        /// <summary>
        /// Add a new budget Function
        /// </summary>
        /// <param name="houseID">HouseholdID</param>
        /// <param name="category">Budget type</param>
        /// <param name="total">Limit of the Budget</param>
        /// <param name="current">Current Balance of the Budget</param>
        /// <returns>Integer indicating if Insert was successful</returns>
        [Route("AddBudget")]
        [AcceptVerbs("GET")]
        public int AddBudget(int houseID, string category, decimal current, decimal total)
        {
            return db.AddBudget(houseID, category, current, total);
        }
    }
}
