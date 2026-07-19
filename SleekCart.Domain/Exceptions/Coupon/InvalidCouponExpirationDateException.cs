using e_commerse.Domain.Abstractions.Exceptions;

namespace SleekCart.Domain.Exceptions.Coupon;

public sealed class InvalidCouponExpirationDateException: CouponException
{
    public InvalidCouponExpirationDateException(): base("The coupon expiration date must be in the future.")
    {
        
    }
}
