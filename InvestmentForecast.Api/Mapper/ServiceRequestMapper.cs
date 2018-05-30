using InvestmentForecast.Api.Models.Request;
using InvestmentForecaster.Service;

namespace InvestmentForecast.Api.Mapper
{
    public class ServiceRequestMapper : IServiceRequestMapper
    {
        public ForecastRequestDto MapCalculation(CalculateRequest model)
        {
            return new ForecastRequestDto()
            {
                InvestmentTermInYears = model.InvestmentTermInYears,
                LumpSumInvestment = model.LumpSumInvestment,
                MonthlyInvestment = model.MonthlyInvestment,
                RiskLevel = model.RiskLevel
            };
        }
    }
}
