using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Coupon
{
    public class InvalidCouponDiscountException : CouponException
    {
        public InvalidCouponDiscountException(): base("Invalid coupon discount value. It must be greater than zero.")
        {
            
        }
    }
}
