using SleekCart.Domain.Entities;
using SleekCart.Domain.ValueObjects.Coupon;

namespace e_commerse.Domain.Abstractions.Repositories
{
    public interface ICouponRepository
    {
        Task<Coupon> GetAsync(CouponId couponId, CancellationToken ct);
        Task InsertAsync(Coupon coupon, CancellationToken ct);
        Task UpdateAsync(Coupon coupon, CancellationToken ct);
        Task DeleteAsync(CouponId couponId, CancellationToken ct);
    }
}
