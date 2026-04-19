using e_commerse.Domain.Exceptions.ProductImage;

namespace e_commerse.Domain.ValueObjects.ProductImage
{
    public record ImageFileName
    {
        public string Value { get; }

        public ImageFileName(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new EmptyImageFileNameException();
            }

            this.Value = value;
        }

        public static implicit operator string(ImageFileName value) => value.Value;

        public static implicit operator ImageFileName(string value) => new ImageFileName(value);
    }
}
