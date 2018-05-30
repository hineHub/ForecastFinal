using InvestmentForecast.Api;
using InvestmentForecast.Api.Models.Request;
using InvestmentForecast.E2E.Tests.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentForecast.E2E.Tests
{
    public class ApiHelper
    {
        private TestServer _server;
        private HttpClient _client;

        public ApiHelper()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        public async Task<ForecastViewModel> Calculate(CalculateRequest request)
        {
            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync("/api/InvestmentForecast", contents);

            return JsonConvert.DeserializeObject<Tests.Model.ForecastViewModel>(await response.Content.ReadAsStringAsync());
        }
    }
}
