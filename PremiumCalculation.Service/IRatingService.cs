using PremiumCalculation.Domain;
using PremiumCalculation.Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PremiumCalculation.Service
{
    public interface IRatingService
    {
        Task<List<RatingModel>> GetAll();
        Task<decimal> GetOccupationRatingFactorByRatingId(int id);
    }
}