using Microsoft.AspNetCore.Mvc;
using Sparrow.StandardResult.Web;
using Sparrow.StandardResult.WebTest.Models;
using System;
using System.Linq;

namespace Sparrow.StandardResult.WebTest.Controllers
{
    [Route("[controller]")]
    [StandardModelResult]
    public class WeatherForecastController : StandardControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController() : base("weather")
        {

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
            var dto = new Standard(); ;
            return new JsonResult(dto.SuccessResult(weathers));
        }
        [HttpGet, Route("/page")]
        public IActionResult Page()
        {
            var result = GetStandard();
            var pagination = new StandardPagination<WeatherForecast>();
            var rng = new Random();
            var weathers = Enumerable.Range(1, 92).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            pagination.GetPagination(weathers, 92, 1, 10);
            result.SuccessResult(pagination);
            return StandardContent(result);
        }

        [HttpGet, Route("/modelvalid")]
        public IActionResult ModelValid([FromQuery] QueryWeather query)
        {
            var dto = new Standard();
            return new JsonResult(dto.SuccessResult());
        }

        [HttpPost, Route("/CreateWeather")]
        public IActionResult CreateWeather([FromBody] CreateWeather weather)
        {
            var dto = new Standard();
            return new JsonResult(dto.SuccessResult());
        }

        [HttpGet, Route("/exception")]
        public ActionResult GetException() => throw new Exception("Sample exception.");

        [HttpGet, Route("/error")]
        public IActionResult Error()
        {
            var dto = new Standard();
            return new JsonResult(dto.ExceptionResult());
        }
    }
}
