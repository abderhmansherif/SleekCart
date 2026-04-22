using e_commerse.Domain.Exceptions.Cart;
using e_commerse.Domain.ValueObjects.Cart;
using e_commerse.Domain.ValueObjects.Product;
using e_commerse.Domain.ValueObjects.User;

namespace e_commerse.Domain.Entities
{
    internal class Cart
    {
        public CartId Id { get; private set; }
        public UserId UserId { get; private set; }
        public Currency? Currency { get; private set; }
        public Money? Total { get; private set; }
        public IReadOnlyCollection<CartItem> Items => _items;

        private List<CartItem> _items = new();

        public Cart(CartId id, UserId userId)
        {
            Id = id;
            UserId = userId;    
        }

        public void AddItem(CartItem cartItem)
        {
            // Validate the cart item
            if (cartItem is null)
            {
                throw new EmptyCartItemException();
            }

            var item = _items.FirstOrDefault(i => i.ProductId == cartItem.ProductId);

            // If the item already exists in the cart, increase the quantity
            if (item is not null)
            {
                item.IncreaseQuantity(cartItem.Quantity);

                RecalculateTotal();
                return;
            }

            // If the cart is empty, set the currency based on the first item added
            if (!_items.Any()) 
            {
                Currency = cartItem.Price.Currency;
            } // If the cart already has items, ensure the currency matches
            else if(Currency != cartItem.Price.Currency)
            {
                throw new CurrencyMismatchException();
            }

            // Add the new item to the cart
            _items.Add(cartItem);

            //Recalculate the total price of the cart
            RecalculateTotal();
        }

        private void RecalculateTotal()
        {
            // If there are no items in the cart, set the total to null
            if (!_items.Any())
            {
                Total = null;
                return;
            }

            if (Currency is null)
                return;

            // Calculate the total price by summing the total price of each item in the cart
            var sum = _items.Sum(i => i.Total);

            // Set the total price of the cart
            Total = new Money(sum, Currency.Value);
        }

        public void RemoveItem(CartItem cartItem) 
        {
            // Validate the cart item
            if (cartItem is null)
            {
                throw new EmptyCartItemException();
            }

            // If the cart is empty, throw an exception
            if (!_items.Any())
            {
                throw new EmptyCartException();
            }

            var item = _items.FirstOrDefault(i => i.ProductId == cartItem.ProductId);

            if(item is null)
            {
                throw new EmptyCartItemException();
            }

            //Remove Item
            _items.Remove(item);
            //Recalculate the total cart
            RecalculateTotal();
        }

        public void ClearCart()
        {
            _items.Clear();
            Currency = null;
            Total = null;
        }
    }
}
