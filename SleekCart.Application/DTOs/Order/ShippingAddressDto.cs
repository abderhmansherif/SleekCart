namespace SleekCart.Application.DTOs.Order;

public sealed class ShippingAddressDto
{
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}
