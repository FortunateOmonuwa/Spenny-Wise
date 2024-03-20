using Microsoft.EntityFrameworkCore;
using Spenny_Wise.WebAPI.Domain.Models;

namespace Spenny_Wise.WebAPI.Data_Access
{
    public class SpennyContext : DbContext
    {
        public SpennyContext(DbContextOptions<SpennyContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BudgetCategory>()
       .HasData(
           new BudgetCategory { Id = 1, Name = "Housing" },
           new BudgetCategory { Id = 2, Name = "Food" },
           new BudgetCategory { Id = 3, Name = "Transportation" },
           new BudgetCategory { Id = 4, Name = "Debt Payments" },
           new BudgetCategory { Id = 5, Name = "Saving" },
           new BudgetCategory { Id = 6, Name = "Health & Wellness" },
           new BudgetCategory { Id = 7, Name = "Insurance" },
           new BudgetCategory { Id = 8, Name = "Personal Care" },
           new BudgetCategory { Id = 9, Name = "Entertainment" },
           new BudgetCategory { Id = 10, Name = "Education" },
           new BudgetCategory { Id = 11, Name = "Giving" },
           new BudgetCategory { Id = 12, Name = "Pets" },
           new BudgetCategory { Id = 13, Name = "Miscellaneous" },
           new BudgetCategory { Id = 14, Name = "Business Expenses" },
           new BudgetCategory { Id = 15, Name = "Professional Development" },
           new BudgetCategory { Id = 16, Name = "Streaming Services" },
           new BudgetCategory { Id = 17, Name = "Personal Development" },
           new BudgetCategory { Id = 18, Name = "Home Improvement" },
           new BudgetCategory { Id = 19, Name = "Travel" }
       );

            modelBuilder.Entity<ExpenseCategory>()
                .HasData(
                    new ExpenseCategory { Id = 1, Name = "Food" },
                    new ExpenseCategory { Id = 2, Name = "Tithing" },
                    new ExpenseCategory { Id = 3, Name = "Transportation" },
                    new ExpenseCategory { Id = 4, Name = "Data" },
                    new ExpenseCategory { Id = 5, Name = "Snacks" },
                    new ExpenseCategory { Id = 6, Name = "Beverages" },
                    new ExpenseCategory { Id = 7, Name = "Restaurants" },
                    new ExpenseCategory { Id = 8, Name = "Housing" },
                    new ExpenseCategory { Id = 9, Name = "Dates" },
                    new ExpenseCategory { Id = 10, Name = "Lease Payment" },
                    new ExpenseCategory { Id = 11, Name = "Loan Payment" },
                    new ExpenseCategory { Id = 12, Name = "Rent" },
                    new ExpenseCategory { Id = 13, Name = "Subscriptions" },
                    new ExpenseCategory { Id = 14, Name = "Entertainment" }, 
                    new ExpenseCategory { Id = 15, Name = "Miscellaneous" },
                    new ExpenseCategory { Id = 16, Name = "Health" },
                    new ExpenseCategory { Id = 17, Name = "Deodorant" },
                    new ExpenseCategory { Id = 18, Name = "No Idea" },
                    new ExpenseCategory { Id = 19, Name = "Birthdays" },
                    new ExpenseCategory { Id = 20, Name = "Holidays" },
                    new ExpenseCategory { Id = 21, Name = "Personal Development" }
                );
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set;}
        public DbSet<ExpenseItem>  ExpenseItems { get; set; }
        public DbSet<BudgetCategory> BudgetCategories { get; set;}
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    }
}
