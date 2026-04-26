using e_commerse.Domain.Exceptions.Cart;

namespace e_commerse.Domain.ValueObjects.Cart
{
    public record CartId
    {
        public Guid Value { get; }

        public CartId(Guid value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new EmptyCartIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(CartId cartId) => cartId.Value;

        public static implicit operator CartId(Guid value) => new CartId(value);
    }
}
