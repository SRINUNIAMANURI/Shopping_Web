using Shopping.Shopping_Enum;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Models.InputDto_s
{
    public class PaymentInputDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]

        public PaymentModeEnum PaymentMode { get; set; }
    }
}
