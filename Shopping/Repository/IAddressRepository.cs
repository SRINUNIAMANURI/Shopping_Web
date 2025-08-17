using Shopping.Models;
using Shopping.Models.DTO_s;

namespace Shopping.Repository
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAllAddresses();
        Task<Address> GetAddressById(int id);
        Task<Address> GetAddresByCustomerId(int id);

        Task AddAddress(Address address);

        Task<Address> UpdateAddress(AddressInputDto addressDto);
    }
}
