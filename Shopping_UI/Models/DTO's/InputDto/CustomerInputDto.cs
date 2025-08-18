using System.ComponentModel.DataAnnotations;

namespace Shopping_UI.Models.DTO_s.InputDto
{
    public class CustomerInputDto
    {
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; } // Email of the customer
        [Required]
        public string PhoneNumber { get; set; } // Contact number of the customer
        public AddressInputDto Address { get; set; }
    }
}
