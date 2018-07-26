﻿using System;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace FinancePlannerAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// A way to see the household information
        /// </summary>
        /// <param name="houseID"></param>
        /// <returns></returns>
        public async Task<Households> GetHouseholdData(int houseID)
        {
            return await Database.SqlQuery<Households>("GetHouseholdData @houseID",
                new SqlParameter("houseID", houseID)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Retrieve the data of a Transaction
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public async Task<Transactions> GetTransactions(int accountID)
        {
            return await Database.SqlQuery<Transactions>("GetTransactions @accountID",
                new SqlParameter("accountID", accountID)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// See the details of a Transaction
        /// </summary>
        /// <param name="transactionID"></param>
        /// <returns></returns>
        public async Task<Transactions> GetTransactionDetails(int transactionID)
        {
            return await Database.SqlQuery<Transactions>("GetTransactionDetails @transactionID",
                new SqlParameter("transactionID", transactionID)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Budget information data
        /// </summary>
        /// <param name="houseID"></param>
        /// <returns></returns>
        public async Task<Budgets> GetBudgets(int houseID)
        {
            return await Database.SqlQuery<Budgets>("GetBudgets @houseID",
                new SqlParameter("houseID", houseID)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Budget Details information
        /// </summary>
        /// <param name="budgetID"></param>
        /// <returns></returns>
        public async Task<Budgets> GetBudgetDetails(int budgetID)
        {
            return await Database.SqlQuery<Budgets>("GetBudgetDetails @budgetID",
                new SqlParameter("budgetID", budgetID)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// The summary of a Budget Item
        /// </summary>
        /// <param name="BudgetID"></param>
        /// <returns></returns>
        public async Task<BudgetItems> GetBudgetItem(int BudgetID)
        {
            return await Database.SqlQuery<BudgetItems>("GetBudgetItem @BudgetID",
                new SqlParameter("BudgetID", BudgetID)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Budget Item Details summary
        /// </summary>
        /// <param name="budgetItemID"></param>
        /// <returns></returns>
        public async Task<BudgetItems> GetBudgetItemDetails(int budgetItemID)
        {
            return await Database.SqlQuery<BudgetItems>("GetBudgetItemDetails @budgetItemID",
                new SqlParameter("budgetItemID", budgetItemID)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Account information summary
        /// </summary>
        /// <param name="houseID"></param>
        /// <returns></returns>
        public async Task<Accounts> GetAccounts(int houseID)
        {
            return await Database.SqlQuery<Accounts>("GetAccounts @houseID",
                new SqlParameter("houseID", houseID)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Account details summary
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public async Task<Accounts> GetAccountDetails(int accountID)
        {
            return await Database.SqlQuery<Accounts>("GetAccountDetails @accountID",
                new SqlParameter("accountID", accountID)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Open a new Account
        /// </summary>
        /// <param name="total"></param>
        /// <param name="category"></param>
        /// <param name="houseID"></param>
        /// <param name="bank"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int AddAccount(decimal total, string category, int houseID, int bank, string userID)
        {
            return Database.ExecuteSqlCommand("AddAccount @total, @category, @houseID, @bank, @userID",
               new SqlParameter("total", total),
               new SqlParameter("category", category),
               new SqlParameter("houseID", houseID),
               new SqlParameter("bank", bank),
               new SqlParameter("userID", userID));
        }

        /// <summary>
        /// Start a new budget
        /// </summary>
        /// <param name="houseID"></param>
        /// <param name="category"></param>
        /// <param name="current"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public int AddBudget(int houseID, string category, decimal current, decimal total)
        {
            return Database.ExecuteSqlCommand("AddBudget @houseID, @category, @current, @total",
               new SqlParameter("total", total),
               new SqlParameter("current", current),
               new SqlParameter("houseID", houseID),
               new SqlParameter("category", category));
        }

        /// <summary>
        /// Add a new transaction
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="cost"></param>
        /// <param name="Created"></param>
        /// <param name="HouseholdID"></param>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public int AddTransaction(string type, string name, string description, decimal cost, DateTime Created, int HouseholdID, int accountID)
        {
            return Database.ExecuteSqlCommand("AddTransaction @type, @name, @description, @cost, @Created, @householdID, @accountID",

               new SqlParameter("type", type),
               new SqlParameter("name", name),
               new SqlParameter("description", description),
               new SqlParameter("cost", cost),
               new SqlParameter("Created", Created),
               new SqlParameter("HouseholdID", HouseholdID),
               new SqlParameter("accountID", accountID));
        }
    }
}