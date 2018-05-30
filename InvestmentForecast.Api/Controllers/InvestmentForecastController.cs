using InvestmentForecast.Api.Mapper;
using InvestmentForecast.Api.Models.Request;
using InvestmentForecast.Api.Models.Response;
using InvestmentForecaster.Service;
using InvestmentForecaster.Service.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentForecast.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class InvestmentForecastController : Controller
    {
        IInvestmentForecastOrchestrator _orchestrator;
        IServiceRequestMapper _requestMapper;
        IServiceResponseMapper _responseMapper;

        public InvestmentForecastController(IInvestmentForecastOrchestrator orchestrator, 
            IServiceRequestMapper requestMapper, IServiceResponseMapper responseMapper)
        {
            _orchestrator = orchestrator;
            _requestMapper = requestMapper;
            _responseMapper = responseMapper;
        }

        /// <summary>
        /// Calculates the monthly annual growth value using monthly payments. Uses model binding validation.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Calculate([FromBody] CalculateRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ForecastRequestDto requestDto = _requestMapper.MapCalculation(request);
                    ForecastResponseDto responseDto = await _orchestrator.Orchestration(requestDto);
                    CalculateResponse response = _responseMapper.MapCalculationResponse(responseDto) ;

                    return Ok(response);
                }

                var errors = MapModelValidationErrors(ModelState);
                return BadRequest(new CalculateResponse(errors));
            }
            catch(Exception ex)
            {
                //logging
                return BadRequest(new CalculateResponse(new List<string>() { "Exception"}));
            }
        }

        public IEnumerable<string> MapModelValidationErrors(ModelStateDictionary modelState)
        {
            return modelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();
        }

    }
}