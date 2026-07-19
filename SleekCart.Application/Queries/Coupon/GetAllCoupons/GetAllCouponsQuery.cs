using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.DTOs.Coupon;

namespace SleekCart.Application.Queries.Coupon.GetAllCoupons;

public sealed record GetAllCouponsQuery(): IQuery<List<CouponDto>>;
