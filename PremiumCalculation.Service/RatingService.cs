using PremiumCalculation.Infrastructure.UnitOfWork;
using System.Threading.Tasks;

namespace PremiumCalculation.Service
{
    public class RatingService : IRatingService
    {
        public IUnitOfWork _unitOfWork;

        public RatingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        

        public async Task<decimal> GetOccupationRatingFactorByRatingId(int id)
        {
            var rating = await _unitOfWork.RatingRepository.GetAsync(r => r.Id == id);

            return rating?.Factor ?? 0;
        }
            
    }
}
