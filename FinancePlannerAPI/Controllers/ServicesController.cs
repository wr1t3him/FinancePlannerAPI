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

        /// <summary>
        /// Add a new Transaction passing in a custom Created Date
        /// </summary>
        /// <param name="type">Transaction type</param>
        /// <param name="name">Transaction Name</param>
        /// <param name="description">Transaction description</param>
        /// <param name="cost">Transaction Price</param>
        /// <param name="Created">Time of Transaction</param>
        /// <param name="HouseholdID">Household</param>
        /// <param name="accountID">Account used for Transaction</param>
        /// <returns>Integer indicating if Insert was successful</returns>
        [Route("AddTransaction")]
        [AcceptVerbs("GET")]
        public int AddTransaction(string type, string name, string description, decimal cost, DateTime Created, int HouseholdID, int accountID)
        {
            return db.AddTransaction(type, name, description, cost, Created, HouseholdID, accountID);
        }

        /// <summary>
        /// Full record of an Account
        /// </summary>
        /// <param name="houseID">HouseholdID</param>
        /// <returns></returns>
        [Route("GetAccounts")]
        public async Task<Accounts> GetAccounts(int houseID)
        {
            return await db.GetAccounts(houseID);
        }

        /// <summary>
        /// A Budget Item
        /// </summary>
        /// <param name="BudgetID">Budget Parameter</param>
        /// <returns></returns>
        [Route("GetBudgetItem")]
        public async Task<BudgetItems> GetBudgetItem(int BudgetID)
        {
            return await db.GetBudgetItem(BudgetID);
        }

        /// <summary>
        /// The full scope of a budget
        /// </summary>
        /// <param name="houseID">House Parameter</param>
        /// <returns></returns>
        [Route("GetBudgets")]
        public async Task<Budgets> GetBudgets(int houseID)
        {
            return await db.GetBudgets(houseID);
        }
        
        /// <summary>
        /// The full scope of a household
        /// </summary>
        /// <param name="houseID">Household Parameter</param>
        /// <returns></returns>
        [Route("GetHouse")]
        public async Task<Households> GetHouseholdData(int houseID)
        {
            return await db.GetHouseholdData(houseID);
        }

        /// <summary>
        /// The full scope of a Transaction
        /// </summary>
        /// <param name="accountID">Account Parameter</param>
        /// <returns></returns>
        [Route("GetTransactions")]
        public async Task<Transactions> GetTransactions(int accountID)
        {
            return await db.GetTransactions(accountID);
        }

        /// <summary>
        /// Detailed Information of a Account
        /// </summary>
        /// <param name="accountID">HouseholdID</param>
        /// <returns></returns>
        [Route("GetAccountDetails")]
        public async Task<Accounts> GetAccountDetails(int accountID)
        {
            return await db.GetAccountDetails(accountID);
        }

        /// <summary>
        /// Get the details of a Budget
        /// </summary>
        /// <param name="BudgetID">Budget Parameter</param>
        /// <returns></returns>
        [Route("GetBudgetDetails")]
        public async Task<Budgets> GetBudgetDetails(int budgetID)
        {
            return await db.GetBudgetDetails(budgetID);
        }

        /// <summary>
        /// Get the details of a Budget Item
        /// </summary>
        /// <param name="budgetItemID">BudgetID</param>
        /// <returns></returns>
        [Route("GetBudgetItemDetails")]
        public async Task<BudgetItems> GetBudgetItemDetails(int budgetItemID)
        {
            return await db.GetBudgetItemDetails(budgetItemID);
        }

        /// <summary>
        /// The details of a Transaction
        /// </summary>
        /// <param name="transactionID">Transaction Parameter</param>
        /// <returns></returns>
        [Route("GetTransactionDetails")]
        public async Task<Transactions> GetTransactionDetails(int transactionID)
        {
            return await db.GetTransactionDetails(transactionID);
        }
    }
}
