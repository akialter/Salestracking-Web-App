using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureDBApp.Models
{
    public class DiscountEntity
    {
        [Key]
        public int DiscountId { get; set; }

        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        [DisplayName("Begin Date")]
        [DataType(DataType.Date)]
        [DateRange("BeginDate", "EndDate", ErrorMessage = "Begin Date must be earlier than End Date.")]
        public DateTime BeginDate { get; set; }

        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DisplayName("Discount Percentage")]
        [Range(0, 100, ErrorMessage = "Discount Percentage must be between 0 and 100.")]
        public double DiscountPercentage { get; set; }
    }
}



