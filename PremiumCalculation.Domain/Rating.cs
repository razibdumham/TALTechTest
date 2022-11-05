using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PremiumCalculation.Domain
{
    public class Rating
    {
        public int Id { get; set; }
        public string RatingTitle { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Factor { get; set; }

        public ICollection<Occupation> Occupations { get; set; }
    }
}
