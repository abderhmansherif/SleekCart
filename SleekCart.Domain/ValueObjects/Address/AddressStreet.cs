using e_commerse.Domain.Exceptions.Address;

namespace SleekCart.Domain.ValueObjects.Address
{
    public record AddressStreet
    {
        public string Value { get; }
        public AddressStreet(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyAddressStreetException();
            }
            Value = value;
        }

        public static implicit operator string(AddressStreet addressStreet) => addressStreet.Value;
        public static implicit operator AddressStreet(string value) => new AddressStreet(value);
    }
}
