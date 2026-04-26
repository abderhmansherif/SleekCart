
using e_commerse.Domain.Exceptions.Category;

namespace SleekCart.Domain.ValueObjects.Category
{
    public record CategoryId
    {
        public Guid Value { get; }

        public CategoryId(Guid value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new EmptyCategoryIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(CategoryId CategoryId) => CategoryId.Value;

        public static implicit operator CategoryId(Guid value) => new CategoryId(value);
    }
}
