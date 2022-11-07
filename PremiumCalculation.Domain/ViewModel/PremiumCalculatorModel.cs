using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PremiumCalculation.Domain.ViewModel
{
    public class PremiumCalculatorModel
    {
        public PremiumCalculatorModel()
        {
            Occupations = new List<OccupationModel>();
            Errors = new List<string>();
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MinimumAge(1)]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal SumInsured { get; set; }
        [Required]
        public decimal CalculatedPremium { get; set; }
        [Required]
        public int RatingId { get; set; }
        public List<OccupationModel> Occupations { get; set; }
        public List<string> Errors { get; set; }
    }
}
