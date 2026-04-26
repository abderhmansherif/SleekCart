using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Product;
using e_commerse.Domain.ValueObjects.Review;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Factories
{
    public class ReviewFactory : IReviewFactory
    {
        public Review Create(UserId userId, ProductId productId, ReviewRating rating, ReviewComment comment, bool isVerifiedPurchase = false)
            => new Review(userId, productId, rating, comment, isVerifiedPurchase);
    }
}
