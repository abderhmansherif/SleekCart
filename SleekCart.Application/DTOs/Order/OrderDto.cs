namespace SleekCart.Application.Order.DTOs;

public class OrderDto
{
    public Guid OrderId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string TotalPrices { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
