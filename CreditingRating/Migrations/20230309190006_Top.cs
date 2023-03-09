using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditingRating.Migrations
{
    /// <inheritdoc />
    public partial class Top : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "client_credit");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "client_credit");

            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "client_credit");

            migrationBuilder.DropColumn(
                name: "MonthlyPayment",
                table: "client_credit");

            migrationBuilder.RenameColumn(
                name: "LatePayments",
                table: "client_credit",
                newName: "LatePayment");

            migrationBuilder.AddColumn<int>(
                name: "AvailableCredit",
                table: "client_credit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "MoneySpent",
                table: "client_credit",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "client_credit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableCredit",
                table: "client_credit");

            migrationBuilder.DropColumn(
                name: "MoneySpent",
                table: "client_credit");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "client_credit");

            migrationBuilder.RenameColumn(
                name: "LatePayment",
                table: "client_credit",
                newName: "LatePayments");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "client_credit",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "client_credit",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "client_credit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyPayment",
                table: "client_credit",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
