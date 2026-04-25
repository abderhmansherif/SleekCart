using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Cart;
using e_commerse.Domain.ValueObjects.Product;
using e_commerse.Domain.ValueObjects.User;

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
