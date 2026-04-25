using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Payment;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> GetAsync(PaymentId paymentId);
        Task InsertAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(PaymentId paymentId);
    }
}
