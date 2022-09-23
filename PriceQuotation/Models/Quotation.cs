using System.ComponentModel.DataAnnotations;

namespace PriceQuotation.Models
{
    public class Quotation
    {
        [Required(ErrorMessage =
           "Please enter a subtotal.")]
        [Range(1, double.MaxValue, ErrorMessage =
            "Subtotal must be greater than 0.")]
        public decimal? Subtotal { get; set; }
        [Required(ErrorMessage =
            "Please enter a discount percent.")]
        [Range(0, 100, ErrorMessage =
            "Discount percent must be between 0 and 100.")]
        public decimal? DiscountPercent { get; set; }

        public decimal? CalculateDiscountAmount()
        {
            decimal? percent = DiscountPercent / 100;
            decimal? discountamount = percent * Subtotal;
            return discountamount;
        }

        public decimal? CalculateTotal()
        {
            decimal? total = Subtotal - CalculateDiscountAmount();
            return total;
        }
    }
}
