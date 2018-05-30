using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecaster.Service.Bounds
{
    public class BoundsFactory : IBoundsFactory
    {
        public IBounds GetBounds(string riskLevel)
        {
            if (string.IsNullOrWhiteSpace(riskLevel)) throw new ArgumentException("Risk level unknown");

            IBounds bounds;

            switch (riskLevel.ToLower())
            {
                case "low":
                    bounds = new LowRiskBounds();
                    break;
                case "medium":
                    bounds = new MediumRiskBounds();
                    break;
                case "high":
                    bounds = new HighRiskBounds();
                    break;
                default:
                    throw new ArgumentException("Risk level is out of bounds");
                    
            }

            return bounds;
        }
    }
}
