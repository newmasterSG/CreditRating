using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditingRating.Migrations
{
    /// <inheritdoc />
    public partial class BankDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    bank_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.bank_id);
                });

            migrationBuilder.CreateTable(
                name: "credit_history",
                columns: table => new
                {
                    credit_histoy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    client_credit_utilization = table.Column<double>(type: "float", nullable: false),
                    client_age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credit_history", x => x.credit_histoy_id);
                });

            migrationBuilder.CreateTable(
                name: "customer_contact",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    person_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    person_surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    person_gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    person_birthday = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    person_age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_contact", x => x.person_id);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_salary = table.Column<double>(type: "float", nullable: false),
                    credit_histoy_id = table.Column<int>(type: "int", nullable: false),
                    person_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.client_id);
                    table.ForeignKey(
                        name: "FK_client_credit_history_credit_histoy_id",
                        column: x => x.credit_histoy_id,
                        principalTable: "credit_history",
                        principalColumn: "credit_histoy_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_client_customer_contact_person_id",
                        column: x => x.person_id,
                        principalTable: "customer_contact",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankClients",
                columns: table => new
                {
                    bank_id = table.Column<int>(type: "int", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    bank_client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankClients", x => new { x.client_id, x.bank_id });
                    table.ForeignKey(
                        name: "FK_BankClients_Bank_bank_id",
                        column: x => x.bank_id,
                        principalTable: "Bank",
                        principalColumn: "bank_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankClients_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankClients_bank_id",
                table: "BankClients",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_client_credit_histoy_id",
                table: "client",
                column: "credit_histoy_id");

            migrationBuilder.CreateIndex(
                name: "IX_client_person_id",
                table: "client",
                column: "person_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankClients");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "credit_history");

            migrationBuilder.DropTable(
                name: "customer_contact");
        }
    }
}
