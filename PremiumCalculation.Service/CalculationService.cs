using PremiumCalculation.Domain;
using PremiumCalculation.Infrastructure.UnitOfWork;
using PremiumCalculation.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculation.Service
{
    public class CalculationService : ICalculationService
    {
        public IUnitOfWork _unitOfWork;
        public IRatingService _ratingService;

        public CalculationService(IUnitOfWork unitOfWork, IRatingService ratingService)
        {
            _unitOfWork = unitOfWork;
            _ratingService = ratingService;
        }



        public async Task<decimal> CalculatePremium(PremiumCalculatorModel model)
        {
            var age = this.CalculateAge(model.DateOfBirth);
            decimal occupationRatingFactor = await _ratingService.GetOccupationRatingFactorByRatingId(model.RatingId);
            return
                (model.SumInsured * occupationRatingFactor * age) / 1000 * 12;
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - dateOfBirth.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
