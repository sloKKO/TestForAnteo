using Pricing.Core.Models;
using System;

namespace Pricing.Core.Queries
{
    public class GetMarkupRateQuery : IQuery<MarkupRate>
    {
        /// <summary>
        /// The date of departure
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// The currency 
        /// </summary>
        public Currency Currency { get; set; }
    }
}
