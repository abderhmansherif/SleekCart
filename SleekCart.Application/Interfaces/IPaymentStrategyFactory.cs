using SleekCart.Domain.Enums.Payment;

namespace SleekCart.Application.Interfaces;

public interface IPaymentStrategyFactory
{
    IPaymentStrategy GetStrategy(PaymentProvider paymentProvider);
}