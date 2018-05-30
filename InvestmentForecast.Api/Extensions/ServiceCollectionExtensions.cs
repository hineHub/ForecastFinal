﻿using InvestmentForecast.Api.Mapper;
using InvestmentForecaster.Service;
using InvestmentForecaster.Service.Bounds;
using InvestmentForecaster.Service.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace InvestmentForecast.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDependencies(this IServiceCollection collection)
        {
            collection.AddTransient<IInvestmentForecastOrchestrator, InvestmentForecastOrchestrator>();
            collection.AddTransient<IBoundsFactory, BoundsFactory>();
            collection.AddTransient<IForecastCalculator, ForecastAnnualGrowthCalculator>();
            collection.AddTransient<IServiceRequestMapper, ServiceRequestMapper>();
            collection.AddTransient<IServiceResponseMapper, ServiceResponseMapper>();
            collection.AddTransient<IValidationService, ValidationService>();
        }
    }
}
