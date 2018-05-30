using InvestmentForecaster.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentForecaster.Service.Model
{
    public class ForecastResponseDto
    {
        public ForecastResponseDto(IEnumerable<string> validationMessages)
        {
            ValidationMessages = validationMessages;
        }

        public ForecastResponseDto(IEnumerable<ForecastResponse> annualForecasts)
        {
            AnnualForecasts = annualForecasts;
        }

        public IEnumerable<ForecastResponse> AnnualForecasts { get; }

        public IEnumerable<string> ValidationMessages { get; }
        public bool Success => ValidationMessages == null || !ValidationMessages.Any();
    }
}
