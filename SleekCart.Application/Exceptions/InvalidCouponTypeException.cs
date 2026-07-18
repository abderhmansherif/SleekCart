namespace SleekCart.Application.Exceptions;

public class InvalidCouponTypeException: ApplicationException
{
    public InvalidCouponTypeException(string type): base($"There is no coupon type with name '{type}'")
    {}
}