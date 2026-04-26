
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Cart;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface ICartFactory
    {
        Cart Create(CartId id, UserId userId);
    }
}
