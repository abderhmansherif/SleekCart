using SleekCart.Domain.ValueObjects.Address;
using SleekCart.Domain.ValueObjects.User;

namespace SleekCart.Domain.Entities
{
    public class Address
    {
        public AddressId Id { get; private set; }
        public UserId UserId { get; private set; }
        public AddressCity City { get; private set; }
        public AddressStreet Street { get; private set; }
        public AddressBuilding Building { get; private set; }
        public AddressNote Note { get; private set; }

        public Address(AddressId id, UserId userId, AddressCity city, 
            AddressStreet street, AddressBuilding building, AddressNote note)
        {
            this.Id = id;
            this.UserId = userId;
            this.Street = street;
            this.City = city;
            this.Building = building;
            this.Note = note;
        }

    }
}
