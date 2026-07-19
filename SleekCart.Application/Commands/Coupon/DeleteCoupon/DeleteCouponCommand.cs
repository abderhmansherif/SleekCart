using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Coupon.DeleteCoupon;

public sealed record DeleteCouponCommand(string CouponCode): ICommand;
