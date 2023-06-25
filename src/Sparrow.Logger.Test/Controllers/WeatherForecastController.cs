using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.Logger.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("log 1 this is info");
            _logger.LogDebug("log 2 this is debug");
            _logger.LogError("log 3 this is error");
            SparrowLogger.Logger.LogInformation("nlog 1 this is info");
            SparrowLogger.Logger.LogDebug("nlog 2 this is debug");
            SparrowLogger.Logger.LogError("nlog 3 this is error");
            SparrowLogger.GetLogger<WeatherForecast>().LogInformation("nlogfac 1 this is info");
            SparrowLogger.GetLogger<WeatherForecast>().LogDebug("nlogfac 2 this is info");
            SparrowLogger.GetLogger<WeatherForecast>().LogError("nlogfac 3 this is info");
            SparrowLogger.GetLogger<WeatherForecastController>().LogInformation("nlogfac 1 this is info");
            SparrowLogger.GetLogger<WeatherForecastController>().LogDebug("nlogfac 2 this is info");
            SparrowLogger.GetLogger<WeatherForecastController>().LogError("nlogfac 3 this is info");

            SparrowLogger.GetLogger("hello").LogInformation("nlogdef 1 this is info");
            SparrowLogger.GetLogger("hello").LogDebug("nlogdef 2 this is info");
            SparrowLogger.GetLogger("hello").LogError("nlogdef 3 this is info");
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
