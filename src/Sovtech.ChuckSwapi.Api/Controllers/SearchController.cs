using Microsoft.AspNetCore.Mvc;
using Sovtech.ChuckSwap.Api;

namespace Sovtech.ChuckSwapi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ChuckController> _logger;

        public SearchController(ILogger<ChuckController> logger)
        {
            _logger = logger;
        }

        [HttpGet("search")]
        public IActionResult Get()
        {
            var values = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            return Ok(values);
        }
    }
}