using e_commerse.Domain.ValueObjects.Category;

namespace e_commerse.Domain.Entities
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
