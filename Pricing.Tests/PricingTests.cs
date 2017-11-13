using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pricing.Core.Models;
using Pricing.Core.Queries;
using Pricing.Core.QueryHandlers;
using Pricing.Core.Services;

namespace Pricing.Tests
{
    [TestClass]
    public class PricingTests
    {
        private IQueryHandler<GetExchangeRateQuery, ExchangeRate> GetExchangeRateQueryHandler;
        private IQueryHandler<GetMarkupRateQuery, MarkupRate> GetMarkupRateQueryHandler;
        private TourDeparturePricingService TourDeparturePricingService;

        [TestInitialize]
        public void TestInitialize()
        {
            GetExchangeRateQueryHandler = new GetExchangeRateQueryHandler(ExchangeRateTestData.All);
            GetMarkupRateQueryHandler = new GetMarkupRateQueryHandler(MarkupRateTestData.All);
            TourDeparturePricingService = new TourDeparturePricingService(
                GetExchangeRateQueryHandler, GetMarkupRateQueryHandler);
        }

        [TestMethod]
        public void ConvertPriceFromEURToUSD()
        {
            var priceUSDExpected = new Price(278.9M, CurrencyTestData.USD);
            var priceUSDActual = ExchangeRateTestData.EURToUSD.Convert(new Price(250M, CurrencyTestData.EUR));

            Assert.AreEqual(priceUSDExpected, priceUSDActual);
        }

        [TestMethod]
        public void ConvertPriceFromUSDToGBP()
        {
            var priceGBPExpected = new Price(161.12M, CurrencyTestData.GBP);
            var priceGBPActual = ExchangeRateTestData.USDToGBP.Convert(new Price(250M, CurrencyTestData.USD));

            Assert.AreEqual(priceGBPExpected, priceGBPActual);
        }

        [TestMethod]
        public void ConvertPriceFromGBPToEUR()
        {
            var priceEURExpected = new Price(347.71M, CurrencyTestData.EUR);
            var priceEURActual = ExchangeRateTestData.GBPToEUR.Convert(new Price(250M, CurrencyTestData.GBP));

            Assert.AreEqual(priceEURExpected, priceEURActual);
        }

        [TestMethod]
        public void GetExchangeRateEURToUSD()
        {
            var expected = ExchangeRateTestData.EURToUSD.Rate;
            var actual = GetExchangeRateQueryHandler.Handle(new GetExchangeRateQuery
            {
                From = CurrencyTestData.EUR,
                To = CurrencyTestData.USD
            }).Rate;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetExchangeRateUSDToGBP()
        {
            var expected = ExchangeRateTestData.USDToGBP.Rate;
            var actual = GetExchangeRateQueryHandler.Handle(
                new GetExchangeRateQuery { From = CurrencyTestData.USD, To = CurrencyTestData.GBP }).Rate;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetExchangeRateGBPToEUR()
        {
            var expected = ExchangeRateTestData.GBPToEUR.Rate;
            var actual = GetExchangeRateQueryHandler.Handle(
                new GetExchangeRateQuery { From = CurrencyTestData.GBP, To = CurrencyTestData.EUR }).Rate;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMarkupRateForCurrencyUSDAndDepartureDate20150330ShouldReturnRateOf20Percent()
        {
            var rate = GetMarkupRateQueryHandler.Handle(
                new GetMarkupRateQuery
                {
                    Currency = CurrencyTestData.USD,
                    DepartureDate = new DateTime(2015, 3, 30)
                });

            Assert.IsNotNull(rate);
            Assert.AreEqual(CurrencyTestData.USD, rate.Currency);
            Assert.AreEqual(20M, rate.PercentageRate);
        }

        [TestMethod]
        public void GetMarkupRateForCurrencyGBPAndDepartureDate20150725ShouldReturnRateOf18Percent()
        {
            var rate = GetMarkupRateQueryHandler.Handle(
                new GetMarkupRateQuery
                {
                    Currency = CurrencyTestData.GBP,
                    DepartureDate = new DateTime(2015, 7, 25)
                });

            Assert.IsNotNull(rate);
            Assert.AreEqual(CurrencyTestData.GBP, rate.Currency);
            Assert.AreEqual(18M, rate.PercentageRate);
        }

        [TestMethod]
        public void GetMarkupRateForCurrencyEURAndDepartureDate20151203ShouldReturnRateOf35Percent()
        {
            var rate = GetMarkupRateQueryHandler.Handle(
                new GetMarkupRateQuery
                {
                    Currency = CurrencyTestData.EUR,
                    DepartureDate = new DateTime(2015, 12, 3)
                });

            Assert.IsNotNull(rate);
            Assert.AreEqual(CurrencyTestData.EUR, rate.Currency);
            Assert.AreEqual(35M, rate.PercentageRate);
        }

        [TestMethod]
        public void MarkupRateMarkupShouldReturnMarkedUpPriceInSameCurrency()
        {
            var currency = CurrencyTestData.USD;
            var price = new Price(250M, currency);
            var markupRate = new MarkupRate(
                new DateTime(2017, 1, 1), new DateTime(2017, 12, 31), 
                currency, 25M);

            var markedUpPrice = markupRate.Markup(price);

            Assert.AreEqual(currency, markedUpPrice.Currency);
            Assert.AreEqual(312.5M, markedUpPrice.Amount);
        }

        [TestMethod]
        public void TourDeparturePricingServiceShouldCalculatePriceInLocalCurrencyWhenLocalAndSellingCurrenciesAreSame()
        {
            var tourDeparture = TourDepartureTestData.TourDepartures.First();

            var result = TourDeparturePricingService.CalculatePrice(tourDeparture, tourDeparture.LocalCost.Currency);

            Assert.AreEqual(tourDeparture, result.TourDeparture);
            Assert.AreEqual(575M, result.SellingPrice.Amount);
            Assert.AreEqual(CurrencyTestData.GBP, result.SellingPrice.Currency);
        }

        [TestMethod]
        public void TourDeparturePricingServiceShouldCalculatePriceInSellingCurrencyWhenLocalAndSellingCurrenciesAreNotSame()
        {
            var tourDeparture = TourDepartureTestData.TourDepartures.Skip(1).First();

            var result = TourDeparturePricingService.CalculatePrice(tourDeparture, CurrencyTestData.USD);

            Assert.AreEqual(tourDeparture, result.TourDeparture);
            Assert.AreEqual(969.75M, result.SellingPrice.Amount);
            Assert.AreEqual(CurrencyTestData.USD, result.SellingPrice.Currency);
        }
    }
}
