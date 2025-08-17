using System.ComponentModel.DataAnnotations;

namespace Shopping.Models.DTO_s
{
    public class CustomerDto
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; } // Email of the customer
        [Required]
        public string PhoneNumber { get; set; } // Contact number of the customer
        public AddressDto Address { get; set; }
    }
}
