using Microsoft.Extensions.DependencyInjection;
using SleekCart.Shared.Abstractions.Events;

namespace SleekCart.Shared.Events;

public class EventPublisher : IEventPublisher
{
    private readonly IServiceProvider _serviceProvider;

    public EventPublisher(IServiceProvider serviceProvider)
        => this._serviceProvider = serviceProvider;

    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken ct) where TEvent : IDomainEvent
    {
        using var scope = _serviceProvider.CreateScope();
        var handlers = scope.ServiceProvider.GetServices<IEventHandler<TEvent>>();

        foreach(var handler in handlers)
            await handler.HandleAsync(@event, ct);
    }
}   
