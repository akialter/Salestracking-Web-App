using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDBApp.Models
{
    public class CommissionResult
    {
        public string SalespersonFirstName { get; set; }
        public string SalespersonLastName { get; set; }
        public string YearQuarter { get; set; }

        public decimal TotalCommission { get; set; }
    }
}
