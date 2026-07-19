using e_commerse.Domain.Exceptions.Cart;
using e_commerse.Domain.Exceptions.Coupon;
using e_commerse.Domain.ValueObjects.Coupon;
using SleekCart.Domain.Enums.Coupon;
using SleekCart.Domain.ValueObjects.Coupon;
using SleekCart.Domain.ValueObjects.Product;

namespace SleekCart.Domain.Entities
{
    public class Coupon
    {
        public CouponId Id { get; private set; }
        public CouponCode Code { get; private set; }
        public CouponType Type { get; private set; }
        public Discount Discount { get; private set; }
        public bool IsUsed { get; private set; }
        public UsageLimit? UsageLimit { get; private set; }
        public UsedCount? UsedCount { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public DateTime CreatedAt { get; private set; }

        internal Coupon(CouponId id, CouponCode code, DateTime expiryDate, Discount discount)
        {
            this.Id = id;
            this.Code = code;
            this.Type = CouponType.SingleUse;
            this.ExpiryDate = expiryDate;
            this.IsUsed = false;
            this.Discount = discount;
            this.UsageLimit = null;
            this.UsedCount = null;
            this.CreatedAt = DateTime.UtcNow;
        }
    
        internal Coupon(CouponId id, CouponCode code, UsageLimit usageLimit, 
           DateTime expiryDate, Discount discount)
        {
            this.Id = id;
            this.Code = code;
            this.Discount = discount;
            this.Type = CouponType.MultiUse;
            this.ExpiryDate = expiryDate;
            this.UsageLimit = usageLimit;
            this.UsedCount = new(0);
            this.CreatedAt = DateTime.UtcNow;
        }


        public void UpdateDiscount(Discount discount) => this.Discount = discount;
        public void UpdateCode(CouponCode code) => this.Code = code;
        public void UpdateExpirationDate(DateTime NewExpiryDate)
        {
            var now = DateTime.UtcNow;

            if(NewExpiryDate < now)
                return;

            this.ExpiryDate = NewExpiryDate;
        }

        public bool IsValid()
        {
            // Check if the coupon has expired
            if (DateTime.UtcNow > ExpiryDate)
                return false;

            // Check usage based on coupon type
            if (Type == CouponType.SingleUse)
            {
                return !IsUsed;
            }

            // For multi-use coupons, check if the usage limit has not been exceeded
            if (Type == CouponType.MultiUse)
            {
                return UsedCount! < UsageLimit!;
            }

            return false;
        }

        public decimal CalculateDiscount(Money amount)
        {
            // Validate the input amount
            if (amount is null)
            {
                return 0;
            }

            if(!IsValid())
            {
                throw new CouponNotValidException();
            }

            // Calculate the discount based on whether it's a percentage or a fixed amount
            return amount.Amount * Discount / 100;
        }

        public void Use()
        {
            // Validate the coupon before using it
           if (!IsValid())
           {
                throw new CouponNotValidException();
           }

            // Mark the coupon as used based on its type
            if (Type == CouponType.SingleUse)
               IsUsed = true;

            // For multi-use coupons, increment the used count
            else if (Type == CouponType.MultiUse)
               UsedCount!++;
        }

    }
}
