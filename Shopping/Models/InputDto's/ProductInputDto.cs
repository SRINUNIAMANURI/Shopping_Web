using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models.InputDto_s
{
    public class ProductInputDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
