using Shopping.Shopping_Enum;
using System.ComponentModel.DataAnnotations;

namespace Shopping.Models.DTO_s
{
    public class PaymentDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]

        public PaymentModeEnum PaymentMode { get; set; }
    }
}
