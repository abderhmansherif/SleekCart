using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Order;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetAsync(OrderId orderId, CancellationToken ct);
        Task InsertAsync(Order order, CancellationToken ct);
        Task UpdateAsync(Order order, CancellationToken ct);
        Task DeleteAsync(OrderId orderId, CancellationToken ct);
    }
}
