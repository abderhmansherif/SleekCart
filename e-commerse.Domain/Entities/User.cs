using e_commerse.Domain.Abstractions.Domain;
using e_commerse.Domain.Enums.User;
using e_commerse.Domain.Events.User;
using e_commerse.Domain.Exceptions.User;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Entities
{
    internal class User: AggregateRoot
    {
        public UserId Id { get; private set; }
        public UserFullName FullName { get; private set; }
        public Email Email { get; private set; }
        public UserRole Role { get; private set; } 
        public DateTime JoinedAt { get; private set; }
        public bool IsDeleted { get; private set; } = false;

        internal User(UserId id, UserFullName fullName, Email email, UserRole role)
        {
            this.Id = id;
            this.FullName = fullName;
            this.Email = email;
            this.Role = role;
            this.JoinedAt = DateTime.UtcNow;

            // Raise UserCreatedEvent 
            RaiseDomainEvent(new UserRegisteredEvent(this.Id, this.Email));
        }

        public void MarkAsDeleted()
        {
            if(this.IsDeleted)
            {
                throw new AlreadyUserDeletedException();
            }
                
            this.IsDeleted = true;
        }
    }
}
