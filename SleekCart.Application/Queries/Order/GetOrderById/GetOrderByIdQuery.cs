using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.DTOs.Order;

namespace SleekCart.Application.Queries.Order.GetOrderById;

public sealed record GetOrderByIdQuery(Guid OrderId): IQuery<OrderDetailsDto>;
