// <auto-generated />
using System;
using BudgetWise.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BudgetWise.Api.Migrations
{
    [DbContext(typeof(BudgetWiseDbContext))]
    partial class BudgetWiseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BudgetWise.Api.Entities.CategoriesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BudgetWise.Api.Entities.LabelsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("AppliedAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("applied_amount");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("due_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("notes");

                    b.Property<decimal?>("PlannedAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("planned_amount");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("BudgetWise.Api.Entities.TransactionsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("amount");

                    b.Property<DateTime>("DateApplied")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_applied");

                    b.Property<int?>("LabelId")
                        .HasColumnType("int")
                        .HasColumnName("label_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("LabelId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BudgetWise.Api.Entities.UsersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("salt");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BudgetWise.Api.Entities.CategoriesEntity", b =>
                {
                    b.HasOne("BudgetWise.Api.Entities.UsersEntity", "User")
                        .WithMany("UserCategories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BudgetWise.Api.Entities.LabelsEntity", b =>
                {
                    b.HasOne("BudgetWise.Api.Entities.CategoriesEntity", "Category")
                        .WithMany("CategoryLabels")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BudgetWise.Api.Entities.TransactionsEntity", b =>
                {
                    b.HasOne("BudgetWise.Api.Entities.LabelsEntity", "Label")
                        .WithMany("LabelTransactions")
                        .HasForeignKey("LabelId");

                    b.HasOne("BudgetWise.Api.Entities.UsersEntity", "User")
                        .WithMany("UserTransactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Label");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BudgetWise.Api.Entities.CategoriesEntity", b =>
                {
                    b.Navigation("CategoryLabels");
                });

            modelBuilder.Entity("BudgetWise.Api.Entities.LabelsEntity", b =>
                {
                    b.Navigation("LabelTransactions");
                });

            modelBuilder.Entity("BudgetWise.Api.Entities.UsersEntity", b =>
                {
                    b.Navigation("UserCategories");

                    b.Navigation("UserTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
