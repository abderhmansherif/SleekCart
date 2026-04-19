using e_commerse.Domain.Exceptions.Product;

namespace e_commerse.Domain.ValueObjects.Product
{
    public record ProductPrice
    {
        public decimal Value { get; }

        public ProductPrice(decimal value)
        {
            if(value <= 0)
            {
                throw new InvalidProductPriceException();
            }

            Value = value;
        }

        public static implicit operator decimal(ProductPrice price) => price.Value;

        public static implicit operator ProductPrice(decimal value) => new(value);
    }
}
