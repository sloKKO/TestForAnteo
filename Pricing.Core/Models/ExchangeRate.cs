using System;


namespace Pricing.Core.Models
{
    public class ExchangeRate
    {
        public ExchangeRate(Currency from, Currency to, decimal rate)
        {
            From = from;
            To = to;
            Rate = rate;
        }

        public Currency From { get; private set; }
        public Currency To { get; private set; }
        public decimal Rate { get; private set; }

        public Price Convert(Price price)
        {
            // To perform a currency conversion, divide the local price by the conversion rate
            // and return a new price in the selling currency.
            // Prices should be rounded to 2dp.
            price.Amount = price.Amount / Rate;
            price.Currency = To;
            price.Amount = Math.Round(price.Amount, 2);
            return price;

            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (obj is ExchangeRate)
            {
                ExchangeRate other = (ExchangeRate)obj;
                return From == other.From && To == other.To && Rate == other.Rate;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + From.GetHashCode();
                hash = hash * 23 + To.GetHashCode();
                hash = hash * 23 + Rate.GetHashCode();
                return hash;
            }
        }
    }
}
