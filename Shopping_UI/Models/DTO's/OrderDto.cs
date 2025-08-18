using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_UI.Models
{
    public class OrderDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }  // Total amount of the order
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public CustomerDto Customer { get; set; } // Navigation Property
       // public ICollection<OrderItem> OrderItems { get; set; }
    }
}
