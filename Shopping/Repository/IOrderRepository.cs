using Shopping.Models;
using Shopping.Models.DTO_s;
using Shopping.Models.InputDto_s;

namespace Shopping.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int id);
        Task<Order> AddOrder(OrderCreateDto orderInputDto);
        Task<Order> UpdateOrder(OrderUpdateDto orderDto);
        Task<Order> DeleteOrder(int id);
    }
}
