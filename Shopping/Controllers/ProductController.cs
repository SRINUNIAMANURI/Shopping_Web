using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Models;
using Shopping.Models.DTO_s;
using Shopping.Models.InputDto_s;
using Shopping.Repository;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductController(IMapper mapper, IProductRepository productRepository)
        {
            this._mapper = mapper;
            this._productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAll();

            return products?.Count > 0 ? Ok(_mapper.Map<List<ProductDto>>(products)) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Product product;
            try
            {
                product = await _productRepository.GetById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return product?.Id > 0 ? Ok(_mapper.Map<ProductDto>(product)) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductInputDto productInputDto)
        {
            Product product;
            try
            {
                product = await _productRepository.AddProduct(productInputDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           
            return Ok(_mapper.Map<ProductDto>(product));
           
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
        {
            Product product;
            try
            {
                product = await _productRepository.UpdateProduct(productDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return product?.Id > 0 ? Ok(_mapper.Map<ProductDto>(product)) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            Product product;
            try
            {
               product = await _productRepository.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return product?.Id  > 0 ? Ok(_mapper.Map<ProductDto>(product)) : NotFound();
        }
    }
}
