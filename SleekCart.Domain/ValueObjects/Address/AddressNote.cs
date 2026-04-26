using e_commerse.Domain.Exceptions.Address;

namespace e_commerse.Domain.ValueObjects.Address
{
    public record AddressNote
    {
        public string Value { get; }
        public AddressNote(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyAddressNoteException();
            }
            Value = value;
        }

        public static implicit operator string(AddressNote addressNote) => addressNote.Value;
        public static implicit operator AddressNote(string value) => new AddressNote(value);
    }
}
