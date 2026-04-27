using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Product;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface IReviewRepository
    {
        Task<Review> GetAsync(UserId userId, ProductId productId, CancellationToken ct);
        Task InsertAsync(Review review, CancellationToken ct);
        Task UpdateAsync(Review review, CancellationToken ct);
        Task DeleteAsync(UserId userId, ProductId productId, CancellationToken ct);
    }
}
