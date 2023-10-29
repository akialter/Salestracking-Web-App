using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDBApp.Models
{
    public class CustomerEntity
    {
        [Key]
        public int CustomerId { get; set; }

        [DisplayName("First Name")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "First Name must contain only letters.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Last Name must contain only letters.")]
        public string LastName { get; set; }

        [DisplayName("Address")]
        [MaxLength(100)]
        public string Address { get; set; }

        [DisplayName("Phone")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number format (must be 10 digits).")]
        public string Phone { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }

}
