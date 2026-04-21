using e_commerse.Domain.Enums.Coupon;
using e_commerse.Domain.Exceptions.Cart;
using e_commerse.Domain.Exceptions.Coupon;
using e_commerse.Domain.ValueObjects.Coupon;
using e_commerse.Domain.ValueObjects.Product;

namespace e_commerse.Domain.Entities
{
    internal class Coupon
    {
        public CouponId Id { get; private set; }
        public CouponCode Code { get; private set; }
        public CouponType Type { get; private set; }
        public Money DiscountValue { get; private set; }
        public bool IsUsed { get; private set; } = false;
        public bool IsPercentage { get; private set; } 
        public UsageLimit UsageLimit { get; private set; }
        public UsedCount UsedCount { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public DateTime CreatedAt { get; private set; }

        internal Coupon(CouponId id, CouponCode code, bool isPercentage, DateTime expiryDate)
        {
            this.Id = id;
            this.Code = code;
            this.IsPercentage = isPercentage;
            this.Type = CouponType.SingleUse;
            this.ExpiryDate = expiryDate;
            this.CreatedAt = DateTime.UtcNow;
        }

        internal Coupon(CouponId id, CouponCode code, bool isPercentage, UsageLimit usageLimit, 
            UsedCount usedCount, DateTime expiryDate)
        {
            this.Id = id;
            this.Code = code;
            this.IsPercentage = isPercentage;
            this.Type = CouponType.MultiUse;
            this.ExpiryDate = expiryDate;
            this.UsageLimit = usageLimit;
            this.UsedCount = usedCount;
            this.CreatedAt = DateTime.UtcNow;
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
                return UsedCount < UsageLimit;
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

            // Ensure the discount value and the amount are in the same currency
            if (DiscountValue.Currency != amount.Currency)
            {
                throw new CurrencyMismatchException();
            }

            // Calculate the discount based on whether it's a percentage or a fixed amount
            if (IsPercentage)
            {
                return (amount.Amount * DiscountValue.Amount) / 100;
            }

            return DiscountValue.Amount;
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
               UsedCount++;
        }

    }
}
