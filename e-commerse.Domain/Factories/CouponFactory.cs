using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Coupon;

namespace e_commerse.Domain.Factories
{
    internal class CouponFactory : ICouponFactory
    {
        public Coupon CreateMultiUse(CouponId id, CouponCode code, bool isPercentage, UsageLimit usageLimit, UsedCount usedCount, DateTime expiryDate)
            => new Coupon(id, code, isPercentage, usageLimit, usedCount, expiryDate);

        public Coupon CreateSingleUse(CouponId id, CouponCode code, bool isPercentage, DateTime expiryDate)
            => new Coupon(id, code, isPercentage, expiryDate);
    }
}
