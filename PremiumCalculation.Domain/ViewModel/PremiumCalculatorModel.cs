using System;
using System.Collections.Generic;

namespace PremiumCalculation.Domain.ViewModel
{
    public class PremiumCalculatorModel
    {
        public PremiumCalculatorModel()
        {
            Ratings = new List<RatingModel>();
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string OccupationTitle { get; set; }
        public decimal SumInsured { get; set; }
        public int RatingId { get; set; }
        public List<RatingModel> Ratings { get; set; }
}
}
