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
        }
    }
}
