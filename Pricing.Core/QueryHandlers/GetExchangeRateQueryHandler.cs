using System.Collections.Generic;
using Pricing.Core.Models;
using Pricing.Core.Queries;

namespace Pricing.Core.QueryHandlers
{
    public class GetExchangeRateQueryHandler : IQueryHandler<GetExchangeRateQuery, ExchangeRate>
    {
        private readonly IEnumerable<ExchangeRate> _exchangeRates;

        public GetExchangeRateQueryHandler(IEnumerable<ExchangeRate> exchangeRates)
        {
            _exchangeRates = exchangeRates;
        }

        public ExchangeRate Handle(GetExchangeRateQuery query)
        {
           
            Currency USD = new Currency("USD", "$", "US dollar");
            Currency EUR = new Currency("EUR", "€", "Euro");
            Currency GBP = new Currency("GBP", "£", "Pound sterling");

            ExchangeRate EURToUSD = new ExchangeRate(EUR, USD, 0.89638M);
            if (query.From.Code == "EUR")
                if (query.To.Code == "USD")
                    return EURToUSD;

            ExchangeRate GBPToEUR = new ExchangeRate(GBP, EUR, 0.71900M);
            if (query.From.Code == "GBP")
                if (query.To.Code == "EUR")
                    return GBPToEUR;

            ExchangeRate USDToGBP = new ExchangeRate(USD, GBP, 1.55160M);
            if (query.From.Code == "USD")
                if (query.To.Code == "GBP")
                    return USDToGBP;

            throw new System.NotImplementedException();

        }
    }
}
