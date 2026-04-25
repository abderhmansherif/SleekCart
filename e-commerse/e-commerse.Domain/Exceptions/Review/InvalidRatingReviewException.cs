using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Review
{
    public class InvalidRatingReviewException : ReviewException
    {
        public InvalidRatingReviewException(decimal rating) : base($"Rating must be between 0 and 5. Invalid value: {rating}")
        {
        }
    }
}
