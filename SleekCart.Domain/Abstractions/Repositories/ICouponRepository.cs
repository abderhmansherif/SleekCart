using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Coupon;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface ICouponRepository
    {
        Task<Coupon> GetAsync(CouponId couponId);
        Task InsertAsync(Coupon coupon);
        Task UpdateAsync(Coupon coupon);
        Task DeleteAsync(CouponId couponId);
    }
}
