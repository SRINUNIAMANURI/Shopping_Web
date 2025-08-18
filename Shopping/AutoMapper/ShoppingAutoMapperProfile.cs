using AutoMapper;
using Shopping.Models;
using Shopping.Models.DTO_s;
using Shopping.Models.InputDto_s;

namespace Shopping.AutoMapper
{
    public class ShoppingAutoMapperProfile : Profile
    {
        public ShoppingAutoMapperProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<Address, AddressInputDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerInputDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product,ProductInputDto>().ReverseMap();

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FirstName + src.Customer.LastName))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate.ToString()))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Customer.Email))
                .ForMember(dest => dest.CustomerPhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Customer.Address))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));



            CreateMap<OrderItem, OrderItemDto>().ReverseMap();

            //  CreateMap<Order, OrderCreateDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>()
                  // Map the Product.Name property to OrderItemDTO.ProductName
                  .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                  // Map the Product.Price property to OrderItemDTO.ProductPrice
                  .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
                  // Calculate and map the total price (Product.Price * Quantity) to OrderItemDTO.TotalPrice
                  .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Product.Price * src.Quantity));

            CreateMap<OrderCreateDto, Order>()
               // Set the OrderDate to the current date and time (DateTime.Now) when creating an order
               .ForMember(dest => dest.OrderDate, opt => opt.Ignore())
               // Ignore the Amount property during the mapping, as it will be calculated later
               .ForMember(dest => dest.Amount, opt => opt.Ignore())
               // Map the list of OrderItemCreateDTO to the OrderItems property in the Order entity
               .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.Items)).ReverseMap();

            CreateMap<OrderItem, OrderCreateDto>().ReverseMap();

            CreateMap<Order, OrderUpdateDto>().ReverseMap();

            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Payment, PaymentInputDto>().ReverseMap();
        }
    }
}
