using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculation.Domain
{
    public class Occupation
    {
        public int Id { get; set; }
        public string OccupationTitle { get; set; }
        public int RatingId { get; set; }
        public Rating Rating { get; set; }

    }
}
