using AutoMapper;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.AutoMapper;
using Shopping.DATA;
using Shopping.Models;
using Shopping.Models.DTO_s;
using Shopping.Repository;

namespace Shopping.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            this._addressRepository = addressRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            var addresses = await _addressRepository.GetAllAddresses();

            if (addresses is not null)
            {
                return Ok(_mapper.Map<List<AddressDto>>(addresses));
            }

            return NotFound("No Addresses are there please add your Address");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var address = await _addressRepository.GetAddressById(id);

            if (address is not null) { return Ok(_mapper.Map<AddressDto>(address)); }

            return NotFound("No Addresses are there please add your Address");
        }

        //[HttpGet("{customer_Id}")]
        //[Route("Address/GetAddressByCustomerId")]
        //public async Task<IActionResult> GetAddressByCustomerId(int customer_Id)
        //{
        //    var address = await _addressRepository.GetAddresByCustomerId(customer_Id);

        //    if (address is not null) { return Ok(_mapper.Map<AddressDto>(address)); }

        //    return NotFound("No Addresses are there please add your Address");
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddAddress([FromBody] AddressInputDto addressDto)
        //{
        //    await _addressRepository.AddAddress(_mapper.Map<Address>(addressDto));

        //    return Ok();
        //}
    }
}
