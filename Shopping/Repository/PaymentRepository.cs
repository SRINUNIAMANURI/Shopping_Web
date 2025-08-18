using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.DATA;
using Shopping.Models;
using Shopping.Models.DTO_s;
using Shopping.Models.InputDto_s;

namespace Shopping.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ShoppingDbContext dbContext;
        private readonly IMapper mapper;

        public PaymentRepository(ShoppingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<Payment>>GetAll()
        {
            var payments = await dbContext.Payments.ToListAsync();

            return payments;
        }

        public async Task<Payment>GetById(int id)
        {
            var payment = await dbContext.Payments.FirstOrDefaultAsync(p => p.Id == id);

            return payment;
        }

        public async Task<Payment>AddPayment(PaymentInputDto paymentInputDto)
        {
            var paymentmodel = mapper.Map<Payment>(paymentInputDto);

            await dbContext.Payments.AddAsync(paymentmodel);

            await dbContext.SaveChangesAsync();

            return paymentmodel;
        }

        public async Task<Payment> UpdatePayment(PaymentDto paymentDto)
        {
            var paymentModel = await dbContext.Payments.FirstOrDefaultAsync(p => p.Id == paymentDto.Id);

            if(paymentModel != null)
            {
                mapper.Map(paymentDto, paymentModel);
            }

            await dbContext.SaveChangesAsync();

            return paymentModel ?? new Payment();
        }

        public async Task<Payment> DeletePayment(int id)
        {
            var paymentModel = await dbContext.Payments.FirstOrDefaultAsync(p => p.Id == id);

            if( paymentModel != null )
            {
                dbContext.Payments.Remove(paymentModel);
            }

            await dbContext.SaveChangesAsync();

            return paymentModel?? new Payment();
        }
    }
}
