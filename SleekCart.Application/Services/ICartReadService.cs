using SleekCart.Application.DTOs.Cart;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Application.Services;

public interface ICartReadService
{
    Task<CartDto> GetCartWithItemsAsync(UserId userId, CancellationToken ct);
}
