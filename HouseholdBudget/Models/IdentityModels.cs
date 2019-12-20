using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HouseholdBudget.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Notifications = new HashSet<Notification>();
            BankAccounts = new HashSet<BankAccount>();
            Transactions = new HashSet<Transaction>();
            Budgets = new HashSet<Budget>();
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string AvatarPath { get; set; }

        public int? HouseholdId { get; set; }

        public virtual Household Household { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
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
        public DbSet<Household> Households { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<HouseholdBudget.Models.BankAccount> BankAccounts { get; set; }

        public System.Data.Entity.DbSet<HouseholdBudget.Models.Budget> Budgets { get; set; }

        public System.Data.Entity.DbSet<HouseholdBudget.Models.BudgetItem> BudgetItems { get; set; }
                
        public System.Data.Entity.DbSet<HouseholdBudget.Models.Notification> Notifications { get; set; }

        public System.Data.Entity.DbSet<HouseholdBudget.Models.Transaction> Transactions { get; set; }

        public System.Data.Entity.DbSet<HouseholdBudget.Models.Invitation> Invitations { get; set; }
    }
}