using AzureDBApp.DB;
using AzureDBApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AzureDBApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string selectedQuarter)
        {
            // Calculate the commissions
            var commissions = CalculateCommissions();

            if (string.IsNullOrEmpty(selectedQuarter) && commissions.Any())
            {
                // If selectedQuarter is not specified and there are commissions, set it to the latest quarter
                selectedQuarter = commissions.Select(result => result.YearQuarter).OrderByDescending(q => q).First();
            }

            ViewBag.SelectedQuarter = selectedQuarter;
            return View(commissions);
        }



        private List<CommissionResult> CalculateCommissions()
        {
            var sql = @"
                WITH CTE AS (
                    SELECT
                        sp.FirstName AS SalespersonFirstName,
                        sp.LastName AS SalespersonLastName,
                        CAST(YEAR(s.SalesDate) AS VARCHAR(4)) + ' Q' + CAST(DATEPART(QUARTER, s.SalesDate) AS VARCHAR(1)) AS YearQuarter,
                        SUM(CAST(p.SalePrice AS DECIMAL(18, 2)) * COALESCE(CAST(d.DiscountPercentage AS DECIMAL(18, 2)) / 100, 1.0) * (CAST(p.CommissionPercentage AS DECIMAL(18, 2)) / 100)) AS TotalCommission
                    FROM Salespersons sp
                    JOIN SalesEntity s ON sp.SalespersonId = s.SalespersonId
                    JOIN Products p ON s.ProductId = p.ProductId
                    LEFT JOIN DiscountEntity d ON p.ProductId = d.ProductId
                    WHERE
                        s.SalesDate BETWEEN (SELECT MIN(SalesDate) FROM SalesEntity) AND (SELECT MAX(SalesDate) FROM SalesEntity)
                    GROUP BY
                        sp.FirstName,
                        sp.LastName,
                        CAST(YEAR(s.SalesDate) AS VARCHAR(4)) + ' Q' + CAST(DATEPART(QUARTER, s.SalesDate) AS VARCHAR(1))
                )

                SELECT *
                FROM CTE
                ORDER BY CAST(LEFT(YearQuarter, 4) AS INT), CAST(SUBSTRING(YearQuarter, 7, 1) AS INT)
                ";

            var commissions = _context.CommissionResults.FromSqlRaw(sql).ToList();

            return commissions;
        }

        private List<string> GetAllQuarters()
        {
            var sql = @"
        SELECT DISTINCT
            CAST(YEAR(s.SalesDate) AS VARCHAR(4)) + ' Q' + CAST(DATEPART(QUARTER, s.SalesDate) AS VARCHAR(1)) AS YearQuarter
        FROM SalesEntity s";

            var quarters = _context.CommissionResults.FromSqlRaw(sql)
                .Select(result => result.YearQuarter)
                .Distinct()
                .ToList();

            return quarters;
        }

        public static List<string> GetQuarters(DateTime startDate, DateTime endDate)
        {
            List<string> quarters = new List<string>();

            while (startDate <= endDate)
            {
                int year = startDate.Year;
                int quarter = (startDate.Month - 1) / 3 + 1;
                string quarterName = string.Format("Q{0} {1}", quarter, year);

                quarters.Add(quarterName);

                startDate = startDate.AddMonths(3);
            }

            return quarters;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}