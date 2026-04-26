using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Coupon
{
    public class CouponNotValidException : CouponException
    {
        public CouponNotValidException() : base("The coupon is not valid or expired.")
        {
        }
    }
}
