using System.Threading.Tasks;

namespace PremiumCalculation.Service
{
    public interface IRatingService
    {
        Task<decimal> GetOccupationRatingFactorByRatingId(int id);
    }
}