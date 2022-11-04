using PremiumCalculation.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculation.Infrastructure.Repository
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(PremiumCalculationDBContext dBContext) : base(dBContext)
        {

        }
    }
}
