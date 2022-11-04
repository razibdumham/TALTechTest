using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculation.Domain.ViewModel
{
    public class OccupationModel
    {
        public int Id { get; set; }
        public string OccupationTitle { get; set; }
        public decimal Factor { get; set; }
    }
    
}
