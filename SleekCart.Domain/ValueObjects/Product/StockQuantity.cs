using e_commerse.Domain.Exceptions.Product;

namespace SleekCart.Domain.ValueObjects.Product
{
    public record StockQuantity
    {
        public int Value { get; private set; }
        public StockQuantity(int value)
        {
            if (value < 0)
                throw new StockQuantityNegativeException();

            Value = value;
        }

        public static implicit operator int(StockQuantity stockQuantity) => stockQuantity.Value;

        public static implicit operator StockQuantity(int value) => new StockQuantity(value);
    }
}
