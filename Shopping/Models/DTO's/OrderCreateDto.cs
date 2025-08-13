using System.ComponentModel.DataAnnotations;

namespace Shopping.Models.DTO_s
{
    public class OrderCreateDto
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public List<OrderItemCreateDto> Items { get; set; }
        // The amount can be calculated on the server side based on the product prices and quantities.
        // However, if you prefer to include it, you can add it here.
    }
}
