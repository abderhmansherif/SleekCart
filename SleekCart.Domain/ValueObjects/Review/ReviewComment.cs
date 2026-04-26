using e_commerse.Domain.Exceptions.Review;

namespace SleekCart.Domain.ValueObjects.Review
{
    public record ReviewComment
    {
        public string Value { get;}
        public ReviewComment(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyReviewCommentException();
            }

            if(value.Length > 500)
            {
                throw new TooLongReviewCommentException();
            }

            Value = value;
        }

        public static implicit operator string(ReviewComment comment) => comment.Value;
        public static implicit operator ReviewComment(string value) => new ReviewComment(value);
    }
}
