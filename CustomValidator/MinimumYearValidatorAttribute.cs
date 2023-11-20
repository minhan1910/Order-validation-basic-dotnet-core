using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Order_Customers_Assignment.CustomValidator
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefaultErrorMessage { get; set; } = "Minimum year allowed is {0}";

        public MinimumYearValidatorAttribute() { }

        public MinimumYearValidatorAttribute(int minimumYear) 
        {
            MinimumYear = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return null;
            }
        
            DateTime date = Convert.ToDateTime(value);

            if (date.Year >= MinimumYear) 
            {
                return ValidationResult.Success;
            }            

            string errMsg = ErrorMessage ?? DefaultErrorMessage;

            return new ValidationResult(string.Format(errMsg, MinimumYear));            
        }
    }
}
