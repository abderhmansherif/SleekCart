using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Cart;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(UserId userId);
        Task InsertAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(UserId userId);
    }
}
