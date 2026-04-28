using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Application.Services;

public interface IOrderReadService
{
    Task<List<Order>> GetOrdersByUserId(UserId userId, CancellationToken ct);
}
