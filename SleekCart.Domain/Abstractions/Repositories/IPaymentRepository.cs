using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Payment;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment> GetAsync(PaymentId paymentId, CancellationToken ct);
        Task InsertAsync(Payment payment, CancellationToken ct);
        Task UpdateAsync(Payment payment, CancellationToken ct);
        Task DeleteAsync(PaymentId paymentId, CancellationToken ct);
    }
}
