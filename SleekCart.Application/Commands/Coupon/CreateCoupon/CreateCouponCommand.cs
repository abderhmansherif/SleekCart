using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Coupon.CreateCoupon;

public record CreateCouponCommand
(
    string Code, 
    string CouponType, 
    DateTime ExpirationDate, 
    decimal DiscountValue,
    int? UsageLimit
    
    ): ICommand;