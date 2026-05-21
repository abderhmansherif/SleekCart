using SleekCart.Application.Order.DTOs;
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Application.Services;

public interface IOrderReadService
{
    Task<List<OrderDto>> GetOrdersByUserId(UserId userId, CancellationToken ct);
}
