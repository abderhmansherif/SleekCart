using e_commerse.Domain.Exceptions.Coupon;

namespace e_commerse.Domain.ValueObjects.Coupon
{
    public record UsageLimit
    {
        public int Value { get; }
        public UsageLimit(int value)
        {
            if (value <= 0)
            {
                throw new InvalidCouponUsageLimitException();
            }

            Value = value;
        }

        public static implicit operator int(UsageLimit usageLimit) => usageLimit.Value;
        public static implicit operator UsageLimit(int value) => new UsageLimit(value);
    }
}
