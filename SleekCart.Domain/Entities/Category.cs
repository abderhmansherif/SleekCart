using SleekCart.Domain.ValueObjects.Category;

namespace SleekCart.Domain.Entities
{
    public class Category
    {
        public CategoryId Id { get; private set; }
        public CategoryName Name { get; private set; }

        public Category(CategoryId id, CategoryName name)
        {
            Id = id;
            Name = name;
        }
    }
}
