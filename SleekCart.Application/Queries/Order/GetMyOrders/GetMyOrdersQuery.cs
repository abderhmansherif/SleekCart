using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.Order.DTOs;

namespace SleekCart.Application.Queries.Order.GetMyOrders;

public sealed record GetMyOrdersQuery(Guid UserId): IQuery<List<OrderDto>>;
