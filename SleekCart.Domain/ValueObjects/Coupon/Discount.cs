using SleekCart.Domain.Exceptions.Coupon;

namespace SleekCart.Domain.ValueObjects.Coupon;

public record Discount
{
    public decimal Value {get;}

    public Discount(decimal value)
    {
        if(value <= 0)
        {
            throw new NotFoundCouponDiscountException();
        }
        this.Value = value;
    }

    public static implicit operator decimal (Discount discount)
        => discount.Value;

    public static implicit operator Discount (decimal Value)
        => new Discount(Value);
}