using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PremiumCalculation.Service;
using PremiumCalculation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculation.Controllers
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
        private readonly IRatingService _ratingService;
        private readonly ICalculationService _calculationService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRatingService ratingService, ICalculationService calculationService)
        {
            _logger = logger;
            _ratingService = ratingService;
            _calculationService = calculationService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var ratings = await _ratingService.GetAll();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<decimal> Post(PremiumCalculatorModel model)
        {
            var premium = await _calculationService.CalculatePremium(model);
            return premium;
        }
    }
}
