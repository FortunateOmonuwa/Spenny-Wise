using Microsoft.EntityFrameworkCore;
using Spenny_Wise.WebAPI.Domain.Models;
using Spenny_Wise.WebAPI.Domain.Models.BudgetEntities;
using Spenny_Wise.WebAPI.Domain.Models.ExpenseEntities;
using Spenny_Wise.WebAPI.Domain.Models.UserEntity;

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
            modelBuilder.Entity<User>()
           .HasData(new User
           {
               Email = "initial@gmail.com",
               DateCreated = DateTime.Now.ToShortDateString(),
               Id = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf"),
               Name = "test test test",
               FirstName = "test",
               LastName = "test",
               MiddleName = "test",
               PhoneNumber = "1234567",
               
           });
        
            modelBuilder.Entity<BudgetCategory>()
       .HasData(
           new BudgetCategory { Id = 1, Name = "Housing", UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 2, Name = "Food", UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 3, Name = "Transportation", UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 4, Name = "Debt Payments" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 5, Name = "Saving", UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 6, Name = "Health & Wellness", UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 7, Name = "Insurance" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 8, Name = "Personal Care" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 9, Name = "Entertainment" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 10, Name = "Education" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 11, Name = "Giving"  , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 12, Name = "Pets"  , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 13, Name = "Miscellaneous" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 14, Name = "Business Expenses" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 15, Name = "Professional Development" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 16, Name = "Streaming Services" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 17, Name = "Personal Development" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 18, Name = "Home Improvement" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
           new BudgetCategory { Id = 19, Name = "Travel" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") }
       );
            modelBuilder.Entity<BudgetCategory>().HasIndex(x => x.UserId);
            modelBuilder.Entity<ExpenseCategory>().HasIndex(x => x.UserId);
            modelBuilder.Entity<ExpenseCategory>()
                .HasData(
                    new ExpenseCategory { Id = 1, Name = "Food", UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 2, Name = "Tithing", UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 3, Name = "Transportation", UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 4, Name = "Data", UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 5, Name = "Snacks", UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 6, Name = "Beverages", UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 7, Name = "Restaurants" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 8, Name = "Housing" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 9, Name = "Dates" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 10, Name = "Lease Payment" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 11, Name = "Loan Payment" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 12, Name = "Rent" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 13, Name = "Subscriptions" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 14, Name = "Entertainment" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") }, 
                    new ExpenseCategory { Id = 15, Name = "Miscellaneous" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 16, Name = "Health" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 17, Name = "Deodorant" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 18, Name = "No Idea" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 19, Name = "Birthdays" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 20, Name = "Holidays" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    new ExpenseCategory { Id = 21, Name = "Personal Development" , UserId = new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") }
                );

            modelBuilder.Entity<Role>().HasData(
               new Role { Id = Guid.Parse("A1B2C3D4-E5F6-47A8-B9C0-D1E2F3A4B5C6"), Name = "Admin" },
               new Role { Id = Guid.Parse("B2C3D4E5-F6A7-58B8-C9D0-E1F2A3B4C5D6"), Name = "User" }
                );
            modelBuilder.Entity<UserRole>().HasKey(k => new { k.RoleId, k.UserId });
            modelBuilder.Entity<UserRole>().HasOne(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<UserRole>().HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<UserAuth>().HasIndex(x => x.UserId);
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set;}
        public DbSet<BudgetCategory> BudgetCategories { get; set;}
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserAuth> UserAuthentication { get; set; }
    }
}
