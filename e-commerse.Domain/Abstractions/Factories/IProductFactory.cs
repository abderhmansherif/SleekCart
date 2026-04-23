using e_commerse.Domain.Entities;

namespace e_commerse.Domain.Abstractions.Factories
{
    public interface IProductFactory
    {
        public Product CreateDefault();
        public Product CreateWithCategory();
    }
}
