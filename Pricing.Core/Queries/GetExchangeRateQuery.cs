using Pricing.Core.Models;

namespace Pricing.Core.Queries
{
    public class GetExchangeRateQuery : IQuery<ExchangeRate>
    {
        /// <summary>
        /// The currency to convert from
        /// </summary>
        public Currency From { get; set; }

        /// <summary>
        /// The currency to convert to
        /// </summary>
        public Currency To { get; set; }
    }
}
