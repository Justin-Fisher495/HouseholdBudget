using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseholdBudget.Models
{
    public class BankAccount
    {
        public BankAccount()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string OwnerId { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public string AccountType { get; set; }
        public float StartingBalance { get; set; }
        public float CurrentBalance { get; set; }

        public virtual Household Household { get; set; }
        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}