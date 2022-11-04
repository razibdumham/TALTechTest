using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculation.Domain.ViewModel
{
    public class RatingModel
    {
        public int Id { get; set; }
        public string RatingTitle { get; set; }
        public decimal Factor { get; set; }
    }
    
}
