using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureDBApp.Models
{
    // This validator ensure that start date is earlier than termination date
    public class DateRangeAttribute : ValidationAttribute
    {
        private readonly string _startDateProperty;
        private readonly string _endDateProperty;

        public DateRangeAttribute(string startDateProperty, string endDateProperty)
        {
            _startDateProperty = startDateProperty;
            _endDateProperty = endDateProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startDateInfo = validationContext.ObjectType.GetProperty(_startDateProperty);
            var endDateInfo = validationContext.ObjectType.GetProperty(_endDateProperty);

            if (startDateInfo == null || endDateInfo == null)
            {
                return new ValidationResult($"Property {_startDateProperty} or {_endDateProperty} not found.");
            }

            var startDateValue = (DateTime?)startDateInfo.GetValue(validationContext.ObjectInstance, null);
            var endDateValue = (DateTime?)endDateInfo.GetValue(validationContext.ObjectInstance, null);

            if (startDateValue.HasValue && endDateValue.HasValue && startDateValue.Value > endDateValue.Value)
            {
                return new ValidationResult(ErrorMessage ?? $"{_startDateProperty} must be earlier than {_endDateProperty}.");
            }

            return ValidationResult.Success;
        }
    }

    public class SalespersonEntity
    {
        [Key]
        public int SalespersonId { get; set; }

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
        [DateRange("StartDate", "TerminationDate", ErrorMessage = "Start Date must be earlier than Termination Date.")]
        public DateTime StartDate { get; set; }

        [DisplayName("Termination Date")]
        [DataType(DataType.Date)]
        public DateTime? TerminationDate { get; set; }

        [DisplayName("Manager")]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Manager must contain only letters.")]
        public string Manager { get; set; }
    }

}
