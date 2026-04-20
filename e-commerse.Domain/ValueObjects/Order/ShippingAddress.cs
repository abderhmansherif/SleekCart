using e_commerse.Domain.Exceptions.Order;

namespace e_commerse.Domain.ValueObjects.Order
{
    public record ShippingAddress
    {
        public string Country { get;}
        public string Street { get; }
        public string City { get; }
        public string Note { get; }

        public ShippingAddress(string country, string street, string city, string note)
        {
            if(string.IsNullOrWhiteSpace(country))
                throw new InvalidShippingAddressArgumentException("Country is required");

            if(string.IsNullOrWhiteSpace(street))
                throw new InvalidShippingAddressArgumentException("Street is required");

            if(string.IsNullOrWhiteSpace(city))
                throw new InvalidShippingAddressArgumentException("City is required");

            if(string.IsNullOrWhiteSpace(note))
                throw new InvalidShippingAddressArgumentException("Note is required");

            Country = country;
            Street = street;
            City = city;
            Note = note;
        }
    }
}
