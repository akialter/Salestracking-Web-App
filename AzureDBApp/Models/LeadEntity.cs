using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace AzureDBApp.Models
{
    public class LeadEntity
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTime LeadDate { get; set; }
        [DisplayName("Lead Source")]
        public string LeadSource { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }
        public string Email { get; set; }   

    }
}
