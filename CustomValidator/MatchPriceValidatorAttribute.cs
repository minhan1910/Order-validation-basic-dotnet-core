using Order_Customers_Assignment.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Order_Customers_Assignment.CustomValidator
{
    public class MatchPriceValidatorAttribute : ValidationAttribute
    {
        public string OtherPriceName { get; set; }
        public string ERR_PRODUCT_NULL_OR_EMPTY { get; } = "Product shouldn't be null or empty";
        public string ERR_FIELD_PRICE_NULL_OR_EMPTY { get; } = "Product Field Price shouldn't be null or empty";
        public string ERR_TOTAL_PRICE_NOT_MATCH_OTHER_PRICE { get; } = "{0} is not match with Total Price";

        public MatchPriceValidatorAttribute(string otherPriceName) 
        {
            OtherPriceName = otherPriceName;    
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            PropertyInfo? otherPriceProp = validationContext.ObjectType.GetProperty(OtherPriceName);

            if (otherPriceProp is null || OtherPriceName is null)
            {
                return new ValidationResult(ERR_FIELD_PRICE_NULL_OR_EMPTY);
            }

            double otherPrice = Convert.ToDouble(otherPriceProp.GetValue(validationContext.ObjectInstance));

            List<Product>? products = value as List<Product>;

            if (products is null || products.Count <= 0) 
            {
                return new ValidationResult(ERR_PRODUCT_NULL_OR_EMPTY);
            }

            double totalAllProductsPrice = products.Sum(product => product.GetTotalPrice());

            return otherPrice != totalAllProductsPrice 
                ? new ValidationResult(ErrorMessage ?? string.Format(ERR_TOTAL_PRICE_NOT_MATCH_OTHER_PRICE, OtherPriceName)) 
                : ValidationResult.Success;
        }
    }
}
