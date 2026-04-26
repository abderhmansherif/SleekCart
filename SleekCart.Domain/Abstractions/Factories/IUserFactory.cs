using SleekCart.Domain.Entities;
using SleekCart.Domain.Enums.User;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface IUserFactory
    {
        User Create(UserId id, UserFullName fullName, Email email, UserRole role);
    }
}
