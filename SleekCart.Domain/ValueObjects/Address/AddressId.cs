using e_commerse.Domain.Exceptions.Address;

namespace e_commerse.Domain.ValueObjects.Address
{
    public record AddressId
    {
        public Guid Value { get; }
        public AddressId(Guid value)
        {
            if(value == Guid.Empty)
            {
                throw new EmptyAddressIdException();
            }
            Value = value;
        }

        public static implicit operator Guid(AddressId addressId) => addressId.Value;
        public static implicit operator AddressId(Guid value) => new AddressId(value);
    }
}
