using e_commerse.Domain.Exceptions.Product;

namespace SleekCart.Domain.ValueObjects.Product
{
    public record ProductName
    {
        public string Value { get; }

        public ProductName(string value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new EmptyProductNameException();
            }

            if(value.Length > 150)
            {
                throw new ProductNameTooLongException();
            }

            Value = value;
        }

        public static implicit operator string(ProductName productName) => productName.Value;

        public static implicit operator ProductName(string value) => new ProductName(value);
    }
}
