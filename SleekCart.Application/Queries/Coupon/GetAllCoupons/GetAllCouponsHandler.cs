using SleekCart.Application.DTOs.Coupon;
using SleekCart.Application.Services;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.Coupon.GetAllCoupons;

public sealed class GetAllCouponsHandler: IQueryHandler<GetAllCouponsQuery, List<CouponDto>>
{
    private readonly ICouponReadService _couponReadService;

    public GetAllCouponsHandler(ICouponReadService couponReadService)
    {
        this._couponReadService = couponReadService;
    }

    public async Task<List<CouponDto>> HandleAsync(GetAllCouponsQuery query, CancellationToken ct)
        => await _couponReadService.GetAllCouponsAsync(ct);
}
