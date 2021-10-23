using BudgetWise.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetWise.Api
{
    public class BudgetWiseDbContext : DbContext
    {
        public DbSet<CategoriesEntity> Categories { get; set; }
        public DbSet<LabelsEntity> Labels { get; set; }
        public DbSet<TransactionsEntity> Transactions { get; set; }
        public DbSet<UsersEntity> Users { get; set; }

        public BudgetWiseDbContext(DbContextOptions<BudgetWiseDbContext> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureLabels();
            modelBuilder.ConfigureTransactions();
            modelBuilder.ConfigureCategories();
        }
    }
}