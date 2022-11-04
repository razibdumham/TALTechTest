using PremiumCalculation.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculation.Infrastructure.Repository
{
    public class OccupationRepository : GenericRepository<Occupation>
    {
        public OccupationRepository(PremiumCalculationDBContext dBContext) : base(dBContext)
        {

        }
    }
}
