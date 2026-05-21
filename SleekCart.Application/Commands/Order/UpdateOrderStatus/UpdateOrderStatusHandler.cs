using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Domain.Enums.Order;

namespace SleekCart.Application.Commands.Order.UpdateOrderStatus;

public sealed class UpdateOrderStatusHandler: ICommandHandler<UpdateOrderStatusCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrderStatusHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        this._orderRepository = orderRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(UpdateOrderStatusCommand command, CancellationToken ct)
    {
        var order = await _orderRepository.GetAsync(command.OrderId, ct);

        if(order is null)
            throw new NotFoundOrderException();

        if(!Enum.TryParse<OrderStatus>(command.NewStatus, out var status))
            throw new InvalidOrderStatusException();

        order.UpdateStatus(status);
        
        await _orderRepository.UpdateAsync(order, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
