using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Product;
using e_commerse.Domain.ValueObjects.Review;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface IReviewFactory
    {
        Review Create(UserId userId, ProductId productId,
            ReviewRating rating, ReviewComment comment, bool isVerifiedPurchase = false); 
    }
}
