
using e_commerse.Domain.Abstractions.Factories;
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Cart;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Factories
{
    public class CartFactory : ICartFactory
    {
        public Cart Create(CartId id, UserId userId)
            => new Cart(id: id, userId: userId);
    }
}
