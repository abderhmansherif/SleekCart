namespace SleekCart.Application.DTOs;

public class AddressDto
{
    public Guid AddressId { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Building { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}
