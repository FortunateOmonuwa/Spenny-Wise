using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Spenny_Wise.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetCategories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 200, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Importance = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budgets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseCategories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfExpense = table.Column<DateTime>(type: "datetime", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BudgetItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BudgetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BudgetId1 = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetItems_Budgets_BudgetId1",
                        column: x => x.BudgetId1,
                        principalTable: "Budgets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BudgetCategories",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Housing", null },
                    { 2, "Food", null },
                    { 3, "Transportation", null },
                    { 4, "Debt Payments", null },
                    { 5, "Saving", null },
                    { 6, "Health & Wellness", null },
                    { 7, "Insurance", null },
                    { 8, "Personal Care", null },
                    { 9, "Entertainment", null },
                    { 10, "Education", null },
                    { 11, "Giving", null },
                    { 12, "Pets", null },
                    { 13, "Miscellaneous", null },
                    { 14, "Business Expenses", null },
                    { 15, "Professional Development", null },
                    { 16, "Streaming Services", null },
                    { 17, "Personal Development", null },
                    { 18, "Home Improvement", null },
                    { 19, "Travel", null }
                });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Food", null },
                    { 2, "Tithing", null },
                    { 3, "Transportation", null },
                    { 4, "Data", null },
                    { 5, "Snacks", null },
                    { 6, "Beverages", null },
                    { 7, "Restaurants", null },
                    { 8, "Housing", null },
                    { 9, "Dates", null },
                    { 10, "Lease Payment", null },
                    { 11, "Loan Payment", null },
                    { 12, "Rent", null },
                    { 13, "Subscriptions", null },
                    { 14, "Entertainment", null },
                    { 15, "Miscellaneous", null },
                    { 16, "Health", null },
                    { 17, "Deodorant", null },
                    { 18, "No Idea", null },
                    { 19, "Birthdays", null },
                    { 20, "Holidays", null },
                    { 21, "Personal Development", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCategories_UserId",
                table: "BudgetCategories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetItems_BudgetId1",
                table: "BudgetItems",
                column: "BudgetId1");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_UserId",
                table: "Budgets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategories_UserId",
                table: "ExpenseCategories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetCategories");

            migrationBuilder.DropTable(
                name: "BudgetItems");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
