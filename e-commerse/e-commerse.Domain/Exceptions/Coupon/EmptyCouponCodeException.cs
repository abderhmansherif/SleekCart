using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Coupon
{
    public class EmptyCouponCodeException : CouponException
    {
        public EmptyCouponCodeException() : base("Coupon code cannot be empty.")
        { }
    }
}
