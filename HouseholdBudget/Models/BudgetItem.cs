using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseholdBudget.Models
{
    public class BudgetItem
    {
       
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public float TargetAmount { get; set; }
        public float CurrentAmount { get; set; }



        public virtual Budget Budget { get; set; }

    }
}