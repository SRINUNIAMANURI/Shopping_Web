using System.ComponentModel.DataAnnotations;

namespace Shopping.Models.DTO_s
{
    public class OrderItemCreateDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
