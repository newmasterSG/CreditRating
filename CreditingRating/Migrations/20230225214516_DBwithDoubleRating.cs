using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditingRating.Migrations
{
    /// <inheritdoc />
    public partial class DBwithDoubleRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "client_rating",
                table: "BankClients",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "client_rating",
                table: "BankClients",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
