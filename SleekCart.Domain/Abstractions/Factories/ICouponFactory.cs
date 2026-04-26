using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Coupon;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface ICouponFactory
    {
        Coupon CreateSingleUse(CouponId id, CouponCode code, bool isPercentage, DateTime expiryDate);
        Coupon CreateMultiUse(CouponId id, CouponCode code, bool isPercentage, UsageLimit usageLimit,
            UsedCount usedCount, DateTime expiryDate);
    }
}
