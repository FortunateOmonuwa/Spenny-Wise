﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spenny_Wise.WebAPI.Data_Access;

#nullable disable

namespace Spenny_Wise.WebAPI.Migrations
{
    [DbContext(typeof(SpennyContext))]
    [Migration("20240320224504_Third Migration")]
    partial class ThirdMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Spenny_Wise.WebAPI.Domain.Models.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Importance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("Spenny_Wise.WebAPI.Domain.Models.BudgetCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BudgetCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Housing"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Transportation"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Debt Payments"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Saving"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Health & Wellness"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Insurance"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Personal Care"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Entertainment"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Education"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Giving"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Pets"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Miscellaneous"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Business Expenses"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Professional Development"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Streaming Services"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Personal Development"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Home Improvement"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Travel"
                        });
                });

            modelBuilder.Entity("Spenny_Wise.WebAPI.Domain.Models.BudgetItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("BudgetId1")
                        .HasColumnType("int");

                    b.Property<string>("MaxAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MinAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId1");

                    b.ToTable("BudgetItems");
                });

            modelBuilder.Entity("Spenny_Wise.WebAPI.Domain.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfExpense")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Spenny_Wise.WebAPI.Domain.Models.ExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ExpenseCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tithing"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Transportation"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Data"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Snacks"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Beverages"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Restaurants"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Housing"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Dates"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Lease Payment"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Loan Payment"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Rent"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Subscriptions"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Entertainment"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Miscellaneous"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Health"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Deodorant"
                        },
                        new
                        {
                            Id = 18,
                            Name = "No Idea"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Birthdays"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Holidays"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Personal Development"
                        });
                });

            modelBuilder.Entity("Spenny_Wise.WebAPI.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Spenny_Wise.WebAPI.Domain.Models.Budget", b =>
                {
                    b.HasOne("Spenny_Wise.WebAPI.Domain.Models.User", null)
                        .WithMany("Budgets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Spenny_Wise.WebAPI.Domain.Models.BudgetCategory", b =>
                {
                    b.HasOne("Spenny_Wise.WebAPI.Domain.Models.User", null)
                        .WithMany("Categories")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Spenny_Wise.WebAPI.Domain.Models.BudgetItem", b =>
                {
                    b.HasOne("Spenny_Wise.WebAPI.Domain.Models.Budget", null)
                        .WithMany("BudgetItems")
                        .HasForeignKey("BudgetId1");
                });

            modelBuilder.Entity("Spenny_Wise.WebAPI.Domain.Models.Expense", b =>
                {
                    b.HasOne("Spenny_Wise.WebAPI.Domain.Models.User", null)
                        .WithMany("Expenses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Spenny_Wise.WebAPI.Domain.Models.Budget", b =>
                {
                    b.Navigation("BudgetItems");
                });

            modelBuilder.Entity("Spenny_Wise.WebAPI.Domain.Models.User", b =>
                {
                    b.Navigation("Budgets");

                    b.Navigation("Categories");

                    b.Navigation("Expenses");
                });
#pragma warning restore 612, 618
        }
    }
}
