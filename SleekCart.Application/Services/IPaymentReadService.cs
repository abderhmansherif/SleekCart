using SleekCart.Application.DTOs.Payment;
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Order;

namespace SleekCart.Application.Services;

public interface IPaymentReadService
{
    Task<PaymentDto> GetByOrderIdAsync(OrderId orderId, CancellationToken cancellationToken);
}
