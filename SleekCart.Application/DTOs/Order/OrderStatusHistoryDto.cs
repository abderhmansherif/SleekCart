namespace SleekCart.Application.DTOs.Order;

public sealed class OrderStatusHistoryDto
{
    public Guid OrderId { get; set; }
    public string Status { get; set; } = string.Empty;
    public List<OrderTimeLine> Timeline {get; set;} = new();
    public DateTime EstimatedDelivery {get; set;}
}