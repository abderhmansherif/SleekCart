using Microsoft.Extensions.Primitives;
using SleekCart.Application.Common.DTOs;
using SleekCart.Application.DTOs.Order;
using SleekCart.Application.Order.DTOs;
using SleekCart.Domain.ValueObjects.Order;
using SleekCart.Domain.ValueObjects.Product;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Application.Services;

public interface IOrderReadService
{
    Task<List<OrderDto>> GetOrdersByUserId(UserId userId, CancellationToken ct);
    Task<OrderDetailsDto> GetOrderDetailsByIdAsync(OrderId orderId, CancellationToken CancellationToken);
    Task<PagedResult<OrderDto>> GetAllAsync(int PageNumber, int PageSize, CancellationToken cancellationToken);
    Task<bool> HasPurchasedProductAsync(UserId userId, ProductId productId, CancellationToken CancellationTokenw);
}
