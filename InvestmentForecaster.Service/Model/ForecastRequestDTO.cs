using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecaster.Service
{
    public class ForecastRequestDto
    {
        public decimal LumpSumInvestment { get; set; }

        public decimal MonthlyInvestment { get; set; }

         public int InvestmentTermInYears { get; set; }

        public string RiskLevel { get; set; }
    }
}
