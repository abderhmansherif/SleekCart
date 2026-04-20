using e_commerse.Domain.Exceptions.Cart;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_commerse.Domain.ValueObjects
{
    public record Currency
    {
        public string Value { get; }

        public Currency(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new EmptyCurrencyException();
            }

            this.Value = value;
        }

        public static implicit operator string(Currency currency) => currency.Value;
        public static implicit operator Currency(string value) => new Currency(value);
    }
}
