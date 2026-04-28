using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.DTOs;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Mappers;
using SleekCart.Application.Services;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.GetMyProfile;

public sealed class GetMyProfileHandler : IQueryHandler<GetMyProfileQuery, ProfileDto>
{
    private readonly IOrderReadService _orderReadService;
    private readonly IUserRepository _userRepository;

    public GetMyProfileHandler(IOrderReadService orderReadService, IUserRepository userRepository)
    {
        this._orderReadService = orderReadService;
        this._userRepository = userRepository;
    }
    public async Task<ProfileDto> HandleAsync(GetMyProfileQuery query, CancellationToken ct)
    {
        var user = await _userRepository.GetByIdAsync(query.UserId, ct);

        if(user is null)
        {
            throw new NotFoundUserException();
        }

        var orders = await _orderReadService.GetOrdersByUserId(query.UserId, ct);

        if(orders.Count <= 0)
            orders = new();

        return user.ToProfile(orders);
    }
}
