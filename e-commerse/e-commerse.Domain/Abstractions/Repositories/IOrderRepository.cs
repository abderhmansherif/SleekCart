using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Order;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetAsync(OrderId orderId);
        Task InsertAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(OrderId orderId);
    }
}
