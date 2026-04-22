namespace e_commerse.Domain.Abstractions.Domain
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
