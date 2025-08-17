using Microsoft.EntityFrameworkCore;
using Shopping.DATA;
using Shopping.Models;
using Shopping.Models.DTO_s;

namespace Shopping.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ShoppingDbContext dbContext;

        public AddressRepository(ShoppingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAddress(Address address)
        {
            await dbContext.Address.AddAsync(address);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Address> GetAddresByCustomerId(int id)
        {
            return await dbContext.Address.FirstOrDefaultAsync(ad => ad.CustomerId == id);
        }

        public async Task<Address> GetAddressById(int id)
        {
            return await dbContext.Address.FirstOrDefaultAsync(ad => ad.Id == id);
        }

        public async Task<List<Address>> GetAllAddresses()
        {
            return await dbContext.Address.ToListAsync();
        }

        public Task<Address> UpdateAddress(AddressInputDto addressDto)
        {
            throw new NotImplementedException();
        }
    }
}
