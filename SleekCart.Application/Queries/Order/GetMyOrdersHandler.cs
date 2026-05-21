using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Order.DTOs;
using SleekCart.Application.Queries.Order.GetMyOrders;
using SleekCart.Application.Services;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.Order;

public sealed class GetMyOrdersHandler: IQueryHandler<GetMyOrdersQuery, List<OrderDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IOrderReadService _orderReadService;

    public GetMyOrdersHandler(IUserRepository userRepository, IOrderReadService orderReadService)
    {
        this._userRepository = userRepository;
        this._orderReadService = orderReadService;
    }

    public async Task<List<OrderDto>> HandleAsync(GetMyOrdersQuery query, CancellationToken ct)
    {
        var user = await _userRepository.GetByIdAsync(query.UserId, ct);

        if(user is null)
        {
            throw new NotFoundUserException();
        }

        var orders = await _orderReadService.GetOrdersByUserId(query.UserId, ct);

        return orders;
    }
}
