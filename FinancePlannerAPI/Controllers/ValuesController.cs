using FinancePlannerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FinancePlannerAPI.Controllers
{
    [RoutePrefix("Api")]
    public class ValuesController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [Route("GetHouse")]
        public async Task<Households> GetHouseholdData(int houseID)
        {
            return await db.GetHouseholdData(houseID);
        }

        [Route("GetTransactions")]
        public async Task<Transactions> GetTransactions(int accountID)
        {
            return await db.GetTransactions(accountID);
        }

        [Route("GetTransactionDetails")]
        public async Task<Transactions> GetTransactionDetails(int transactionID)
        {
            return await db.GetTransactionDetails(transactionID);
        }

        [Route("GetBudgets")]
        public async Task<Budgets> GetBudgets(int houseID)
        {
            return await db.GetBudgets(houseID);
        }

        [Route("GetBudgetDetails")]
        public async Task<Budgets> GetBudgetDetails(int budgetID)
        {
            return await db.GetBudgetDetails(budgetID);
        }

        [Route("GetBudgetItem")]
        public async Task<BudgetItems> GetBudgetItem(int BudgetID)
        {
            return await db.GetBudgetItem(BudgetID);
        }

        [Route("GetBudgetItemDetails")]
        public async Task<BudgetItems> GetBudgetItemDetails(int budgetItemID)
        {
            return await db.GetBudgetItemDetails(budgetItemID);
        }

        [Route("GetAccounts")]
        public async Task<Accounts> GetAccounts(int houseID)
        {
            return await db.GetAccounts(houseID);
        }

        [Route("GetAccountDetails")]
        public async Task<Accounts> GetAccountDetails(int accountID)
        {
            return await db.GetAccountDetails(accountID);
        }

        [Route("AddAccount")]
        [AcceptVerbs("GET")]
        public int AddAccount(decimal total, string category, int houseID, int bank, string userID)
        {
            return db.AddAccount(total, category, houseID, bank, userID);
        }

        [Route("AddBudget")]
        [AcceptVerbs("GET")]
        public int AddBudget(int houseID, string category, decimal current, decimal total)
        {
            return db.AddBudget(houseID, category, current, total);
        }

        [Route("AddTransaction")]
        [AcceptVerbs("GET")]
        public int AddTransaction(string type, string name, string description, decimal cost, DateTime Created, int HouseholdID, int accountID)
        {
            return db.AddTransaction(type,  name, description, cost, Created, HouseholdID, accountID);
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
