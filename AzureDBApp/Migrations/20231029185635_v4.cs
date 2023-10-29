using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureDBApp.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "DiscountEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "DiscountEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
