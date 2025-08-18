using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.DATA;
using Shopping.Models;
using Shopping.Models.DTO_s;
using Shopping.Models.InputDto_s;

namespace Shopping.Repository
{
    public class OrderRepository :IOrderRepository
    {
        private readonly ShoppingDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(ShoppingDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<List<Order>>GetAll()
        {
            var ordres = await _dbContext.Orders.Include(c => c.Customer).ThenInclude(c => c.Address).Include(c =>c.OrderItems).ThenInclude(c => c.Product).ToListAsync();

            return ordres;
        }

        public async Task<Order>GetById(int id)
        {
            var order = await _dbContext.Orders.Include(c => c.Customer).ThenInclude(c => c.Address).Include(c => c.OrderItems).ThenInclude(c => c.Product).FirstOrDefaultAsync(o => o.Id == id) ?? new Order();

            return order;
        }

        public async Task<Order> AddOrder(OrderCreateDto orderInputDto)
        {
            
            var orderModel = new Order();


            orderModel.OrderDate = DateTime.Now;

            orderModel.CustomerId = orderInputDto.CustomerId;
            
            decimal price = 0;

            ICollection<OrderItem>orderItemList = [];


            foreach (var itm in orderInputDto.Items)
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == itm.ProductId);
                OrderItem orderItem = new OrderItem();

                orderItem.ProductId = itm.ProductId;
                orderItem.ProductPrice = product.Price;
                orderItem.Order = orderModel;
                orderItem.Product = product;
                orderItem.Quantity = itm.Quantity;

                orderItemList.Add(orderItem);
                
                price += (itm.Quantity * product.Price);
            }

            orderModel.Amount = price;
            orderModel.OrderItems = orderItemList;

            await _dbContext.Orders.AddAsync(orderModel);

            await _dbContext.SaveChangesAsync();

            return orderModel;
        }

        public async Task<Order>UpdateOrder(OrderUpdateDto orderDto)
        {
            var orderModel = new Order();


            orderModel.OrderDate = orderDto.OrderDate;

            orderModel.CustomerId = orderDto.CustomerId;

            decimal price = 0;

            ICollection<OrderItem> orderItemList = [];


            foreach (var itm in orderDto.OrderItems)
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == itm.ProductId);
                OrderItem orderItem = new OrderItem();

                orderItem.ProductId = itm.ProductId;
                orderItem.ProductPrice = product.Price;
                orderItem.Order = orderModel;
                orderItem.Product = product;
                orderItem.Quantity = itm.Quantity;

                orderItemList.Add(orderItem);

                price += (itm.Quantity * product.Price);
            }

            orderModel.Amount = price;
            orderModel.OrderItems = orderItemList;

            await _dbContext.Orders.AddAsync(orderModel);

            await _dbContext.SaveChangesAsync();

            return orderModel;
        }

        public async Task<Order> DeleteOrder(int id)
        {
            var orderModel = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if(orderModel != null)
            {
                _dbContext.Orders.Remove(orderModel);
            }

           await _dbContext.SaveChangesAsync();

            return orderModel ?? new Order();
        }
    }
}
