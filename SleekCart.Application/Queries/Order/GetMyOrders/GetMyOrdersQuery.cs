using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.Order.DTOs;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Application.Queries.Order.GetMyOrders;

public sealed record GetMyOrdersQuery(Guid UserId): IQuery<List<OrderDto>>;
