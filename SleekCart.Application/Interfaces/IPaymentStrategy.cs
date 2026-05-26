using SleekCart.Application.DTOs.Payment;
using SleekCart.Domain.Enums.Payment;

namespace SleekCart.Application.Interfaces;

public interface IPaymentStrategy
{
    string Provider { get; }
    Task<PaymentResult> ProcessPaymentAsync(PaymentInvoice invoice);
}