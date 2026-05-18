namespace SleekCart.Application.DTOs.Order;

public sealed class OrderTimeLine
{
    public string Status { get; set; } = string.Empty;
    public DateTime At { get; set; }
}