using SleekCart.Domain.Entities;
using SleekCart.Domain.Enums.User;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface IUserFactory
    {
        User CreateCustomer(UserId id, UserFullName fullName, Email email);
        User CreateAdmin(UserId id, UserFullName fullName, Email email);
    }
}
