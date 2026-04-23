using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Cart;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface ICartFactory
    {
        Cart Create(CartId id, UserId userId);
    }
}
