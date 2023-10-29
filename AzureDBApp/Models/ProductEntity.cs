using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace AzureDBApp.Models
{
    public class ProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ProductId { get; set; }

        [Required]
        [DisplayName("Product Name")]
        [MaxLength(50)] 
        public string Name { get; set; }

        [DisplayName("Manufacturer")]
        [MaxLength(50)]
        public string Manufacturer { get; set; }

        [DisplayName("Style")]
        [MaxLength(50)] 
        public string Style { get; set; }

        [DisplayName("Purchase Price")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Purchase Price must be a non-negative value.")]
        public decimal PurchasePrice { get; set; }

        [DisplayName("Sale Price")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Sale Price must be a non-negative value.")]
        public decimal SalePrice { get; set; }

        [DisplayName("Quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
        public int QtyOnHand { get; set; }

        [DisplayName("Commission Percentage")]
        [Range(0, 100)]
        public double CommissionPercentage { get; set; }

        [NotMapped]
        public IFormFile? File { get; set; }
    }
}
