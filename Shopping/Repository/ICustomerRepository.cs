using Shopping.Models;
using Shopping.Models.DTO_s;

namespace Shopping.Repository
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAllCustomers();

        Task<Customer> GetCustomerById(int id);

        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(CustomerDto customerDto);

        Task<Customer> DeleteCustomer(int id);
    }
}
