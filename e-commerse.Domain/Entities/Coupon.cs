using e_commerse.Domain.Enum.Coupon;
using e_commerse.Domain.Exceptions.Coupon;
using e_commerse.Domain.ValueObjects.Coupon;

namespace e_commerse.Domain.Entities
{
    internal class Coupon
    {
        public CouponId Id { get; private set; }
        public CouponCode Code { get; private set; }
        public CouponType Type { get; private set; }
        public CouponDiscount DiscountValue { get; private set; }
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
            if (DateTime.UtcNow > ExpiryDate)
                return false;

            if (Type == CouponType.SingleUse)
            {
                return !IsUsed;
            }
            
            if(Type == CouponType.MultiUse)
            {
                return UsedCount < UsageLimit;
            }

            return false;
        }

        public decimal CalculateDiscount(decimal amount)
        {
            if(amount < 0)
            {
                return 0;
            }

            if(IsPercentage)
            {
                return (amount * DiscountValue) / 100;
            }

            return DiscountValue;
        }

        public void Use()
        {
           if(!IsValid())
           {
                throw new CouponNotValidException();
           }

           if(Type == CouponType.SingleUse)
               IsUsed = true;
           
           else if(Type == CouponType.MultiUse)
               UsedCount++;
           
        }

    }
}
