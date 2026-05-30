using e_commerse.Domain.Abstractions.Repositories;
using SleekCart.Application.Abstractions.Commands;
using SleekCart.Application.Exceptions;
using SleekCart.Application.Interfaces;
using SleekCart.Domain.Enums.Payment;

namespace SleekCart.Application.Commands.Payment.ProcessPaymentWebhook;

public sealed class ProcessPaymentWebhookHandler: ICommandHandler<ProcessPaymentWebhookCommand>
{
    private readonly IWebhookProcessorFactory _webhookProcessorFactory;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProcessPaymentWebhookHandler(IWebhookProcessorFactory webhookProcessorFactory, IPaymentRepository paymentRepository,
                    IUnitOfWork unitOfWork)
    {
        this._webhookProcessorFactory = webhookProcessorFactory;
        this._paymentRepository = paymentRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(ProcessPaymentWebhookCommand command, CancellationToken ct)
    {
        if(!Enum.TryParse<PaymentProviderProcessors>(command.Provider, out var provider))
        {
            throw new InvalidPaymentProviderException(command.Provider);
        }

        var processor = _webhookProcessorFactory.GetProcessor(provider);

        var result = await processor.ProcessAsync(payload: command.Payload, EventType: command.EventType);

        var payment = await _paymentRepository.GetByProviderSessionId(result.ProviderSessionId, ct);

        if(payment is null)
        {
            throw new NotFoundPaymentException();
        }

        payment.SetProviderPaymentId(result.ProviderPaymentId);
        
        switch(result.Status)
        {
            case PaymentStatus.Succeeded:
                payment.MarkAsCompleted();
                break;

            case PaymentStatus.Refunded:
                payment.MarkAsRefunded();
                break;
            
            case PaymentStatus.Failed:
                payment.MarkAsFailed();
                break;
        }

        await _paymentRepository.UpdateAsync(payment, ct);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}