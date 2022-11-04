using PremiumCalculation.Domain;
using PremiumCalculation.Domain.ViewModel;
using PremiumCalculation.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
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



        public async Task<List<RatingModel>> GetAll()
        {
            var ratings = await _unitOfWork.RatingRepository.GetAllAsync();

            var ratingModelList = this.PrepareRatingModel(ratings);

            return ratingModelList;
        }

        //For this type of Mapping automapper library is used as standard practice
        private List<RatingModel> PrepareRatingModel(IEnumerable<Rating> ratings)
        {
            var ratingModelList = new List<RatingModel>();
            foreach (var rating in ratings)
            {
                var ratingModel = new RatingModel();

                ratingModel.Id = rating.Id;
                ratingModel.RatingTitle = rating.RatingTitle;
                ratingModel.Factor = rating.Factor;
                ratingModelList.Add(ratingModel);
            }
            return ratingModelList;
        }

        public async Task<decimal> GetOccupationRatingFactorByRatingId(int id)
        {
            var rating = await _unitOfWork.RatingRepository.GetAsync(r => r.Id == id);

            return rating?.Factor ?? 0;
        }
            
    }
}
