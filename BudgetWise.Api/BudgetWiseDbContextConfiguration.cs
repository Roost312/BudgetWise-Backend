using BudgetWise.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetWise.Api
{
    public static class BudgetWiseDbContextConfiguration
    {
        public static void ConfigureLabels(this ModelBuilder builder)
        {
            builder.Entity<LabelsEntity>()
                .HasOne(le => le.Category)
                .WithMany(ce => ce.CategoryLabels);
        }

        public static void ConfigureTransactions(this ModelBuilder builder)
        {
            builder.Entity<TransactionsEntity>()
                .HasOne(te => te.Label)
                .WithMany(le => le.LabelTransactions);
            
            builder.Entity<TransactionsEntity>()
                .HasOne(te => te.User)
                .WithMany(ue => ue.UserTransactions);
        }

        public static void ConfigureCategories(this ModelBuilder builder)
        {
            builder.Entity<CategoriesEntity>()
                .HasOne(ce => ce.User)
                .WithMany(ue => ue.UserCategories);
        }
    }
}