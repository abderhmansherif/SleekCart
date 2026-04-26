using e_commerse.Domain.Exceptions.Category;

namespace SleekCart.Domain.ValueObjects.Category
{
    public record CategoryName
    {
        public string Value { get; }

        public CategoryName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyCategoryNameException();
            }

            this.Value = value;
        }

        public static implicit operator string(CategoryName value) => value.Value;

        public static implicit operator CategoryName(string value) => new CategoryName(value);
    }
}
