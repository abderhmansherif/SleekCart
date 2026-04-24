using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Cart;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Factories
{
    public class CartFactory : ICartFactory
    {
        public Cart Create(CartId id, UserId userId)
            => new Cart(id: id, userId: userId);
    }
}
