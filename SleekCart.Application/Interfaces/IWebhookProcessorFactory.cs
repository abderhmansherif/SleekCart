using SleekCart.Application.Commands.Payment.ProcessPaymentWebhook;

namespace SleekCart.Application.Interfaces;

public interface IWebhookProcessorFactory
{
    IWebhookProcessor GetProcessor(PaymentProviderProcessors Provider);
}