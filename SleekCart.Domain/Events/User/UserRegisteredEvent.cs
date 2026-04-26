using e_commerse.Domain.Abstractions.Domain;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Events.User
{
    public record UserRegisteredEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }
        public UserId UserId { get; }
        public Email Email { get; set; }

        public UserRegisteredEvent(UserId userId, Email email)
        {
            UserId = userId;
            Email = email;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
