using e_commerse.Domain.Abstractions.Domain;
using e_commerse.Domain.Enums.User;
using e_commerse.Domain.Events.User;
using e_commerse.Domain.Exceptions.User;
using e_commerse.Domain.ValueObjects.Address;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Entities
{
    public class User: AggregateRoot
    {
        public UserId Id { get; private set; }
        public UserFullName FullName { get; private set; }
        public Email Email { get; private set; }
        public UserRole Role { get; private set; } 
        public DateTime JoinedAt { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public IReadOnlyList<Address> Addresses => _addresses.AsReadOnly();

        private List<Address> _addresses = new List<Address>();

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

        public void UpdateFullName(UserFullName newFullName)
        {
            if(this.IsDeleted)
            {
                throw new AlreadyUserDeletedException();
            }
            this.FullName = newFullName;
        }

        public void AddAddress(Address newAddress)
        {
            if(this.IsDeleted)
            {
                throw new AlreadyUserDeletedException();
            }

            if(_addresses.Any(a => a.Building == newAddress.Building))
            {
                throw new AddressAlreadyExistsException();
            }

            _addresses.Add(newAddress);
        }

        public void RemoveAddress(AddressId addressId)
        {
            if(this.IsDeleted)
            {
                throw new AlreadyUserDeletedException();
            }

            var address = _addresses.FirstOrDefault(a => a.Id == addressId);
            if(address == null)
            {
                throw new AddressNotFoundException();
            }
            _addresses.Remove(address);
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
