using e_commerse.Domain.Exceptions.Product;

namespace e_commerse.Domain.ValueObjects.Product
{
    public record ProductDescription
    {
        public string Value { get; }

        public ProductDescription(string value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new EmptyProductDescriptionException();
            }

            if (value.Length > 600)
            {
                throw new ProductDescriptionTooLongException();
            }

            Value = value;
        }

        public static implicit operator string(ProductDescription productDescription) => productDescription.Value;

        public static implicit operator ProductDescription(string value) => new ProductDescription(value);
    }
}
