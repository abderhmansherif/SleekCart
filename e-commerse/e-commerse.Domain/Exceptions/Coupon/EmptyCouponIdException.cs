using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Coupon
{
    public class EmptyCouponIdException : CouponException
    {
        public EmptyCouponIdException() : base("CouponId cannot be empty.")
        { }
    }
}
