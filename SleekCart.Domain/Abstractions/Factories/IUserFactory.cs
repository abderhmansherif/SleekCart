using e_commerse.Domain.Entities;
using e_commerse.Domain.Enums.User;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface IUserFactory
    {
        User Create(UserId id, UserFullName fullName, Email email, UserRole role);
    }
}
