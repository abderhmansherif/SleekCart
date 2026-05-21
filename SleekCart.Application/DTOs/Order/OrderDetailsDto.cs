using SleekCart.Domain.ValueObjects.Order;

namespace SleekCart.Application.DTOs.Order;

public sealed class OrderDetailsDto
{
    public Guid OrderId { get; set; }
    public Guid UserId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
    public ShippingAddressDto ShippingAddress { get; set; } = null!;
    public List<OrderItemDto> Items { get; set; } = new();
    public List<OrderTimeLine> History { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public Guid CouponId  { get; set; }
}
