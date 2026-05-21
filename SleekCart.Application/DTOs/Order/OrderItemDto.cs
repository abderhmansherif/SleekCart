using SleekCart.Application.DTOs.Product;

namespace SleekCart.Application.DTOs.Order;

public sealed class OrderItemDto
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductMainImageUrl { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public MoneyDto Price {get; set;} = null!;
    public decimal Total {get; set;}
}
