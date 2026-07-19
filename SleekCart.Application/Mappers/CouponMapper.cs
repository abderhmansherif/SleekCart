using SleekCart.Application.DTOs.Coupon;
using SleekCart.Domain.Entities;
using SleekCart.Domain.Enums.Coupon;

namespace SleekCart.Application.Mappers;

public static class CouponMapper
{
    public static CouponDto ToDTO(this Coupon coupon)
        => new CouponDto
        {
            CouponId = coupon.Id.Value,
            Code = coupon.Code.Value,
            Discount = coupon.Discount.Value,
            ExpirationDate = coupon.ExpiryDate,
            Type = coupon.Type.ToString(),
            IsUsed = coupon.IsUsed.Value,
            UsageLimit = coupon.UsageLimit ,
            UsedCount = coupon.UsedCount
        };
}
