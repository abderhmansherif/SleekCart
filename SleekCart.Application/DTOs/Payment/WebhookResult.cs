using SleekCart.Domain.Enums.Payment;

namespace SleekCart.Application.DTOs.Payment;

public sealed class WebhookResult
{
    public string ProviderPaymentId { get; set; } = string.Empty;
    public string ProviderSessionId { get; set; } = string.Empty;
    public PaymentStatus Status {get; set;}
}