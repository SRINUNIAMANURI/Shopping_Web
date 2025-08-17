using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.DATA;
using Shopping.Models;
using Shopping.Models.DTO_s;
using Shopping.Models.InputDto_s;

namespace Shopping.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingDbContext dbContext;
        private readonly IMapper mapper;

        public ProductRepository(ShoppingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<Product>>GetAll()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product>GetById(int id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id) ?? new Product();
        }

        public async Task<Product>AddProduct(ProductInputDto productInputDto)
        {
            var productModel = mapper.Map<Product>(productInputDto);

            await dbContext.Products.AddAsync(productModel);
            await dbContext.SaveChangesAsync();

            return productModel;
        }

        public async Task<Product>UpdateProduct(ProductDto productDto)
        {
            var productModel = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == productDto.Id);

            if(productModel != null)
            {
                mapper.Map(productDto,productModel);
            }

            await dbContext.SaveChangesAsync();

            return productModel ?? new Product();
        }

        public async Task<Product>DeleteProduct(int id)
        {
            var productModel = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if( productModel != null)
            {
                dbContext.Products.Remove(productModel);
            }

            await dbContext.SaveChangesAsync();

            return productModel ?? new Product();
        }
    }
}
