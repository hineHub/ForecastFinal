using InvestmentForecast.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecast.E2E.Tests.TestBuilder
{
    public class ForecastRequestViewModelBuilder
    {
        private int _years;
        private string _riskLevel;
        private decimal _lumpSum;
        private decimal _monthlyInvestment;

        private const string Low = "low";

        public ForecastRequestViewModelBuilder WithValidDefaults()
        {
            _years = 5;
            _riskLevel = Low;
            _lumpSum = 10000;
            _monthlyInvestment = 1000;
            return this;
        }

        public ForecastRequestViewModelBuilder WithInvestmentTerm(int years)
        {
            _years = years;
            return this;
        }

        public ForecastRequestViewModelBuilder WithLumpSum(decimal lumpSum)
        {
            _lumpSum = lumpSum;
            return this;
        }

        public ForecastRequestViewModelBuilder WithMonthlyInvestment(decimal monthlyInvestment)
        {
            _monthlyInvestment = monthlyInvestment;
            return this;
        }

        public ForecastRequestViewModelBuilder WithRiskLevel(string riskLevel)
        {
            _riskLevel = riskLevel;
            return this;
        }

        public CalculateRequest Build()
        {
            return new CalculateRequest()
            {
                InvestmentTermInYears = _years,
                LumpSumInvestment = _lumpSum,
                MonthlyInvestment = _monthlyInvestment,
                RiskLevel = _riskLevel
            };
        }
    }
}
