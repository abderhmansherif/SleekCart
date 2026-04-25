using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Coupon
{
    public class InvalidCouponUsageLimitException: CouponException
    {
        public InvalidCouponUsageLimitException(): base("Invalid coupon usage limit. It must be greater than zero.")
        {
            
        }
    }
}
