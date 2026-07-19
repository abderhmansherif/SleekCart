using e_commerse.Domain.Abstractions.Exceptions;

namespace SleekCart.Domain.Exceptions.Coupon;

public class NotFoundCouponDiscountException: CouponException
{
    public NotFoundCouponDiscountException(): base("Coupon's Discount Can not be Empty.")
    {
        
    }
}