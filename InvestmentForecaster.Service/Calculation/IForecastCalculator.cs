using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentForecaster.Service.Bounds;
using InvestmentForecaster.Service.DTO;

namespace InvestmentForecaster.Service
{
    public interface IForecastCalculator
    {
        Task<IEnumerable<ForecastResponse>> Calculate(IBounds bounds, ForecastRequestDto request);

    }
}