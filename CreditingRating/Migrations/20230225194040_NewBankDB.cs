using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditingRating.Migrations
{
    /// <inheritdoc />
    public partial class NewBankDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "client_credit_recent_inquiries",
                table: "credit_history",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "client_rating",
                table: "BankClients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "client_credit_recent_inquiries",
                table: "credit_history");

            migrationBuilder.DropColumn(
                name: "client_rating",
                table: "BankClients");
        }
    }
}
