using e_commerse.Domain.Exceptions.Address;

namespace e_commerse.Domain.ValueObjects.Address
{
    public record AddressBuilding
    {
        public string Value { get; }
        public AddressBuilding(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyAddressBuildingException();
            }
            Value = value;
        }

        public static implicit operator string(AddressBuilding addressBuilding) => addressBuilding.Value;
        public static implicit operator AddressBuilding(string value) => new AddressBuilding(value);
    }
}
