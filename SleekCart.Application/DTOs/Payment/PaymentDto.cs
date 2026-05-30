using SleekCart.Application.DTOs.Product;

namespace SleekCart.Application.DTOs.Payment;

public sealed class PaymentDto
{
    public Guid PaymentId { get; set; }
    public Guid OrderId { get; set; }
    public Guid UserId { get; set; }
    public string Status { get; set; } = string.Empty;
    public MoneyDto Total { get; set; } = null!;
    public string Provider { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
