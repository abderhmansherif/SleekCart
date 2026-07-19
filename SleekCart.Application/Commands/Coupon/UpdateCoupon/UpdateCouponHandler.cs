using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Domain.Exceptions.Coupon;

namespace SleekCart.Application.Commands.Coupon.UpdateCoupon;

public class UpdateCouponHandler: ICommandHandler<UpdateCouponCommand>
{
    private readonly ICouponRepository _couponRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCouponHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork)
    {
        this._couponRepository = couponRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(UpdateCouponCommand command, CancellationToken ct)
    {
        var (CouponId, Code, Discount, ExpiryDate) = command;

        var coupon = await _couponRepository.GetAsync(CouponId, ct);

        if(coupon is null)
        {
            throw new NotFoundCouponException();
        }

        coupon.UpdateCode(Code);
        coupon.UpdateDiscount(Discount);
        coupon.UpdateExpirationDate(ExpiryDate);

        await _couponRepository.UpdateAsync(coupon, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}