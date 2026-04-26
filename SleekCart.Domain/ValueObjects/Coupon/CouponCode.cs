using e_commerse.Domain.Exceptions.Coupon;

namespace e_commerse.Domain.ValueObjects.Coupon
{
    public record CouponCode
    {
        public string Value { get;}
        public CouponCode(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyCouponCodeException();
            }

            Value = value;
        }

        public static implicit operator string(CouponCode code) => code.Value;
        public static implicit operator CouponCode(string value) => new CouponCode(value);
    }
}
