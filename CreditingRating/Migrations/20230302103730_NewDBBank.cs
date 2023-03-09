using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditingRating.Migrations
{
    /// <inheritdoc />
    public partial class NewDBBank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_client_credit_history_credit_histoy_id",
                table: "client");

            migrationBuilder.DropTable(
                name: "credit_history");

            migrationBuilder.DropIndex(
                name: "IX_client_credit_histoy_id",
                table: "client");

            migrationBuilder.DropColumn(
                name: "credit_histoy_id",
                table: "client");

            migrationBuilder.CreateTable(
                name: "client_credit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LatePayments = table.Column<int>(type: "int", nullable: false),
                    OpenedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_credit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_client_credit_client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_client_credit_ClientId",
                table: "client_credit",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client_credit");

            migrationBuilder.AddColumn<int>(
                name: "credit_histoy_id",
                table: "client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "credit_history",
                columns: table => new
                {
                    credit_histoy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_age = table.Column<int>(type: "int", nullable: false),
                    client_credit_utilization = table.Column<double>(type: "float", nullable: false),
                    PaymentHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    client_credit_recent_inquiries = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credit_history", x => x.credit_histoy_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_client_credit_histoy_id",
                table: "client",
                column: "credit_histoy_id");

            migrationBuilder.AddForeignKey(
                name: "FK_client_credit_history_credit_histoy_id",
                table: "client",
                column: "credit_histoy_id",
                principalTable: "credit_history",
                principalColumn: "credit_histoy_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
