using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.Common.DTOs;
using SleekCart.Application.Order.DTOs;

namespace SleekCart.Application.Queries.Order.GetAllOrders;

public record GetAllOrdersQuery(int PageNumber = 1, int PageSize = 10): IQuery<PagedResult<OrderDto>>;