using Shopping.Models;
using Shopping.Models.DTO_s;
using Shopping.Models.InputDto_s;

namespace Shopping.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> AddProduct(ProductInputDto productInputDto);
        Task<Product> UpdateProduct(ProductDto productDto);
        Task<Product> DeleteProduct(int id);
    }
}
