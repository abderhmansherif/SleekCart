using e_commerse.Domain.Exceptions.ProductImage;

namespace SleekCart.Domain.ValueObjects.ProductImage
{
    public record ImageFilePath
    {
        public string Value { get; }

        public ImageFilePath(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new EmptyImageFilePathException();
            }

            this.Value = value;
        }

        public static implicit operator string(ImageFilePath value) => value.Value;

        public static implicit operator ImageFilePath(string value) => new ImageFilePath(value);
    }
}
