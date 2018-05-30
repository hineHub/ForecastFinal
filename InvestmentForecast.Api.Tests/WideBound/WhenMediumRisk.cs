using InvestmentForecast.Api.Models.Request;
using InvestmentForecast.E2E.Tests.TestBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentForecast.E2E.Tests.WideBound
{
    [TestClass]
    public class WhenMediumRisk
    {
        private ApiHelper _apiHelper;

        [TestInitialize]
        public void TestSetup()
        {
            _apiHelper = new ApiHelper();
        }


        [TestCategory("WideBound"), TestCategory("MediumRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs50000_ThenYear0WideBoundValuesAreCorrect()
        {
            //Arrange
            decimal lumpSum = 50000.00m;
            decimal expectedLowerBound = 50000.00m;
            decimal expectedUpperBound = 50000.00m;

            CalculateRequest request = new ForecastRequestViewModelBuilder()
                .WithValidDefaults()
                .WithRiskLevel("medium")
                .WithLumpSum(lumpSum)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
            Assert.AreEqual(expectedLowerBound, actual.WideLowerValue.ElementAt(0));
            Assert.AreEqual(expectedUpperBound, actual.WideUpperValue.ElementAt(0));
        }
        
        [TestCategory("WideBoun"), TestCategory("MediumRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs10000_ThenYear100TotalInvestedIsCorrect()
        {
            //Arrange
            decimal expectedTotalInvestment = 1210000m;

            CalculateRequest request = new ForecastRequestViewModelBuilder()
                .WithValidDefaults()
                .WithRiskLevel("medium")
                .WithInvestmentTerm(100)
                .Build();

            //Act
            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);

            Assert.AreEqual(expectedTotalInvestment, actual.TotalValue.ElementAt(100));

        }
    }
}
