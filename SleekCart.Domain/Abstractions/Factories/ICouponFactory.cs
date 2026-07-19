
using e_commerse.Domain.ValueObjects.Coupon;
using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Coupon;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface ICouponFactory
    {

        Coupon CreateSingleUse(CouponId id, CouponCode code, DateTime expiryDate, Discount discount);
        Coupon CreateMultiUse(CouponId id, CouponCode code, UsageLimit usageLimit,
            DateTime expiryDate , Discount discount);
    }
}
