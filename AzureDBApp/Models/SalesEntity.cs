using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace AzureDBApp.Models
{
    public class SalesEntity
    {
        [Key]
        public int SalesId { get; set; }

        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public int SalespersonId { get; set; }
        public SalespersonEntity Salesperson { get; set; }

        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }

        public DateTime SalesDate { get; set; }

    }
}
