using PremiumCalculation.Domain;
using PremiumCalculation.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PremiumCalculation.Service
{
    public interface ICalculationService
    {
        Task<decimal> CalculatePremium(PremiumCalculatorModel model);
    }
}