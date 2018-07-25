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

        public async Task<Households> GetHouseholdData(int houseID)
        {
            return await Database.SqlQuery<Households>("GetHousehold @houseID",
                new SqlParameter("houseID", houseID)).FirstOrDefaultAsync();
        }

        public async Task<Transactions> GetTransactions(int accountID)
        {
            return await Database.SqlQuery<Transactions>("GetTransactions @accountID",
                new SqlParameter("accountID", accountID)).FirstOrDefaultAsync();
        }

        public async Task<Budgets> GetBudgets(int houseID)
        {
            return await Database.SqlQuery<Budgets>("GetBudgets @houseID",
                new SqlParameter("houseID", houseID)).FirstOrDefaultAsync();
        }

        public async Task<Accounts> GetAccounts(int houseID)
        {
            return await Database.SqlQuery<Accounts>("GetAccounts @houseID",
                new SqlParameter("houseID", houseID)).FirstOrDefaultAsync();
        }

        public int AddAccount(decimal total, string category, int houseID, int bank, string userID)
        {
            return Database.ExecuteSqlCommand("AddAccount @total, @category, @houseID, @bank, @userID",
               new SqlParameter("total", total),
               new SqlParameter("category", category),
               new SqlParameter("houseID", houseID),
               new SqlParameter("bank", bank),
               new SqlParameter("userID", userID));
        }

        public int AddBudget(int houseID, string category, decimal current, decimal total)
        {
            return Database.ExecuteSqlCommand("AddBudget @houseID, @category, @current, @total",
               new SqlParameter("total", total),
               new SqlParameter("current", current),
               new SqlParameter("houseID", houseID),
               new SqlParameter("category", category));
        }

        public int AddTransaction(string type, string name, string description, decimal cost, DateTime Created, int HouseholdID, int accountID)
        {
            return Database.ExecuteSqlCommand("AddTransactionWithDate @type, @name, @description, @cost, @Created, @householdID, @accountID",

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