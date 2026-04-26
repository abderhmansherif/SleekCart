namespace SleekCart.Domain.Abstractions.Domain
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
