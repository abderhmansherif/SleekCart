using SleekCart.Application.DTOs.Order;

namespace SleekCart.Application.Mappers.Order;

public static class OrderStatusHistoryMapper
{
    public static OrderStatusHistoryDto ToStatusHistory(this Domain.Entities.Order order)
        => new OrderStatusHistoryDto
        {
            OrderId = order.Id,
            Status = order.Status.ToString(),
            Timeline = order.History.OrderBy(x => x.ChangedAt).Select(x => new OrderTimeLine
            {
                Status = x.Status.ToString(),
                At = x.ChangedAt
            })
            .ToList(),
            EstimatedDelivery = order.CreatedAt.AddDays(3)
        };
}