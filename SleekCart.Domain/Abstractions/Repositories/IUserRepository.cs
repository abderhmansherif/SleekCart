using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Email Email, CancellationToken ct);
        Task<User> GetByIdAsync(UserId userId, CancellationToken ct);
        Task InsertAsync(User user, CancellationToken ct);
        Task UpdateAsync(User user, CancellationToken ct);
        Task DeleteAsync(Email Email, CancellationToken ct);
    }
}
