using e_commerse.Domain.Abstractions.Factories;
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Product;
using SleekCart.Domain.ValueObjects.Review;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Factories
{
    public class ReviewFactory : IReviewFactory
    {
        public Review Create(UserId userId, ProductId productId, ReviewRating rating, ReviewComment comment, bool isVerifiedPurchase = false)
            => new Review(userId, productId, rating, comment, isVerifiedPurchase);
    }
}
