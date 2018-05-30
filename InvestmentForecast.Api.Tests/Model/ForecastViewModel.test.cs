using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecast.E2E.Tests.Model
{
    public class ForecastViewModel
    {
        public IEnumerable<ErrorModel> HasErrors { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public bool Success { get; set; }
       
        public IEnumerable<decimal> TotalValue { get; set; }
        public IEnumerable<decimal> WideLowerValue { get; set; }
        public IEnumerable<decimal> WideUpperValue { get; set; }

        public IEnumerable<decimal> NarrowLowerValue { get; set; }
        public IEnumerable<decimal> NarrowUpperValue { get; set; }

    }

    public class ErrorModel
    {
        public string Source { get; }
        public string Message { get; }
    }
}
