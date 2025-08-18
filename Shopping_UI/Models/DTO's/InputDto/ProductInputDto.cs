using System.ComponentModel.DataAnnotations;

namespace Shopping_UI.Models.DTO_s.InputDto
{
    public class ProductInputDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
