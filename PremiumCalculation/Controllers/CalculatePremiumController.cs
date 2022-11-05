using Microsoft.AspNetCore.Mvc;
using PremiumCalculation.Service;
using PremiumCalculation.Domain.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumCalculation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatePremiumController : ControllerBase
    {
        

        private readonly IOccupationService _occupationService;
        private readonly ICalculationService _calculationService;

        public CalculatePremiumController(IOccupationService occupationService, ICalculationService calculationService)
        {
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
