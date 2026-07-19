namespace SleekCart.Application.DTOs.Coupon;

public class CouponDto
{
    public Guid CouponId { get; set; }
    public string Code { get; set; } = null!;
    public decimal Discount { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Type { get; set; } = null!;
    public bool? IsUsed { get; set; }
    public int? UsageLimit { get; set; }
    public int? UsedCount { get; set; }
}
