using e_commerse.Domain.Abstractions.Factories;
using SleekCart.Domain.Entities;
using SleekCart.Domain.Enums.User;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Factories
{
    public class UserFactory : IUserFactory
    {
        public User CreateCustomer(UserId id, UserFullName fullName, Email email)
            => new User(id, fullName, email, UserRole.Customer);

        public User CreateAdmin(UserId id, UserFullName fullName, Email email)
            => new User(id, fullName, email, UserRole.Admin);
    }
}
