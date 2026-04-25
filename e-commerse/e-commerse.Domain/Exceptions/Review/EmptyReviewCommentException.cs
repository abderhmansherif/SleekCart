using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Review
{
    public class EmptyReviewCommentException : ReviewException
    {
        public EmptyReviewCommentException() : base("Review comment cannot be empty.")
        {
        }
    }
}
