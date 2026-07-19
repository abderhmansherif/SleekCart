
using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.ValueObjects.Coupon;
using SleekCart.Domain.Entities;
using SleekCart.Domain.Enums.Coupon;
using SleekCart.Domain.ValueObjects.Coupon;

namespace e_commerse.Domain.Factories
{
    internal class CouponFactory : ICouponFactory
    {
        public Coupon CreateMultiUse(CouponId id, CouponCode code, UsageLimit usageLimit, DateTime expiryDate, Discount discount)
            => new Coupon(
                id: id,
                code: code,
                usageLimit: usageLimit,
                expiryDate: expiryDate,
                discount: discount);

        public Coupon CreateSingleUse(CouponId id, CouponCode code, DateTime expiryDate, Discount discount)
            => new Coupon(
                id: id,
                code:code,
                expiryDate: expiryDate,
                discount: discount);
    }
}
