using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Domain.Enums.Coupon;

namespace SleekCart.Application.Commands.Coupon.CreateCoupon;

public sealed class CreateCouponHandler: ICommandHandler<CreateCouponCommand>
{
    private readonly ICouponFactory _couponFactory;
    private readonly ICouponRepository _couponRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCouponHandler(ICouponFactory couponFactory, ICouponRepository couponRepository,
            IUnitOfWork unitOfWork)
    {
        this._couponFactory = couponFactory;
        this._couponRepository = couponRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(CreateCouponCommand command, CancellationToken ct)
    {
        if(!Enum.TryParse<CouponType>(command.CouponType, out var type))
        {
            throw new InvalidCouponTypeException(command.CouponType);
        }
        
        var coupon = type switch
        {
            CouponType.MultiUse => _couponFactory.CreateMultiUse(
                                        id: Guid.NewGuid(), 
                                        code: command.Code, 
                                        discount: command.DiscountValue,
                                        expiryDate: command.ExpirationDate, 
                                        usageLimit: command.UsageLimit),
            
            CouponType.SingleUse => _couponFactory.CreateSingleUse(
                                        id: Guid.NewGuid(), 
                                        code: command.Code, 
                                        discount: command.DiscountValue,
                                        expiryDate: command.ExpirationDate),
            
            _ => throw new InvalidCouponTypeException(command.CouponType)
        };

        await _couponRepository.InsertAsync(coupon, ct);
        await _unitOfWork.SaveChangesAsync(ct);       
    }
}