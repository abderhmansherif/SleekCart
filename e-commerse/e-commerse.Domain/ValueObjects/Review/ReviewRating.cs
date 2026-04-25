using e_commerse.Domain.Exceptions.Review;

namespace e_commerse.Domain.ValueObjects.Review
{
    public record ReviewRating
    {
        public decimal Value { get; }
        public ReviewRating(decimal value)
        {
            if(value < 0 || value > 5)
            {
                throw new InvalidRatingReviewException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(ReviewRating rating) => rating.Value;

        public static implicit operator ReviewRating(decimal value) => new ReviewRating(value);
    }
}
