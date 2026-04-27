using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Product;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface IReviewRepository
    {
        Task<Review> GetAsync(UserId userId, ProductId productId);
        Task InsertAsync(Review review);
        Task UpdateAsync(Review review);
        Task DeleteAsync(UserId userId, ProductId productId);
    }
}
