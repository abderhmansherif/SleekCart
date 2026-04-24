using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Entities;
using e_commerse.Domain.Enums.User;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Factories
{
    public class UserFactory : IUserFactory
    {
        public User Create(UserId id, UserFullName fullName, Email email, UserRole role)
            => new User(id, fullName, email, role);
    }
}
