using e_commerse.Domain.Exceptions.Address;

namespace e_commerse.Domain.ValueObjects.Address
{
    public record AddressCity
    {
        public string Value { get; }
        public AddressCity(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyAddressCityException();
            }
            Value = value;
        }

        public static implicit operator string(AddressCity addressCity) => addressCity.Value;
        public static implicit operator AddressCity(string value) => new AddressCity(value);
    }
}
