using SleekCart.Domain.ValueObjects.User;
using SleekCart.Shared.Abstractions.Events;

namespace SleekCart.Domain.Events.User
{
    public record UserRegisteredEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }
        public UserId UserId { get; }
        public Email Email { get; set; }
        public UserFullName FullName { get; set; }

        public UserRegisteredEvent(UserFullName fullName, UserId userId, Email email)
        {
            this.FullName = fullName;
            this.UserId = userId;
            this.Email = email;
            this.OccurredOn = DateTime.UtcNow;
        }
    }
}
