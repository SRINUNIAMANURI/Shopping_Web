using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Models;
using Shopping.Models.DTO_s;
using Shopping.Repository;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(IMapper mapper, ICustomerRepository customerRepository)
        {
            this._mapper = mapper;
            this._customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerRepository.GetAllCustomers();
            var customersDto = _mapper.Map<List<CustomerDto>>(customers);
            return Ok(customersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);

            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerInputDto customerDto)
        {
            try
            {
                await _customerRepository.AddCustomer(_mapper.Map<Customer>(customerDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Customer Added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerDto customerDto)
        {
            try
            {
                var custmoer = await _customerRepository.UpdateCustomer(customerDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok($"Custer Updated {customerDto.Id}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            Customer customer;
            try
            {
                customer = await _customerRepository.DeleteCustomer(id);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex);
            }

            return Ok(_mapper.Map<CustomerDto>(customer));
        }
    }
}
