using Microsoft.EntityFrameworkCore;
using PremiumCalculation.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculation.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>().HasData(
                new Rating { Id = 1, RatingTitle = "Professional", Factor = 1 },
                new Rating { Id = 2, RatingTitle = "White Collar", Factor = 1.25m },
                new Rating { Id = 3, RatingTitle = "Light Manual", Factor = 1.50m },
                new Rating { Id = 4, RatingTitle = "Heavy Manual", Factor = 1.75m }
            );
            modelBuilder.Entity<Occupation>().HasData(
                new Occupation { Id = 1, OccupationTitle = "Cleaner", RatingId = 3 },
                new Occupation { Id = 2, OccupationTitle = "Doctor", RatingId = 1 },
                new Occupation { Id = 3, OccupationTitle = "Author", RatingId = 2 },
                new Occupation { Id = 4, OccupationTitle = "Farmer", RatingId = 4 },
                new Occupation { Id = 5, OccupationTitle = "Mechanic", RatingId = 4 },
                new Occupation { Id = 6, OccupationTitle = "Florist", RatingId = 3 }
            );
        }
    }
}
