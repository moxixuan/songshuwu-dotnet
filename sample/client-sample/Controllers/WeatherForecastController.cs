using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using songshuwu.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client_sample.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public async Task<object> AddWithoutShop([FromServices] ISongshuwuHttpClient client)
        {
            var a = await client.AddWithoutShop(new OrderAddWithoutShopInput()
            {
                origin_id = "123"
            });
            return a;
        }
    }
}
