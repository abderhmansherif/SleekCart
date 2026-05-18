using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.DTOs.Order;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Mappers.Order;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.Order.GetOrderTracking;

public sealed class GetOrderTrackingHandler: IQueryHandler<GetOrderTrackingQuery, OrderStatusHistoryDto>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderTrackingHandler(IOrderRepository orderRepository)
    {
        this._orderRepository = orderRepository;
    }

    public async Task<OrderStatusHistoryDto> HandleAsync(GetOrderTrackingQuery query, CancellationToken ct)
    {
        var order = await _orderRepository.GetAsync(query.OrderId, ct);

        if(order is null)
        {
            throw new NotFoundOrderException();
        }

        return order.ToStatusHistory();
    }
}