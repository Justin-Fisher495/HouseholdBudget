namespace HouseholdBudget.Migrations
{
    using HouseholdBudget.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HouseholdBudget.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HouseholdBudget.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            #region Roles

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "HeadOfHousehold"))
            {
                roleManager.Create(new IdentityRole { Name = "HeadOfHousehold" });
            }

            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                roleManager.Create(new IdentityRole { Name = "Member" });
            }

            #endregion

            #region Users

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var demoPassword = "Abc!123@";



            if (!context.Users.Any(u => u.Email == ""))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "Fish",
                    Email = "Justin.Fisher495@gmail.com",
                    FirstName = "Justin",
                    LastName = "Fisher",
                    DisplayName = "Justin Fisher",
                    HouseholdId = 1
                }, demoPassword);
            }

            if (!context.Users.Any(u => u.Email == ""))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "LadyFish",
                    Email = "Amfisher89@gmail.com",
                    FirstName = "Amber",
                    LastName = "Fisher",
                    DisplayName = "Amber Fisher",
                    HouseholdId = 1
                }, demoPassword);
            }

            if (!context.Users.Any(u => u.Email == ""))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "TommyP@mailinator.com",
                    Email = "TommyP@mailinator.com",
                    FirstName = "Tommy",
                    LastName = "Powers",
                    DisplayName = "Tommy Powers",
                    HouseholdId = 2
                }, demoPassword);
            }

            if (!context.Users.Any(u => u.Email == ""))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "KimP@mailinator.com",
                    Email = "KimP@mailinator.com",
                    FirstName = "Kim",
                    LastName = "Powers",
                    DisplayName = "Kim Powers",
                    HouseholdId = 2
                }, demoPassword);
            }

            if (!context.Users.Any(u => u.Email == ""))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "BillyP@mailinator.com",
                    Email = "BillyP@mailinator.com",
                    FirstName = "Billy",
                    LastName = "Powers",
                    DisplayName = "Billy Powers",
                    HouseholdId = 2
                }, demoPassword);
            }

            if (!context.Users.Any(u => u.Email == ""))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "JasonP@mailinator.com",
                    Email = "JasonP@mailinator.com",
                    FirstName = "Jason",
                    LastName = "Powers",
                    DisplayName = "Jason Powers",
                    HouseholdId = 2
                }, demoPassword);
            }

            if (!context.Users.Any(u => u.Email == ""))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ZackP@mailinator.com",
                    Email = "ZackP@mailinator.com",
                    FirstName = "Zack",
                    LastName = "Powers",
                    DisplayName = "Zack Powers",
                    HouseholdId = 2
                }, demoPassword);
            }

            if (!context.Users.Any(u => u.Email == ""))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "TriniP@mailinator.com",
                    Email = "TriniP@mailinator.com",
                    FirstName = "Trini",
                    LastName = "Powers",
                    DisplayName = "Trini Powers",
                    HouseholdId = 2
                }, demoPassword);
            }

            #endregion

            #region Assign Roles

            var userId = userManager.FindByEmail("justin.fisher495@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");

            userId = userManager.FindByEmail("Amfisher89@gmail.com").Id;
            userManager.AddToRole(userId, "HeadOfHousehold");

            userId = userManager.FindByEmail("TommyP@mailinator.com").Id;
            userManager.AddToRole(userId, "HeadOfHousehold");

            userId = userManager.FindByEmail("KimP@mailinator.com").Id;
            userManager.AddToRole(userId, "Member");

            userId = userManager.FindByEmail("BillyP@mailinator.com").Id;
            userManager.AddToRole(userId, "Member");

            userId = userManager.FindByEmail("JasonP@mailinator.com").Id;
            userManager.AddToRole(userId, "Member");

            userId = userManager.FindByEmail("ZackP@mailinator.com").Id;
            userManager.AddToRole(userId, "Member");

            userId = userManager.FindByEmail("TriniP@mailinator.com").Id;
            userManager.AddToRole(userId, "Member");

            #endregion

            #region Section for loading Lookup Data
            var user = userManager.FindByEmail("justin.fisher495@gmail.com");
            var codeGuid = Guid.NewGuid();

            //Invintations
            context.Invitations.AddOrUpdate(
              new Invitation { Id = 1, HouseholdId = 1, TTL = 7, Body = "Please Join.", IsValid = true, Created = DateTime.Now, RecipientEmail = "", Code = codeGuid }
          );
            //Household
            context.Households.AddOrUpdate(
                new Household { Id = 1, Created = DateTime.Now, Name = "The House", Greeting = "Welcome to my house" },
                new Household { Id = 2, Created = DateTime.Now, Name = "The Main", Greeting = "Welcome to my house" }
            );
            //Bank Accounts
            context.BankAccounts.AddOrUpdate(
                    new BankAccount { Id = 1, HouseholdId = 1, Created = DateTime.Now, Name = "Checking", OwnerId = user.Id, StartingBalance = 10000, CurrentBalance = 10000 },
                    new BankAccount { Id = 2, HouseholdId = 2, Created = DateTime.Now, Name = "Savings", OwnerId = user.Id, StartingBalance = 10000, CurrentBalance = 10000 }
                    );
            //Budgets
            context.Budgets.AddOrUpdate(
                new Budget { Id = 1, HouseholdId = 1, OwnerId = user.Id, Created = DateTime.Now, Name = "MyBudget", TargetAmount = 10000, CurrentAmount = 10000 }
                );
            context.SaveChanges();
            //Transactions
            context.Transactions.AddOrUpdate(
                new Transaction { Id = 1, BankAccountId = 1, OwnerId = user.Id, TransactionTypeId = 0, Created = DateTime.Now, Updated = DateTime.Now, Amount = 1000, Memo = "new", BudgetItemId = 0 }
                );
            //Budget Items
            context.BudgetItems.AddOrUpdate(
                new BudgetItem { BudgetId = 1, Created = DateTime.Now, Name = "Food", TargetAmount = 100, CurrentAmount = 2 }
                );
            #endregion




        }
    }
}
