using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;

namespace SleekCart.Application.Commands.Order.CancelOrder;

public sealed class CancelOrderHandler: ICommandHandler<CancelOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CancelOrderHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        this._orderRepository = orderRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(CancelOrderCommand command, CancellationToken ct)
    {
        var order = await _orderRepository.GetAsync(command.OrderId, ct);

        if(order is null)
        {
            throw new NotFoundOrderException();
        }

        order.Cancel();

        await _orderRepository.UpdateAsync(order, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
