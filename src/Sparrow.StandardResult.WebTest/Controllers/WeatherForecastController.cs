using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Sparrow.StandardResult.WebTest.Controllers
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
        public ActionResult Get()
        {
            var rng = new Random();
            var weathers = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            var dto = new Dto();
            dto.SuccessResult(weathers);
            return new JsonResult(dto.Format());
        }

        [HttpGet, Route("/exception")]
        public ActionResult GetException() => throw new Exception("Sample exception.");

        [HttpGet, Route("/error")]
        public IActionResult Error()
        {
            var dto = new Dto();
            dto.ExceptionResult();
            return new JsonResult(dto.Format());
        }
    }
}
