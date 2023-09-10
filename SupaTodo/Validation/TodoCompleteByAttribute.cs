using System.ComponentModel.DataAnnotations;

namespace SupaTodo.Validation
{
    sealed public class TodoCompleteByAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var completeBy = (DateTime?)value;
            if (completeBy == null)
            {
                return ValidationResult.Success;
            }

            if (completeBy < DateTime.Now)
            {
                return new ValidationResult("Date must be in the future");
            }

            return ValidationResult.Success;
        }
    }
}
