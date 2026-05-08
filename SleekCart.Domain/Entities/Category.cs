using SleekCart.Domain.Exceptions.Cart;
using SleekCart.Domain.ValueObjects.Category;

namespace SleekCart.Domain.Entities
{
    public class Category
    {
        public CategoryId Id { get; private set; }
        public CategoryName Name { get; private set; }

        internal Category(CategoryId id, CategoryName name)
        {
            Id = id;
            Name = name;
        }

        public void UpdateName(CategoryName categoryName)
        {
            if(this.Name == categoryName)
            {
                throw new AlreadyUpdatedCategoryException();
            }

            this.Name = categoryName;
        }
    }
}
