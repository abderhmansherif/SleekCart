using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Coupon.UpdateCoupon;

public record UpdateCouponCommand(
    Guid CouponId, 
    string Code, 
    decimal Discount, 
    DateTime ExpiryDate) :ICommand;