using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Review
{
    public class TooLongReviewCommentException : ReviewException
    {
        public TooLongReviewCommentException() : base("Review comment is too long.")
        {
        }
    }
}
