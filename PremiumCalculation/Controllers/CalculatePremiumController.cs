using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PremiumCalculation.Service;
using PremiumCalculation.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatePremiumController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CalculatePremiumController> _logger;
        private readonly IOccupationService _occupationService;
        private readonly ICalculationService _calculationService;

        public CalculatePremiumController(ILogger<CalculatePremiumController> logger, IOccupationService occupationService, ICalculationService calculationService)
        {
            _logger = logger;
            _occupationService = occupationService;
            _calculationService = calculationService;
        }

        [HttpGet]
        public async Task<PremiumCalculatorModel> Get()
        {
            var model = new PremiumCalculatorModel();
            model.Occupations = await _occupationService.GetAll();

            return model;
        }

        [HttpPost]
        public async Task<PremiumCalculatorModel> Post(PremiumCalculatorModel model)
        {
            //Test server side validation
            //ModelState.AddModelError("Name", "Name is required");
            if (ModelState.IsValid)
            {
                model.CalculatedPremium = await _calculationService.CalculatePremium(model);
                return model;
            }
            model.Errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                                .Select(m => m.ErrorMessage).ToList();
            return model;

        }
    }
}
