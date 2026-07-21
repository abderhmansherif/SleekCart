
using SleekCart.Domain.Abstractions.Domain;
using SleekCart.Domain.ValueObjects.User;
using SleekCart.Shared.Abstractions.Events;

namespace SleekCart.Domain.Events.User
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
