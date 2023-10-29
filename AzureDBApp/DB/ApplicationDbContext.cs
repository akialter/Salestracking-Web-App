using AzureDBApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AzureDBApp.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    
        public DbSet<LeadEntity> Leads { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<SalespersonEntity> Salespersons { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<SalesEntity> Sales { get; set; }
        public DbSet<DiscountEntity> Discounts { get; set; }
        public DbSet<CommissionResult> CommissionResults { get; set; }




        // Enforce constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Name and Manufacturer are unique to a Product
            modelBuilder.Entity<ProductEntity>()
                .HasIndex(p => new { p.Name, p.Manufacturer }).IsUnique();

            // Phone number should be unique for a given Salesperson
            modelBuilder.Entity<SalespersonEntity>()
                .HasIndex(e => e.Phone).IsUnique();

            // There can't be duplicate sales
            modelBuilder.Entity<SalesEntity>()
                .HasIndex(se => new { se.CustomerId, se.ProductId, se.SalespersonId, se.SalesDate })
                .IsUnique();

            // Check for duplicate discount
            modelBuilder.Entity<DiscountEntity>()
                .HasIndex(d => new { d.ProductId, d.BeginDate, d.EndDate })
                .IsUnique();

            // Configure the CommissionResult entity as read-only (has no key)
            modelBuilder.Entity<CommissionResult>().HasNoKey();

            // Create seed data
            SeedData(modelBuilder);
        }


        // Seed with sample data for testing
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity
                {
                    ProductId = 1,
                    Name = "Dodge",
                    Manufacturer = "Ram 1500",
                    Style = "Green",
                    PurchasePrice = 2068.27m,
                    SalePrice = 7091.88m,
                    QtyOnHand = 15,
                    CommissionPercentage = 26.09
                },
                new ProductEntity
                {
                    ProductId = 2,
                    Name = "Saturn",
                    Manufacturer = "Astra",
                    Style = "Green",
                    PurchasePrice = 1269.35m,
                    SalePrice = 6498.63m,
                    QtyOnHand = 17,
                    CommissionPercentage = 6.51
                },
                new ProductEntity
                {
                    ProductId = 3,
                    Name = "Saab",
                    Manufacturer = "9000",
                    Style = "Goldenrod",
                    PurchasePrice = 917.25m,
                    SalePrice = 9515.26m,
                    QtyOnHand = 4,
                    CommissionPercentage = 11.37
                },
                new ProductEntity
                {
                    ProductId = 4,
                    Name = "Volvo",
                    Manufacturer = "XC90",
                    Style = "Violet",
                    PurchasePrice = 1783.00m,
                    SalePrice = 9831.89m,
                    QtyOnHand = 4,
                    CommissionPercentage = 27.71
                },
                new ProductEntity
                {
                    ProductId = 5,
                    Name = "Toyota",
                    Manufacturer = "Venza",
                    Style = "Blue",
                    PurchasePrice = 3953.84m,
                    SalePrice = 8035.80m,
                    QtyOnHand = 11,
                    CommissionPercentage = 29.33
                },
                new ProductEntity
                {
                    ProductId = 6,
                    Name = "Buick",
                    Manufacturer = "Century",
                    Style = "Yellow",
                    PurchasePrice = 4455.92m,
                    SalePrice = 9920.71m,
                    QtyOnHand = 8,
                    CommissionPercentage = 13.35
                },
                new ProductEntity
                {
                    ProductId = 7,
                    Name = "Scion",
                    Manufacturer = "xB",
                    Style = "Indigo",
                    PurchasePrice = 544.53m,
                    SalePrice = 9906.81m,
                    QtyOnHand = 7,
                    CommissionPercentage = 26.74
                },
                new ProductEntity
                {
                    ProductId = 8,
                    Name = "Cadillac",
                    Manufacturer = "Escalade",
                    Style = "Yellow",
                    PurchasePrice = 1859.92m,
                    SalePrice = 9183.55m,
                    QtyOnHand = 9,
                    CommissionPercentage = 15.47
                },
                new ProductEntity
                {
                    ProductId = 9,
                    Name = "Lamborghini",
                    Manufacturer = "Diablo",
                    Style = "Maroon",
                    PurchasePrice = 4977.57m,
                    SalePrice = 6479.80m,
                    QtyOnHand = 2,
                    CommissionPercentage = 5.39
                },
                new ProductEntity
                {
                    ProductId = 10,
                    Name = "Dodge",
                    Manufacturer = "Ram",
                    Style = "Blue",
                    PurchasePrice = 4131.49m,
                    SalePrice = 8337.38m,
                    QtyOnHand = 15,
                    CommissionPercentage = 16.75
                }
            );

            modelBuilder.Entity<CustomerEntity>().HasData(
                new CustomerEntity
                {
                    CustomerId = 1,
                    FirstName = "Laurella",
                    LastName = "Sperling",
                    Address = "635 Anthes Road",
                    Phone = "9921913996",
                    StartDate = DateTime.ParseExact("10/28/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture)
                },
                new CustomerEntity
                {
                    CustomerId = 2,
                    FirstName = "Darcey",
                    LastName = "Flageul",
                    Address = "98015 Sommers Drive",
                    Phone = "6904109725",
                    StartDate = DateTime.ParseExact("10/28/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture)
                },
                new CustomerEntity
                {
                    CustomerId = 3,
                    FirstName = "Harbert",
                    LastName = "Rangall",
                    Address = "8037 Elka Way",
                    Phone = "2401862328",
                    StartDate = DateTime.ParseExact("11/29/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture)
                },
                new CustomerEntity
                {
                    CustomerId = 4,
                    FirstName = "Krista",
                    LastName = "Antonomolii",
                    Address = "0957 Sauthoff Hill",
                    Phone = "2417565632",
                    StartDate = DateTime.ParseExact("11/02/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture)
                },
                new CustomerEntity
                {
                    CustomerId = 5,
                    FirstName = "Shayne",
                    LastName = "Tawn",
                    Address = "32095 Carberry Avenue",
                    Phone = "7643885563",
                    StartDate = DateTime.ParseExact("10/12/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture)
                },
                new CustomerEntity
                {
                    CustomerId = 6,
                    FirstName = "Caesar",
                    LastName = "Myrkus",
                    Address = "63322 Alpine Pass",
                    Phone = "1581037119",
                    StartDate = DateTime.ParseExact("11/23/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture)
                },
                new CustomerEntity
                {
                    CustomerId = 7,
                    FirstName = "Antonia",
                    LastName = "O'Cassidy",
                    Address = "82412 Kropf Street",
                    Phone = "6599430956",
                    StartDate = DateTime.ParseExact("11/08/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture)
                },
                new CustomerEntity
                {
                    CustomerId = 8,
                    FirstName = "Carlota",
                    LastName = "MacAnespie",
                    Address = "10868 Steensland Center",
                    Phone = "4855246191",
                    StartDate = DateTime.ParseExact("10/15/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture)
                },
                new CustomerEntity
                {
                    CustomerId = 9,
                    FirstName = "Schuyler",
                    LastName = "Butt",
                    Address = "6705 Express Parkway",
                    Phone = "4251880754",
                    StartDate = DateTime.ParseExact("11/11/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture)
                },
                new CustomerEntity
                {
                    CustomerId = 10,
                    FirstName = "Eolande",
                    LastName = "Beadle",
                    Address = "730 Derek Crossing",
                    Phone = "7055238579",
                    StartDate = DateTime.ParseExact("11/16/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture)
                });

            modelBuilder.Entity<SalespersonEntity>().HasData(
                new SalespersonEntity
                {
                    SalespersonId = 1,
                    FirstName = "Melantha",
                    LastName = "Palmer",
                    Address = "99477 Clarendon Terrace",
                    Phone = "2559760515",
                    StartDate = DateTime.ParseExact("10/13/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    TerminationDate = DateTime.ParseExact("2/13/2024", "M/d/yyyy", CultureInfo.InvariantCulture),
                    Manager = "Teddy"
                },
                new SalespersonEntity
                {
                    SalespersonId = 2,
                    FirstName = "Prentice",
                    LastName = "Fuggles",
                    Address = "62265 Ludington Way",
                    Phone = "4952904231",
                    StartDate = DateTime.ParseExact("10/27/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    TerminationDate = DateTime.ParseExact("3/6/2024", "M/d/yyyy", CultureInfo.InvariantCulture),
                    Manager = "Werner"
                },
                new SalespersonEntity
                {
                    SalespersonId = 3,
                    FirstName = "Udall",
                    LastName = "Iacovides",
                    Address = "02 Holmberg Court",
                    Phone = "1098678048",
                    StartDate = DateTime.ParseExact("10/09/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    TerminationDate = DateTime.ParseExact("2/11/2024", "M/d/yyyy", CultureInfo.InvariantCulture),
                    Manager = "Brandtr"
                },
                new SalespersonEntity
                {
                    SalespersonId = 4,
                    FirstName = "Yves",
                    LastName = "Grabham",
                    Address = "47 Prentice Center",
                    Phone = "3302522709",
                    StartDate = DateTime.ParseExact("10/10/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    TerminationDate = DateTime.ParseExact("12/16/2023", "M/d/yyyy", CultureInfo.InvariantCulture),
                    Manager = "Stefan"
                },
                new SalespersonEntity
                {
                    SalespersonId = 5,
                    FirstName = "Robinett",
                    LastName = "Raw",
                    Address = "5 Di Loreto Trail",
                    Phone = "8477849692",
                    StartDate = DateTime.ParseExact("11/19/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    TerminationDate = DateTime.ParseExact("1/15/2024", "M/d/yyyy", CultureInfo.InvariantCulture),
                    Manager = "Sol"
                },
                new SalespersonEntity
                {
                    SalespersonId = 6,
                    FirstName = "Sargent",
                    LastName = "Vedenyapin",
                    Address = "02 Maple Wood Circle",
                    Phone = "8062170689",
                    StartDate = DateTime.ParseExact("10/19/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    TerminationDate = DateTime.ParseExact("3/1/2024", "M/d/yyyy", CultureInfo.InvariantCulture),
                    Manager = "Padriac"
                },
                new SalespersonEntity
                {
                    SalespersonId = 7,
                    FirstName = "Jolie",
                    LastName = "Nevison",
                    Address = "4 Amoth Pass",
                    Phone = "7976218622",
                    StartDate = DateTime.ParseExact("10/27/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    TerminationDate = DateTime.ParseExact("5/5/2024", "M/d/yyyy", CultureInfo.InvariantCulture),
                    Manager = "Griffin"
                },
                new SalespersonEntity
                {
                    SalespersonId = 8,
                    FirstName = "Millie",
                    LastName = "Litton",
                    Address = "94113 Talmadge Alley",
                    Phone = "2991178608",
                    StartDate = DateTime.ParseExact("10/18/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    TerminationDate = DateTime.ParseExact("12/29/2023", "M/d/yyyy", CultureInfo.InvariantCulture),
                    Manager = "Johny"
                },
                new SalespersonEntity
                {
                    SalespersonId = 9,
                    FirstName = "Valencia",
                    LastName = "Killingbeck",
                    Address = "01 Westridge Terrace",
                    Phone = "1902277359",
                    StartDate = DateTime.ParseExact("11/18/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    TerminationDate = DateTime.ParseExact("4/3/2024", "M/d/yyyy", CultureInfo.InvariantCulture),
                    Manager = "Noah"
                },
                new SalespersonEntity
                {
                    SalespersonId = 10,
                    FirstName = "Moe",
                    LastName = "Esselen",
                    Address = "2 Porter Drive",
                    Phone = "3567392817",
                    StartDate = DateTime.ParseExact("11/29/2022", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                    TerminationDate = DateTime.ParseExact("5/5/2024", "M/d/yyyy", CultureInfo.InvariantCulture),
                    Manager = "Rudyard"
                });
        }


        // Seed with sample data for testing
        public DbSet<AzureDBApp.Models.SalesEntity> SalesEntity { get; set; } = default!;


        // Seed with sample data for testing
        public DbSet<AzureDBApp.Models.DiscountEntity> DiscountEntity { get; set; } = default!;
    }
}
