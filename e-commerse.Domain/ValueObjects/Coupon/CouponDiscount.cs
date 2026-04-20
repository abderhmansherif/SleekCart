using e_commerse.Domain.Exceptions.Coupon;

namespace e_commerse.Domain.ValueObjects.Coupon
{
    public record CouponDiscount
    {
        public decimal Value { get; }

        public CouponDiscount(decimal value)
        {
            if(value <= 0)
            {
                throw new InvalidCouponDiscountException();
            }

            Value = value;
        }

        public static implicit operator decimal(CouponDiscount discount) => discount.Value;
        public static implicit operator CouponDiscount(decimal value) => new CouponDiscount(value);
    }
}

