using e_commerse.Domain.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_commerse.Domain.Exceptions.Order
{
    public class EmptyCouponException: OrderException
    {
        public EmptyCouponException(): base("Coupon cannot be empty.")
        {
            
        }
    }
}
