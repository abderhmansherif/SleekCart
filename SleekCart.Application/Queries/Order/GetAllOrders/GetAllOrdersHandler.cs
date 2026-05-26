using SleekCart.Application.Common.DTOs;
using SleekCart.Application.Order.DTOs;
using SleekCart.Application.Services;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.Order.GetAllOrders;

public sealed class GetAllOrdersHandler : IQueryHandler<GetAllOrdersQuery, PagedResult<OrderDto>>
{
    private readonly IOrderReadService _orderReadService;

    public GetAllOrdersHandler(IOrderReadService orderReadService)
    {
        this._orderReadService = orderReadService;
    }

    public async Task<PagedResult<OrderDto>> HandleAsync(GetAllOrdersQuery query, CancellationToken ct)
        => await _orderReadService.GetAllAsync(PageNumber: query.PageNumber, PageSize: query.PageSize, ct);
}