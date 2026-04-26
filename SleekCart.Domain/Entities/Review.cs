using SleekCart.Domain.ValueObjects.Product;
using SleekCart.Domain.ValueObjects.Review;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Domain.Entities
{
    public class Review
    {
        public UserId UserId { get; private set; }
        public ProductId ProductId { get; private set; }
        public ReviewRating Rating { get; private set; } // of 5
        public ReviewComment Comment { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsVerifiedPurchase { get; private set; }

        internal Review(UserId userId, ProductId productId, 
            ReviewRating rating, ReviewComment comment, bool isVerifiedPurchase = false)
        {
            UserId = userId;
            ProductId = productId;
            Rating = rating;
            Comment = comment;
            CreatedAt = DateTime.UtcNow;
            IsVerifiedPurchase = isVerifiedPurchase;
        }

        public void UpdateRating(ReviewRating newRating)
        {
            Rating = newRating;
        }

        public void UpdateComment(ReviewComment comment) 
        {
            this.Comment = comment;
        }
    }
}
