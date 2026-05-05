namespace SleekCart.Application.DTOs.Cart;

public sealed class CartDto
{
    public Guid CartId { get; set; }
    public decimal Total { get; set; }
    public string Currency { get; set; } = string.Empty;
    public List<CartItemDto> Items { get; set; } = new();
}
