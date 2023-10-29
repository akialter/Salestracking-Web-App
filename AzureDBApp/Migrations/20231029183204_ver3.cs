using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureDBApp.Migrations
{
    /// <inheritdoc />
    public partial class ver3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "DiscountEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YearQuarter",
                table: "CommissionResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "DiscountEntity");

            migrationBuilder.DropColumn(
                name: "YearQuarter",
                table: "CommissionResults");
        }
    }
}
