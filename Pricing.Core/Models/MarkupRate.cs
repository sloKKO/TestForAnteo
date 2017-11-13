using System;

namespace Pricing.Core.Models
{
    public class MarkupRate
    {
        public MarkupRate(DateTime from, DateTime to, Currency currency, decimal percentageRate)
        {
            From = from;
            To = to;
            Currency = currency;
            PercentageRate = percentageRate;
        }

        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public Currency Currency { get; private set; }
        public decimal PercentageRate { get; private set; }

        public Price Markup(Price price)
        {
            // To mark up a price, return a value equal to the current price
            // plus the proportion of the value indicated by PercentageRate

            // The price returned should be rounded to 2dp

            throw new NotImplementedException();
        }
    }
}
