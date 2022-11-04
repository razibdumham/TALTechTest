using System;

namespace PremiumCalculation.ViewModel
{
    public class PremiumCalculatorModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string OccupationTitle { get; set; }
        public decimal SumInsured { get; set; }
        public int RatingId { get; set; }
    }
}
