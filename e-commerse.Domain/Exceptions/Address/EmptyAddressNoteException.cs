using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Address
{
    public class EmptyAddressNoteException : AddressException
    {
        public EmptyAddressNoteException() : base("Address note cannot be empty.")
        {
        }
    }
}
