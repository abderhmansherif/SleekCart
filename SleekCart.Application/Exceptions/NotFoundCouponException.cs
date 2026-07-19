namespace SleekCart.Application.Exceptions;

public class NotFoundCouponException : ApplicationException 
{
    public NotFoundCouponException(): base("Not Found Coupon.")
    {
        
    }
}