using SleekCart.Application.DTOs.Coupon;

namespace SleekCart.Application.Services;

public interface ICouponReadService
{
    Task<List<CouponDto>> GetAllCouponsAsync(CancellationToken cancellationToken);
}
