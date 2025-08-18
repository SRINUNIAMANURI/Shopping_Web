using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Models.DTO_s;
using Shopping.Models.InputDto_s;
using Shopping.Repository;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IMapper mapper;

        public PaymentsController(IPaymentRepository paymentRepository, IMapper mapper)
        {
            this.paymentRepository = paymentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await paymentRepository.GetAll();

            return Ok(mapper.Map<List<PaymentDto>>(payments));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payment = await paymentRepository.GetById(id);

            return Ok(mapper.Map<PaymentDto>(payment));
        }

        [HttpPost]
        public async Task<IActionResult> AddPAyment([FromBody] PaymentInputDto paymentInputDto)
        {
            var payment = await paymentRepository.AddPayment(paymentInputDto);

            return Ok(mapper.Map<PaymentDto>(payment));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePayment([FromBody] PaymentDto paymentDto)
        {
            var payment = await paymentRepository.UpdatePayment(paymentDto);

            return Ok(mapper.Map<PaymentDto>(payment));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await paymentRepository.DeletePayment(id);

            return Ok(mapper.Map<PaymentDto>(payment));
        }
    }
}
