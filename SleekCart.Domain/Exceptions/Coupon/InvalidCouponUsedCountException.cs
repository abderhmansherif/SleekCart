using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Coupon
{
    public class InvalidCouponUsedCountException: CouponException
    {
        public InvalidCouponUsedCountException(): base("Invalid coupon used count. It cannot be negative.")
        {
            
        }
    }
}
