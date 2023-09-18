using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ATM.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    LastWithdrawalDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pin = table.Column<short>(type: "smallint", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    FailedAttempts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    BalanceBefore = table.Column<float>(type: "real", nullable: true),
                    BalanceAfter = table.Column<float>(type: "real", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "LastWithdrawalDate", "Username" },
                values: new object[,]
                {
                    { 1, 12345678, 9000f, new DateTime(2023, 8, 18, 0, 34, 46, 154, DateTimeKind.Local).AddTicks(3316), "Bruce Wayne" },
                    { 2, 98765432, 450f, new DateTime(2023, 7, 18, 0, 34, 46, 154, DateTimeKind.Local).AddTicks(3337), "Indiana Jones" },
                    { 3, 11111110, 1800f, new DateTime(2023, 6, 18, 0, 34, 46, 154, DateTimeKind.Local).AddTicks(3338), "Darth Vader" },
                    { 4, 22222220, 675f, new DateTime(2023, 5, 18, 0, 34, 46, 154, DateTimeKind.Local).AddTicks(3339), "Jack Sparrow" },
                    { 5, 33333333, 1050f, new DateTime(2023, 4, 18, 0, 34, 46, 154, DateTimeKind.Local).AddTicks(3340), "John Rambo" },
                    { 6, 44444444, 270f, new DateTime(2023, 3, 18, 0, 34, 46, 154, DateTimeKind.Local).AddTicks(3342), "Peter Parker" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "AccountId", "CardNumber", "FailedAttempts", "IsLocked", "Pin" },
                values: new object[,]
                {
                    { 1, 1, "111222333444", 0, false, (short)1234 },
                    { 2, 2, "555666777888", 0, false, (short)5678 },
                    { 3, 3, "999888777666", 0, false, (short)9876 },
                    { 4, 4, "333222111000", 0, false, (short)3210 },
                    { 5, 5, "777666555444", 0, false, (short)7654 },
                    { 6, 6, "222333444555", 0, false, (short)2345 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "BalanceAfter", "BalanceBefore", "CardId", "TransactionDate", "TransactionType" },
                values: new object[,]
                {
                    { 1, 1000f, 9000f, 10000f, 1, new DateTime(2023, 9, 18, 0, 34, 46, 154, DateTimeKind.Local).AddTicks(3385), 1 },
                    { 2, 50f, 450f, 500f, 2, new DateTime(2023, 9, 18, 0, 34, 46, 154, DateTimeKind.Local).AddTicks(3387), 1 },
                    { 3, 200f, 1800f, 2000f, 3, new DateTime(2023, 9, 18, 0, 34, 46, 154, DateTimeKind.Local).AddTicks(3388), 1 },
                    { 4, 75f, 675f, 750f, 4, new DateTime(2023, 9, 18, 0, 34, 46, 154, DateTimeKind.Local).AddTicks(3389), 1 },
                    { 5, 150f, 1050f, 1200f, 5, new DateTime(2023, 9, 18, 0, 34, 46, 154, DateTimeKind.Local).AddTicks(3389), 1 },
                    { 6, 30f, 270f, 300f, 6, new DateTime(2023, 9, 18, 0, 34, 46, 154, DateTimeKind.Local).AddTicks(3391), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AccountId",
                table: "Cards",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CardId",
                table: "Transactions",
                column: "CardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
