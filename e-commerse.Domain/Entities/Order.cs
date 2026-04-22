using e_commerse.Domain.Exceptions.Coupon;
using e_commerse.Domain.Enums.Order;
using e_commerse.Domain.Exceptions.Order;
using e_commerse.Domain.ValueObjects.Coupon;
using e_commerse.Domain.ValueObjects.Order;
using e_commerse.Domain.ValueObjects.Product;
using e_commerse.Domain.ValueObjects.User;
using e_commerse.Domain.ValueObjects;
using e_commerse.Domain.Exceptions.Cart;

namespace e_commerse.Domain.Entities
{
    internal class Order
    {
        public OrderId Id { get; private set; }
        public UserId UserId { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items;
        public Money SubTotal { get; private set; }
        public Money Total { get; private set; }
        public CouponId CouponId { get; private set; }
        public Currency Currency { get; private set; }
        public ShippingAddress ShippingAddress { get; private set; }
        public OrderStatus Status { get; private set; }
        public Money Discount { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private List<OrderItem> _items = new();

        internal Order(OrderId id, UserId userId, ShippingAddress shippingAddress)
        {
            this.Id = id;
            this.UserId = userId;
            Status = OrderStatus.Pending;
            this.ShippingAddress = shippingAddress;
            this.CreatedAt = DateTime.UtcNow;
        }

        internal Order(OrderId id, UserId userId, ShippingAddress shippingAddress, List<OrderItem> items)
        {
            this.Id = id;
            this.UserId = userId;
            this.ShippingAddress = shippingAddress;
            Status = OrderStatus.Pending;
            this.CreatedAt = DateTime.UtcNow;
            AddItems(items);
        }

        public void AddItem(OrderItem newItem)
        {
            //Validate the newItem
            if (newItem is null)
            {
                throw new EmptyOrderItemException();
            }

            var item = _items.FirstOrDefault(i => i.ProductId == newItem.ProductId);

            if (item is not null)
            {
                throw new DuplicateOrderItemException();
            }

            // If the cart is empty, set the currency based on the first item added 
            if (!_items.Any())
            {
                Currency = newItem.Price.Currency;
            }// If the cart already has items, ensure the currency matches
            else if(Currency != newItem.Price.Currency)
            {
                throw new CurrencyMismatchException();
            }

            // Add the new item to the cart
            _items.Add(newItem);

            // Recalculate the order totals
            Recalculate();
        }

        public void AddItems(List<OrderItem> items)
        {
            foreach (var item in items)
                AddItem(item);
        }

        public void ApplyCoupon(Coupon coupon)
        {
           if(coupon is null)
                throw new EmptyCouponException();

           if (!coupon.IsValid())
               throw new CouponNotValidException();

           if (!_items.Any())
               throw new EmptyOrderException();

           // Calculate the discount amount
           var discount = coupon.CalculateDiscount(SubTotal);

           // Set the Discount Property with the Calculated discount
           Discount = new Money(discount, Currency.Value);

           // Set the CouponId property to the applied coupon's Id
           CouponId = coupon.Id;

           Recalculate();
        }

        public void Pay(Coupon? coupon = null)
        {
            if(Status != OrderStatus.Pending)
                throw new InvalidOrderStatusTransitionException();

            if(coupon is not null)
            {
                if (!coupon.IsValid())
                    throw new CouponNotValidException();

                coupon.Use();
            }

            Status = OrderStatus.Paid;
        }

        public void Cancel()
        {
            if(Status != OrderStatus.Pending && Status != OrderStatus.Paid)
            {
                throw new CannotCancelOrderException();
            }

            Status = OrderStatus.Cancelled;
        }

        private void Recalculate()
        {
            // Gets the all Totol Prices
            var sum = _items.Sum(i => i.Total);

            // Sets the prices and the currency based on Order Currency to SubTotal
            SubTotal = new Money(sum, Currency.Value);

            // Sets the Total to SubTotal before applying any discount
            Total = SubTotal;

            // If there is a discount, subtract it from the SubTotal to get the final Total
            if (Discount is not null)
            {
                Total = SubTotal.Subtract(Discount);
            }
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
           
            // Validate the new status transition
            if (Status == OrderStatus.Delivered
                || Status == OrderStatus.Cancelled 
                || Status == OrderStatus.Failed)
            {
                throw new InvalidOrderStatusTransitionException();
            }

            // Ensure the sequence of status transitions is logical 
            if (Status == OrderStatus.Paid && newStatus != OrderStatus.Shipped)
            {
                throw new InvalidOrderStatusTransitionException();
            } 

            if(Status == OrderStatus.Shipped && newStatus != OrderStatus.Delivered)
            {
                throw new InvalidOrderStatusTransitionException();
            }

            // Update the order status
            Status = newStatus;
        }
    }
}
