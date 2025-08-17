using System.ComponentModel.DataAnnotations;

namespace Shopping.Models.DTO_s
{
    public class AddressInputDto
    {
        [Required, MaxLength(200)]
        public string Street { get; set; }
        [Required, MaxLength(100)]
        public string City { get; set; }
        [Required, MaxLength(10)]
        public string ZipCode { get; set; }
    }
}
