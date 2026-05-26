using SleekCart.Domain.Enums.Payment;

namespace SleekCart.Application.DTOs.Payment;

public class PaymentResult
{
    public string Status { get; set; } = string.Empty;
    public Guid PaymentId { get; set; }
    public string? RedirectUrl { get; set; } = string.Empty;
}