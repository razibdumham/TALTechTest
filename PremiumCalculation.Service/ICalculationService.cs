using PremiumCalculation.Domain.ViewModel;
using System.Threading.Tasks;

namespace PremiumCalculation.Service
{
    public interface ICalculationService
    {
        Task<decimal> CalculatePremium(PremiumCalculatorModel model);
    }
}