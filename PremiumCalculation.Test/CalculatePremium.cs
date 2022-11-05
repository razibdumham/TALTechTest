using PremiumCalculation.Domain.ViewModel;
using PremiumCalculation.Service;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PremiumCalculation.Test
{
    public class CalculatePremium
    {
        private readonly ICalculationService _calculationService;
        private readonly IRatingService _ratingService;
        public CalculatePremium(ICalculationService calculationService, IRatingService ratingService)
        {
            _calculationService = calculationService;
            _ratingService = ratingService;
        }

        [Theory]
        [InlineData(4000, 2, "1986-1-1")]
        public async void TestCalculatePremium(decimal sumInsured, int ratingId, string dateOfBirth)
        {
            var dob = DateTime.Parse(dateOfBirth);

            var premiumCalculatorModel = new PremiumCalculatorModel();
            premiumCalculatorModel.SumInsured = sumInsured;
            premiumCalculatorModel.RatingId = ratingId;
            premiumCalculatorModel.DateOfBirth = dob;

            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - dob.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (dob.Date > today.AddYears(-age))
            {
                age--;
            }
            var occupationRatingFactor = await _ratingService.GetOccupationRatingFactorByRatingId(ratingId);

            var calculatedResult = await _calculationService.CalculatePremium(premiumCalculatorModel);
            var expectedResult = (sumInsured * occupationRatingFactor * age) / 1000 * 12;

            //Assert
            Assert.Equal(calculatedResult, expectedResult);
        }
    }
}
