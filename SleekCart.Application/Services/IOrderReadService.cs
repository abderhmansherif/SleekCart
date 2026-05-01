using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Application.Services;

public interface IOrderReadService
{
    Task<List<SleekCart.Domain.Entities.Order>> GetOrdersByUserId(UserId userId, CancellationToken ct);
}
