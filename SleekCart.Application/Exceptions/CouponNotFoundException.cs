namespace SleekCart.Application.Exceptions;

public sealed class CouponNotFoundException: ApplicationException
{
    public CouponNotFoundException(): base("Coupon not found.")
    {
        
    }
}
