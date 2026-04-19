using e_commerse.Domain.Exceptions.Product;

namespace e_commerse.Domain.ValueObjects.Product
{
    public record ProductId
    {
        public Guid Value { get; }

        public ProductId(Guid value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new EmptyProductIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(ProductId productId) => productId.Value;

        public static implicit operator ProductId(Guid value) => new ProductId(value);
    }
}
