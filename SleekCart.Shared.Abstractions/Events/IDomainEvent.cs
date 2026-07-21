namespace SleekCart.Shared.Abstractions.Events;

    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }

