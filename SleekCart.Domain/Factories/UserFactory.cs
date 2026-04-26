using e_commerse.Domain.Abstractions.Factories;
using SleekCart.Domain.Entities;
using SleekCart.Domain.Enums.User;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Factories
{
    public class UserFactory : IUserFactory
    {
        public User Create(UserId id, UserFullName fullName, Email email, UserRole role)
            => new User(id, fullName, email, role);
    }
}
