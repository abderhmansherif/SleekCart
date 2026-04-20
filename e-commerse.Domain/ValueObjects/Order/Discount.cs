using e_commerse.Domain.Exceptions.Category;
using e_commerse.Domain.Exceptions.Order;

namespace e_commerse.Domain.ValueObjects.Order
{
    public record Discount
    {
        public decimal Value { get; }

        public Discount(decimal value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new EmptyOrderDiscountException();
            }

            Value = value;
        }

        public static implicit operator decimal(Discount discount) => discount.Value;

        public static implicit operator Discount(decimal value) => new Discount(value);
    }
}
