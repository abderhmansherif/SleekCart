using e_commerse.Domain.Exceptions.Coupon;
using e_commerse.Domain.Enums.Order;
using e_commerse.Domain.Exceptions.Order;
using e_commerse.Domain.ValueObjects.Coupon;
using e_commerse.Domain.ValueObjects.Order;
using e_commerse.Domain.ValueObjects.Product;
using e_commerse.Domain.ValueObjects.User;
using System.ComponentModel;

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
        public ShippingAddress ShippingAddress { get; private set; }
        public OrderStatus Status { get; private set; }
        public Money Discount { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private List<OrderItem> _items = new();

        internal Order(OrderId id, UserId userId, ShippingAddress shippingAddress)
        {
            this.Id = id;
            this.UserId = userId;
            this.Status = OrderStatus.Pending;
            this.ShippingAddress = shippingAddress;
            this.CreatedAt = DateTime.UtcNow;
        }

        internal Order(OrderId id, UserId userId, ShippingAddress shippingAddress, List<OrderItem> items)
        {
            this.Id = id;
            this.UserId = userId;
            this.Status = OrderStatus.Pending;
            this.ShippingAddress = shippingAddress;
            this.CreatedAt = DateTime.UtcNow;
            AddItems(items);
        }

        public void AddItem(OrderItem newItem)
        {
            if(newItem is null)
            {
                throw new EmptyOrderItemException();
            }

            var item = _items.FirstOrDefault(i => i.ProductId == newItem.ProductId);

            if (item is not null)
            {
                throw new DuplicateOrderItemException();
            }

            if(_items.Any(i => i.Price.Currency != newItem.Price.Currency))
            {
                throw new InvalidOperationException("All items in an order must have the same currency.");
            }

            _items.Add(newItem);
        }

        public void AddItems(List<OrderItem> items)
        {
            foreach (var item in items)
                AddItem(item);
        }

        public void ApplyCoupon(Coupon coupon)
        {
           
        }

        public void CalculateTotal()
        {
            
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
           
        }
    }
}
