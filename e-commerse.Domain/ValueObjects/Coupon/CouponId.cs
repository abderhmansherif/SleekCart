using e_commerse.Domain.Exceptions.Coupon;

namespace e_commerse.Domain.ValueObjects.Coupon
{
    public record CouponId
    {
        public Guid Value { get; }

        public CouponId(Guid value)
        {
            if(value == Guid.Empty)
            {
                throw new EmptyCouponIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(CouponId id) => id.Value; 

        public static implicit operator CouponId(Guid value) => new CouponId(value);
    }
}
