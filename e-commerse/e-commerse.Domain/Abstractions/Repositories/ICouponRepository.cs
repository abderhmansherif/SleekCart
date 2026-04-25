using e_commerse.Domain.Entities;
using e_commerse.Domain.ValueObjects.Coupon;

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
