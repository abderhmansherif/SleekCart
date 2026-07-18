using SleekCart.Application.Abstractions.Commands;

namespace SleekCart.Application.Commands.Coupon.CreateCoupon;

public record CreateCouponCommand
(
    string Code, 
    string CouponType, 
    DateTime ExpirationDate, 
    bool isPercentage, 
    int UsageLimit
    
    ): ICommand;