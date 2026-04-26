
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Product;
using SleekCart.Domain.ValueObjects.Review;
using SleekCart.Domain.ValueObjects.User;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface IReviewFactory
    {
        Review Create(UserId userId, ProductId productId,
            ReviewRating rating, ReviewComment comment, bool isVerifiedPurchase = false); 
    }
}
