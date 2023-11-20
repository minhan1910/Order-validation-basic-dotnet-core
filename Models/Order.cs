using Order_Customers_Assignment.CustomValidator;
using System.ComponentModel.DataAnnotations;

namespace Order_Customers_Assignment.Models
{
    public class Order
    {
        public int? OrderNo { get; set; }

        [Display(Name = "Order Date")]
        [Required(ErrorMessage = "{0} can't be blank")]
        [MinimumYearValidator]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Invoice Price")]
        [Required(ErrorMessage = "{0} can't be blank")]
        [RegularExpression(@"^[0-9]+$")]
        public double? InvoicePrice { get; set; }

        [Display(Name = "Products")]
        [Required(ErrorMessage = "{0} can't be blank")]
        [MatchPriceValidator(nameof(InvoicePrice))]
        public List<Product>? Products { get; set; } = new();


    }
}
