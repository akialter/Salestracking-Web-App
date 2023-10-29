using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AzureDBApp.Migrations
{
    /// <inheritdoc />
    public partial class initvalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Products_ProductId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Salespersons_SalespersonId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "SalesEntity");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "DiscountEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_SalespersonId",
                table: "SalesEntity",
                newName: "IX_SalesEntity_SalespersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_ProductId",
                table: "SalesEntity",
                newName: "IX_SalesEntity_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Discounts_ProductId",
                table: "DiscountEntity",
                newName: "IX_DiscountEntity_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Salespersons",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesEntity",
                table: "SalesEntity",
                column: "SalesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscountEntity",
                table: "DiscountEntity",
                column: "DiscountId");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "FirstName", "LastName", "Phone", "StartDate" },
                values: new object[,]
                {
                    { 1, "635 Anthes Road", "Laurella", "Sperling", "9921913996", new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "98015 Sommers Drive", "Darcey", "Flageul", "6904109725", new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "8037 Elka Way", "Harbert", "Rangall", "2401862328", new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "0957 Sauthoff Hill", "Krista", "Antonomolii", "2417565632", new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "32095 Carberry Avenue", "Shayne", "Tawn", "7643885563", new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "63322 Alpine Pass", "Caesar", "Myrkus", "1581037119", new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "82412 Kropf Street", "Antonia", "O'Cassidy", "6599430956", new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "10868 Steensland Center", "Carlota", "MacAnespie", "4855246191", new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "6705 Express Parkway", "Schuyler", "Butt", "4251880754", new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "730 Derek Crossing", "Eolande", "Beadle", "7055238579", new DateTime(2022, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CommissionPercentage", "Manufacturer", "Name", "PurchasePrice", "QtyOnHand", "SalePrice", "Style" },
                values: new object[,]
                {
                    { 1, 26.09, "Ram 1500", "Dodge", 2068.27m, 15, 7091.88m, "Green" },
                    { 2, 6.5099999999999998, "Astra", "Saturn", 1269.35m, 17, 6498.63m, "Green" },
                    { 3, 11.369999999999999, "9000", "Saab", 917.25m, 4, 9515.26m, "Goldenrod" },
                    { 4, 27.710000000000001, "XC90", "Volvo", 1783.00m, 4, 9831.89m, "Violet" },
                    { 5, 29.329999999999998, "Venza", "Toyota", 3953.84m, 11, 8035.80m, "Blue" },
                    { 6, 13.35, "Century", "Buick", 4455.92m, 8, 9920.71m, "Yellow" },
                    { 7, 26.739999999999998, "xB", "Scion", 544.53m, 7, 9906.81m, "Indigo" },
                    { 8, 15.470000000000001, "Escalade", "Cadillac", 1859.92m, 9, 9183.55m, "Yellow" },
                    { 9, 5.3899999999999997, "Diablo", "Lamborghini", 4977.57m, 2, 6479.80m, "Maroon" },
                    { 10, 16.75, "Ram", "Dodge", 4131.49m, 15, 8337.38m, "Blue" }
                });

            migrationBuilder.InsertData(
                table: "Salespersons",
                columns: new[] { "SalespersonId", "Address", "FirstName", "LastName", "Manager", "Phone", "StartDate", "TerminationDate" },
                values: new object[,]
                {
                    { 1, "99477 Clarendon Terrace", "Melantha", "Palmer", "Teddy", "2559760515", new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "62265 Ludington Way", "Prentice", "Fuggles", "Werner", "4952904231", new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "02 Holmberg Court", "Udall", "Iacovides", "Brandtr", "1098678048", new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "47 Prentice Center", "Yves", "Grabham", "Stefan", "3302522709", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "5 Di Loreto Trail", "Robinett", "Raw", "Sol", "8477849692", new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "02 Maple Wood Circle", "Sargent", "Vedenyapin", "Padriac", "8062170689", new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "4 Amoth Pass", "Jolie", "Nevison", "Griffin", "7976218622", new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "94113 Talmadge Alley", "Millie", "Litton", "Johny", "2991178608", new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "01 Westridge Terrace", "Valencia", "Killingbeck", "Noah", "1902277359", new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "2 Porter Drive", "Moe", "Esselen", "Rudyard", "3567392817", new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salespersons_Phone",
                table: "Salespersons",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name_Manufacturer",
                table: "Products",
                columns: new[] { "Name", "Manufacturer" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesEntity_CustomerId_ProductId_SalespersonId_SalesDate",
                table: "SalesEntity",
                columns: new[] { "CustomerId", "ProductId", "SalespersonId", "SalesDate" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountEntity_Products_ProductId",
                table: "DiscountEntity",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesEntity_Customers_CustomerId",
                table: "SalesEntity",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesEntity_Products_ProductId",
                table: "SalesEntity",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesEntity_Salespersons_SalespersonId",
                table: "SalesEntity",
                column: "SalespersonId",
                principalTable: "Salespersons",
                principalColumn: "SalespersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountEntity_Products_ProductId",
                table: "DiscountEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesEntity_Customers_CustomerId",
                table: "SalesEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesEntity_Products_ProductId",
                table: "SalesEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesEntity_Salespersons_SalespersonId",
                table: "SalesEntity");

            migrationBuilder.DropIndex(
                name: "IX_Salespersons_Phone",
                table: "Salespersons");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name_Manufacturer",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesEntity",
                table: "SalesEntity");

            migrationBuilder.DropIndex(
                name: "IX_SalesEntity_CustomerId_ProductId_SalespersonId_SalesDate",
                table: "SalesEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscountEntity",
                table: "DiscountEntity");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "SalespersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "SalespersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "SalespersonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "SalespersonId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "SalespersonId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "SalespersonId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "SalespersonId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "SalespersonId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "SalespersonId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "SalespersonId",
                keyValue: 10);

            migrationBuilder.RenameTable(
                name: "SalesEntity",
                newName: "Sales");

            migrationBuilder.RenameTable(
                name: "DiscountEntity",
                newName: "Discounts");

            migrationBuilder.RenameIndex(
                name: "IX_SalesEntity_SalespersonId",
                table: "Sales",
                newName: "IX_Sales_SalespersonId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesEntity_ProductId",
                table: "Sales",
                newName: "IX_Sales_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountEntity_ProductId",
                table: "Discounts",
                newName: "IX_Discounts_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Salespersons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "SalesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Products_ProductId",
                table: "Discounts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Products_ProductId",
                table: "Sales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Salespersons_SalespersonId",
                table: "Sales",
                column: "SalespersonId",
                principalTable: "Salespersons",
                principalColumn: "SalespersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
