namespace SleekCart.Domain.Abstractions.Domain
{
    public abstract class AggregateRoot
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
            => _domainEvents.Add(domainEvent);

        public void ClearFomainEvents()
            => _domainEvents.Clear();
    }
}
