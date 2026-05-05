using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.DTOs.Cart;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Services;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.Cart.GetMyCart;

public sealed class GetMyCartHandler: IQueryHandler<GetMyCartQuery, CartDto>
{
    private readonly ICartReadService _cartReadService;
    private readonly IUserRepository _userRepository;

    public GetMyCartHandler(ICartReadService cartReadService, IUserRepository userRepository)
    {
        this._cartReadService = cartReadService;
        this._userRepository = userRepository;
    }

    public async Task<CartDto> HandleAsync(GetMyCartQuery query, CancellationToken ct)
    {
        var user = await _userRepository.GetByIdAsync(query.UserId, ct);

        if(user is null)
        {
            throw new NotFoundUserException();
        }

        return await _cartReadService.GetCartWithItemsAsync(user.Id, ct);
    }
}
