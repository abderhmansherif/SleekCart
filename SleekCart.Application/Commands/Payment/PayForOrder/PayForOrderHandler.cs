using e_commerse.Domain.Abstractions.Exceptions;
using e_commerse.Domain.Abstractions.Factories;
using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.DTOs.Payment;
using SleekCart.Application.DTOs.Product;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Interfaces;
using SleekCart.Domain.Enums.Payment;

namespace SleekCart.Application.Commands.Payment.PayForOrder;

public sealed class PayForOrderHandler: ICommandHandler<PayForOrderCommand, PaymentResult>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentStrategyFactory _paymentStrategyFactory;
    private readonly IPaymentFactory _paymentFactory;

    public PayForOrderHandler(IOrderRepository orderRepository, IPaymentRepository paymentRepository,
                             IUserRepository userRepository, IUnitOfWork unitOfWork,
                            IPaymentStrategyFactory paymentStrategyFactory, IPaymentFactory paymentFactory)
    {
        this._orderRepository = orderRepository;
        this._paymentRepository = paymentRepository;
        this._userRepository = userRepository;
        this._unitOfWork = unitOfWork;
        this._paymentStrategyFactory = paymentStrategyFactory;
        this._paymentFactory = paymentFactory;
    }

    public async Task<PaymentResult> HandleAsync(PayForOrderCommand command, CancellationToken ct)
    {
        var order = await _orderRepository.GetAsync(command.OrderId, ct);

        if(order is null)
            throw new NotFoundOrderException();
        
        var user = await _userRepository.GetByIdAsync(command.UserId, ct);

        if(user is null)
            throw new NotFoundUserException();

        if(!Enum.TryParse<PaymentProvider>(command.PaymentProvider, out var provider))
        {
            throw new InvalidPaymentProviderException(command.PaymentProvider);
        }

        var strategy = _paymentStrategyFactory.GetStrategy(provider);

        var result = await strategy.ProcessPaymentAsync(new PaymentInvoice(
            orderId: order.Id,
            price: new MoneyDto{Amount = order.Total.Amount, Currency = order.Total.Currency},
            $"Pay For Order Id: {order.Id}",
            user.Email
        ));

        if(provider != PaymentProvider.Cash)
        {
            var payment = _paymentFactory.CreatePayment(
                id: result.PaymentId,
                orderId: order.Id,
                userId: user.Id,
                order.Total,
                provider); 

            await _paymentRepository.InsertAsync(payment, ct);
            await _unitOfWork.SaveChangesAsync(ct);
        }

        return result;
    }
}