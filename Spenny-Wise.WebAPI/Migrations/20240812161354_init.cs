using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Spenny_Wise.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAuthentication",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passwordhash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationTokenExpiration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    VerifiedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExpiration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuthentication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 200, nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Importance = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfExpense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BudgetItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BudgetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetItems_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6"), "Admin" },
                    { new Guid("b2c3d4e5-f6a7-58b8-c9d0-e1f2a3b4c5d6"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "Email", "FirstName", "LastName", "MiddleName", "Name", "PhoneNumber" },
                values: new object[] { new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf"), "8/12/2024", "initial@gmail.com", "test", "test", "test", "test test test", "1234567" });

            migrationBuilder.InsertData(
                table: "BudgetCategories",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Housing", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 2, "Food", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 3, "Transportation", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 4, "Debt Payments", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 5, "Saving", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 6, "Health & Wellness", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 7, "Insurance", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 8, "Personal Care", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 9, "Entertainment", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 10, "Education", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 11, "Giving", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 12, "Pets", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 13, "Miscellaneous", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 14, "Business Expenses", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 15, "Professional Development", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 16, "Streaming Services", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 17, "Personal Development", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 18, "Home Improvement", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 19, "Travel", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") }
                });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Food", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 2, "Tithing", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 3, "Transportation", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 4, "Data", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 5, "Snacks", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 6, "Beverages", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 7, "Restaurants", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 8, "Housing", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 9, "Dates", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 10, "Lease Payment", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 11, "Loan Payment", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 12, "Rent", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 13, "Subscriptions", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 14, "Entertainment", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 15, "Miscellaneous", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 16, "Health", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 17, "Deodorant", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 18, "No Idea", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 19, "Birthdays", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 20, "Holidays", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") },
                    { 21, "Personal Development", new Guid("cb93e0a5-34a7-4a5a-9827-c6825ef6a7cf") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCategories_UserId",
                table: "BudgetCategories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetItems_BudgetId",
                table: "BudgetItems",
                column: "BudgetId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthentication_UserId",
                table: "UserAuthentication",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
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
                name: "UserAuthentication");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
