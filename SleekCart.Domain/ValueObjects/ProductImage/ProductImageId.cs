using e_commerse.Domain.Exceptions.ProductImage;

namespace SleekCart.Domain.ValueObjects.ProductImage
{
    public record ProductImageId
    {
        public Guid Value { get; }

        public ProductImageId(Guid value)
        {
            if(string.IsNullOrEmpty(value.ToString()))
            {
                throw new EmptyProductImageIdException();
            }

            this.Value = value;
        }

        public static implicit operator Guid(ProductImageId value) => value.Value;

        public static implicit operator ProductImageId(Guid value) => new ProductImageId(value);
    }
}
