﻿// <auto-generated />
using System;
using AzureDBApp.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AzureDBApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231009032615_init values")]
    partial class initvalues
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AzureDBApp.Models.CustomerEntity", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "635 Anthes Road",
                            FirstName = "Laurella",
                            LastName = "Sperling",
                            Phone = "9921913996",
                            StartDate = new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "98015 Sommers Drive",
                            FirstName = "Darcey",
                            LastName = "Flageul",
                            Phone = "6904109725",
                            StartDate = new DateTime(2022, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 3,
                            Address = "8037 Elka Way",
                            FirstName = "Harbert",
                            LastName = "Rangall",
                            Phone = "2401862328",
                            StartDate = new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 4,
                            Address = "0957 Sauthoff Hill",
                            FirstName = "Krista",
                            LastName = "Antonomolii",
                            Phone = "2417565632",
                            StartDate = new DateTime(2022, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 5,
                            Address = "32095 Carberry Avenue",
                            FirstName = "Shayne",
                            LastName = "Tawn",
                            Phone = "7643885563",
                            StartDate = new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 6,
                            Address = "63322 Alpine Pass",
                            FirstName = "Caesar",
                            LastName = "Myrkus",
                            Phone = "1581037119",
                            StartDate = new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 7,
                            Address = "82412 Kropf Street",
                            FirstName = "Antonia",
                            LastName = "O'Cassidy",
                            Phone = "6599430956",
                            StartDate = new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 8,
                            Address = "10868 Steensland Center",
                            FirstName = "Carlota",
                            LastName = "MacAnespie",
                            Phone = "4855246191",
                            StartDate = new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 9,
                            Address = "6705 Express Parkway",
                            FirstName = "Schuyler",
                            LastName = "Butt",
                            Phone = "4251880754",
                            StartDate = new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 10,
                            Address = "730 Derek Crossing",
                            FirstName = "Eolande",
                            LastName = "Beadle",
                            Phone = "7055238579",
                            StartDate = new DateTime(2022, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AzureDBApp.Models.DiscountEntity", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountId"));

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("DiscountPercentage")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("DiscountId");

                    b.HasIndex("ProductId");

                    b.ToTable("DiscountEntity");
                });

            modelBuilder.Entity("AzureDBApp.Models.LeadEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LeadDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LeadSource")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Leads");
                });

            modelBuilder.Entity("AzureDBApp.Models.ProductEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<double>("CommissionPercentage")
                        .HasColumnType("float");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("QtyOnHand")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Style")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductId");

                    b.HasIndex("Name", "Manufacturer")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CommissionPercentage = 26.09,
                            Manufacturer = "Ram 1500",
                            Name = "Dodge",
                            PurchasePrice = 2068.27m,
                            QtyOnHand = 15,
                            SalePrice = 7091.88m,
                            Style = "Green"
                        },
                        new
                        {
                            ProductId = 2,
                            CommissionPercentage = 6.5099999999999998,
                            Manufacturer = "Astra",
                            Name = "Saturn",
                            PurchasePrice = 1269.35m,
                            QtyOnHand = 17,
                            SalePrice = 6498.63m,
                            Style = "Green"
                        },
                        new
                        {
                            ProductId = 3,
                            CommissionPercentage = 11.369999999999999,
                            Manufacturer = "9000",
                            Name = "Saab",
                            PurchasePrice = 917.25m,
                            QtyOnHand = 4,
                            SalePrice = 9515.26m,
                            Style = "Goldenrod"
                        },
                        new
                        {
                            ProductId = 4,
                            CommissionPercentage = 27.710000000000001,
                            Manufacturer = "XC90",
                            Name = "Volvo",
                            PurchasePrice = 1783.00m,
                            QtyOnHand = 4,
                            SalePrice = 9831.89m,
                            Style = "Violet"
                        },
                        new
                        {
                            ProductId = 5,
                            CommissionPercentage = 29.329999999999998,
                            Manufacturer = "Venza",
                            Name = "Toyota",
                            PurchasePrice = 3953.84m,
                            QtyOnHand = 11,
                            SalePrice = 8035.80m,
                            Style = "Blue"
                        },
                        new
                        {
                            ProductId = 6,
                            CommissionPercentage = 13.35,
                            Manufacturer = "Century",
                            Name = "Buick",
                            PurchasePrice = 4455.92m,
                            QtyOnHand = 8,
                            SalePrice = 9920.71m,
                            Style = "Yellow"
                        },
                        new
                        {
                            ProductId = 7,
                            CommissionPercentage = 26.739999999999998,
                            Manufacturer = "xB",
                            Name = "Scion",
                            PurchasePrice = 544.53m,
                            QtyOnHand = 7,
                            SalePrice = 9906.81m,
                            Style = "Indigo"
                        },
                        new
                        {
                            ProductId = 8,
                            CommissionPercentage = 15.470000000000001,
                            Manufacturer = "Escalade",
                            Name = "Cadillac",
                            PurchasePrice = 1859.92m,
                            QtyOnHand = 9,
                            SalePrice = 9183.55m,
                            Style = "Yellow"
                        },
                        new
                        {
                            ProductId = 9,
                            CommissionPercentage = 5.3899999999999997,
                            Manufacturer = "Diablo",
                            Name = "Lamborghini",
                            PurchasePrice = 4977.57m,
                            QtyOnHand = 2,
                            SalePrice = 6479.80m,
                            Style = "Maroon"
                        },
                        new
                        {
                            ProductId = 10,
                            CommissionPercentage = 16.75,
                            Manufacturer = "Ram",
                            Name = "Dodge",
                            PurchasePrice = 4131.49m,
                            QtyOnHand = 15,
                            SalePrice = 8337.38m,
                            Style = "Blue"
                        });
                });

            modelBuilder.Entity("AzureDBApp.Models.SalesEntity", b =>
                {
                    b.Property<int>("SalesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SalesDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SalespersonId")
                        .HasColumnType("int");

                    b.HasKey("SalesId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SalespersonId");

                    b.HasIndex("CustomerId", "ProductId", "SalespersonId", "SalesDate")
                        .IsUnique();

                    b.ToTable("SalesEntity");
                });

            modelBuilder.Entity("AzureDBApp.Models.SalespersonEntity", b =>
                {
                    b.Property<int>("SalespersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalespersonId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TerminationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SalespersonId");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Salespersons");

                    b.HasData(
                        new
                        {
                            SalespersonId = 1,
                            Address = "99477 Clarendon Terrace",
                            FirstName = "Melantha",
                            LastName = "Palmer",
                            Manager = "Teddy",
                            Phone = "2559760515",
                            StartDate = new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TerminationDate = new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SalespersonId = 2,
                            Address = "62265 Ludington Way",
                            FirstName = "Prentice",
                            LastName = "Fuggles",
                            Manager = "Werner",
                            Phone = "4952904231",
                            StartDate = new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TerminationDate = new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SalespersonId = 3,
                            Address = "02 Holmberg Court",
                            FirstName = "Udall",
                            LastName = "Iacovides",
                            Manager = "Brandtr",
                            Phone = "1098678048",
                            StartDate = new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TerminationDate = new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SalespersonId = 4,
                            Address = "47 Prentice Center",
                            FirstName = "Yves",
                            LastName = "Grabham",
                            Manager = "Stefan",
                            Phone = "3302522709",
                            StartDate = new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TerminationDate = new DateTime(2023, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SalespersonId = 5,
                            Address = "5 Di Loreto Trail",
                            FirstName = "Robinett",
                            LastName = "Raw",
                            Manager = "Sol",
                            Phone = "8477849692",
                            StartDate = new DateTime(2022, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TerminationDate = new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SalespersonId = 6,
                            Address = "02 Maple Wood Circle",
                            FirstName = "Sargent",
                            LastName = "Vedenyapin",
                            Manager = "Padriac",
                            Phone = "8062170689",
                            StartDate = new DateTime(2022, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TerminationDate = new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SalespersonId = 7,
                            Address = "4 Amoth Pass",
                            FirstName = "Jolie",
                            LastName = "Nevison",
                            Manager = "Griffin",
                            Phone = "7976218622",
                            StartDate = new DateTime(2022, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TerminationDate = new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SalespersonId = 8,
                            Address = "94113 Talmadge Alley",
                            FirstName = "Millie",
                            LastName = "Litton",
                            Manager = "Johny",
                            Phone = "2991178608",
                            StartDate = new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TerminationDate = new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SalespersonId = 9,
                            Address = "01 Westridge Terrace",
                            FirstName = "Valencia",
                            LastName = "Killingbeck",
                            Manager = "Noah",
                            Phone = "1902277359",
                            StartDate = new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TerminationDate = new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SalespersonId = 10,
                            Address = "2 Porter Drive",
                            FirstName = "Moe",
                            LastName = "Esselen",
                            Manager = "Rudyard",
                            Phone = "3567392817",
                            StartDate = new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TerminationDate = new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AzureDBApp.Models.DiscountEntity", b =>
                {
                    b.HasOne("AzureDBApp.Models.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AzureDBApp.Models.SalesEntity", b =>
                {
                    b.HasOne("AzureDBApp.Models.CustomerEntity", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AzureDBApp.Models.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AzureDBApp.Models.SalespersonEntity", "Salesperson")
                        .WithMany()
                        .HasForeignKey("SalespersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Salesperson");
                });
#pragma warning restore 612, 618
        }
    }
}
