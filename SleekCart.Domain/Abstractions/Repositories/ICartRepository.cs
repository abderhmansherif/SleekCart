using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Cart;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetAsync(CartId cartId, CancellationToken ct);
        Task InsertAsync(Cart cart, CancellationToken ct);
        Task UpdateAsync(Cart cart, CancellationToken ct);
        Task DeleteAsync(CartId cartId, CancellationToken ct);
    }
}
