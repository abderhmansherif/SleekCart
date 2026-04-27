using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Email userId);
        Task InsertAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Email userId);
    }
}
