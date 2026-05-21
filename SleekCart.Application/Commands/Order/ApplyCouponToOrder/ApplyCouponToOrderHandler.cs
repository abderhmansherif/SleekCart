using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;

namespace SleekCart.Application.Commands.Order.ApplyCouponToOrder;

public sealed class ApplyCouponToOrderHandler: ICommandHandler<ApplyCouponToOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICouponRepository _couponRepository;

    public ApplyCouponToOrderHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, 
                    ICouponRepository couponRepository)
    {
        this._orderRepository = orderRepository;
        this._unitOfWork = unitOfWork;
        this._couponRepository = couponRepository;
    }

    public async Task HandleAsync(ApplyCouponToOrderCommand command, CancellationToken ct)
    {
        var order = await _orderRepository.GetAsync(command.OrderId, ct);

        if(order is null)
            throw new NotFoundOrderException();

        var coupon = await _couponRepository.GetByCodeAsync(command.CouponCode, ct);

        if(coupon is null)
            throw new CouponNotFoundException();

        order.ApplyCoupon(coupon);

        await _orderRepository.UpdateAsync(order, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
