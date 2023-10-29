using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureDBApp.Migrations
{
    /// <inheritdoc />
    public partial class quartley : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommissionResults",
                columns: table => new
                {
                    SalespersonFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalespersonLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCommission = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommissionResults");
        }
    }
}
