using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_UI.Models
{
    public class AddressDto
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Street { get; set; }
        [Required, MaxLength(100)]
        public string City { get; set; }
        [Required, MaxLength(10)]
        public string ZipCode { get; set; }
        public int CustomerId { get; set; }

        //[ForeignKey("CustomerId")]
        //public CustomerDto Customer { get; set; } // Navigation property for the Customer
    }
}
