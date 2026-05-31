using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Coupon.CreateCoupon;

public record CreateCouponCommand
(
    string Code, 
    string CouponType, 
    TimeSpan Duration, 
    bool isPercentage, 
    int UsageLimit
    
    ): ICommand;