using e_commerse.Domain.Exceptions.Coupon;

namespace e_commerse.Domain.ValueObjects.Coupon
{
    public record UsedCount
    {
        public int Value { get; }
        public UsedCount(int value)
        {
            if (value < 0)
            {
                throw new InvalidCouponUsedCountException();
            }

            Value = value;
        }

        public static implicit operator int(UsedCount usedCount) => usedCount.Value;
        public static implicit operator UsedCount(int value) => new UsedCount(value);
    }
}
