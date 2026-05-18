using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.DTOs.Order;

namespace SleekCart.Application.Queries.Order.GetOrderTracking;

public sealed record GetOrderTrackingQuery(Guid OrderId): IQuery<OrderStatusHistoryDto>;
