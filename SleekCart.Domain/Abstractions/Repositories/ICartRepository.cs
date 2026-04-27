using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Cart;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetAsync(CartId cartId);
        Task InsertAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(CartId cartId);
    }
}
