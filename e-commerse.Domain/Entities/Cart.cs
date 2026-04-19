using e_commerse.Domain.Exceptions.Cart;
using e_commerse.Domain.ValueObjects.Cart;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Entities
{
    internal class Cart
    {
        public CartId Id { get; private set; }
        public UserId UserId { get; private set; }
        public IReadOnlyCollection<CartItem> Items => _items;

        private List<CartItem> _items = new();

        public Cart(CartId id, UserId userId)
        {
            Id = id;
            UserId = userId;    
        }

        public void AddItem(CartItem cartItem)
        {
            if(cartItem is null)
            {
                throw new EmptyCartItemException();
            }

            var item = _items.FirstOrDefault(i => i.ProductId == cartItem.ProductId);

            if(item is not null)
            {
                item.Quantity += cartItem.Quantity;
            }

            _items.Add(cartItem);
        }

        public void RemoveItem(CartItem cartItem) 
        {
            if(cartItem is null)
            {
                throw new EmptyCartItemException();
            }

            if(_items.Count == 0)
            {
                throw new EmptyCartException();
            }

            var item = _items.FirstOrDefault(i => i.ProductId == cartItem.ProductId);

            if(item is null)
            {
                throw new EmptyCartItemException();
            }

            _items.Remove(cartItem);
        }

        public void ClearCart() => _items.Clear();  
    }
}
