using Pricing.Core.Models;
using Pricing.Core.Queries;
using System.Collections.Generic;

namespace Pricing.Core.QueryHandlers
{
    public class GetMarkupRateQueryHandler : IQueryHandler<GetMarkupRateQuery, MarkupRate>
    {
        private readonly IEnumerable<MarkupRate> _markupRates;

        public GetMarkupRateQueryHandler(IEnumerable<MarkupRate> markupRates)
        {
            _markupRates = markupRates;
        }

        public MarkupRate Handle(GetMarkupRateQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}