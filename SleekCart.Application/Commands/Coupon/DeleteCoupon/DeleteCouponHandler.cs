using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;

namespace SleekCart.Application.Commands.Coupon.DeleteCoupon;

public sealed class DeleteCouponHandler: ICommandHandler<DeleteCouponCommand>
{
    private readonly ICouponRepository _couponRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCouponHandler(ICouponRepository couponRepository, IUnitOfWork unitOfWork)
    {
        this._couponRepository = couponRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(DeleteCouponCommand command, CancellationToken ct)
    {
        var coupon = await _couponRepository.GetByCodeAsync(command.CouponCode, ct);

        if(coupon is null)
        {
            throw new NotFoundCouponException();
        }

        await _couponRepository.DeleteAsync(coupon.Id, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
