using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.DATA;
using Shopping.Models;
using Shopping.Models.DTO_s;

namespace Shopping.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShoppingDbContext _dbContext;
        private readonly IMapper mapper;

        public CustomerRepository(ShoppingDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
            }

            await _dbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customer = await _dbContext.Customers.Include(a => a.Address).ToListAsync();

            return customer;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _dbContext.Customers.Include(a => a.Address).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Customer> UpdateCustomer(CustomerDto customerDto)
        {
            var customerModel = await _dbContext.Customers.FirstOrDefaultAsync(a => a.Id == customerDto.Id);

            if (customerModel != null) 
            {
                mapper.Map(customerDto, customerModel);
            }

            await _dbContext.SaveChangesAsync();

            return customerModel;
        }
    }
}
