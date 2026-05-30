using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.DTOs.Payment;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Services;
using SleekCart.Shared.Abstractions.Queries;

namespace SleekCart.Application.Queries.Payment.GetPaymentByOrder;

public sealed class GetPaymentByOrderHandler: IQueryHandler<GetPaymentByOrderQuery, PaymentDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPaymentReadService _paymentReadService;

    public GetPaymentByOrderHandler(IOrderRepository orderRepository, IPaymentRepository paymentRepository, 
                            IUserRepository userRepository, IPaymentReadService paymentReadService)
    {
        this._orderRepository = orderRepository;
        this._paymentRepository = paymentRepository;
        this._userRepository = userRepository;
        this._paymentReadService = paymentReadService;
    }

    public async Task<PaymentDto> HandleAsync(GetPaymentByOrderQuery query, CancellationToken ct)
    {
        var order = await _orderRepository.GetAsync(query.OrderId, ct);

        if(order is null)
            throw new NotFoundOrderException();

        var payment = await _paymentReadService.GetByOrderIdAsync(order.Id, ct);

        if(payment is null)
            throw new NotFoundPaymentException(order.Id.Value.ToString());

        return payment;
    }
}
