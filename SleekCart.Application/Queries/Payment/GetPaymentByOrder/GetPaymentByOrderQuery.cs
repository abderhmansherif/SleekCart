using SleekCart.Application.Abstractions.Queries;
using SleekCart.Application.DTOs.Payment;

namespace SleekCart.Application.Queries.Payment.GetPaymentByOrder;

public sealed record GetPaymentByOrderQuery(Guid OrderId): IQuery<PaymentDto>;
