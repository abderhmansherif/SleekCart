
using e_commerse.Domain.ValueObjects.Coupon;
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Coupon;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface ICouponFactory
    {
        Coupon CreateSingleUse(CouponId id, CouponCode code, bool isPercentage, DateTime expiryDate);
        Coupon CreateMultiUse(CouponId id, CouponCode code, bool isPercentage, UsageLimit usageLimit,
            UsedCount usedCount, DateTime expiryDate);
    }
}
