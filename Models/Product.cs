using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Order_Customers_Assignment.Models
{
    public class Product
    {
        [Display(Name = "Product Code")]
        [Required(ErrorMessage = "{0} can't be blank")]
        [RegularExpression(@"^[0-9]+$")]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [RegularExpression(@"^[0-9]+$")]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [RegularExpression(@"^[0-9]+$")]
        public int Quantity { get; set; }

        public double GetTotalPrice()
        {
            return Price * Quantity;
        }
    }
}
