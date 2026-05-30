using SleekCart.Application.Commands.Payment.ProcessPaymentWebhook;
using SleekCart.Application.DTOs.Payment;

namespace SleekCart.Application.Interfaces;

public interface IWebhookProcessor
{
    public PaymentProviderProcessors Provider { get; }
    Task<WebhookResult> ProcessAsync(string payload, string EventType);
}