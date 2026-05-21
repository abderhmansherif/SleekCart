using SleekCart.Application.DTOs.Order;
using SleekCart.Application.Services;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.Order.GetOrderById;

public sealed class GetOrderByIdHandler: IQueryHandler<GetOrderByIdQuery, OrderDetailsDto>
{
    private readonly IOrderReadService _orderReadService;

    public GetOrderByIdHandler(IOrderReadService orderReadService)
    {
        this._orderReadService = orderReadService;
    }

    public async Task<OrderDetailsDto> HandleAsync(GetOrderByIdQuery query, CancellationToken ct)
        => await _orderReadService.GetOrderDetailsByIdAsync(query.OrderId, ct);
}
