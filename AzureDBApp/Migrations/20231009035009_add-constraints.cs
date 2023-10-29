using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureDBApp.Migrations
{
    /// <inheritdoc />
    public partial class addconstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DiscountEntity_ProductId",
                table: "DiscountEntity");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountEntity_ProductId_BeginDate_EndDate",
                table: "DiscountEntity",
                columns: new[] { "ProductId", "BeginDate", "EndDate" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DiscountEntity_ProductId_BeginDate_EndDate",
                table: "DiscountEntity");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountEntity_ProductId",
                table: "DiscountEntity",
                column: "ProductId");
        }
    }
}
