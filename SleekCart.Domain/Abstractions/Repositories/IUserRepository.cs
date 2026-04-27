using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Email userId, CancellationToken ct);
        Task InsertAsync(User user, CancellationToken ct);
        Task UpdateAsync(User user, CancellationToken ct);
        Task DeleteAsync(Email userId, CancellationToken ct);
    }
}
