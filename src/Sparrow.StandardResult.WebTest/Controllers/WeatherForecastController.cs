using Microsoft.AspNetCore.Mvc;
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
            var dto = new StandardDto(); ;
            return new JsonResult(dto.SuccessResult(weathers));
        }

        [HttpGet, Route("/modelvalid")]
        public IActionResult ModelValid([FromQuery] QueryWeather query)
        {
            var dto = new StandardDto();
            return new JsonResult(dto.SuccessResult());
        }

        [HttpGet, Route("/exception")]
        public ActionResult GetException() => throw new Exception("Sample exception.");

        [HttpGet, Route("/error")]
        public IActionResult Error()
        {
            var dto = new StandardDto();
            return new JsonResult(dto.ExceptionResult());
        }
    }
}
