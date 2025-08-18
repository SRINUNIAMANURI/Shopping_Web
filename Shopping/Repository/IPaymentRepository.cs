using Shopping.Models;
using Shopping.Models.DTO_s;
using Shopping.Models.InputDto_s;

namespace Shopping.Repository
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAll();
        Task<Payment> GetById(int id);
        Task<Payment> AddPayment(PaymentInputDto paymentInputDto);
        Task<Payment> UpdatePayment(PaymentDto paymentDto);
        Task<Payment> DeletePayment(int id);
    }
}
