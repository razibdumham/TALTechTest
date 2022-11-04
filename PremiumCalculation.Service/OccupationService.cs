using PremiumCalculation.Domain;
using PremiumCalculation.Domain.ViewModel;
using PremiumCalculation.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculation.Service
{
    public class OccupationService : IOccupationService
    {
        public IUnitOfWork _unitOfWork;

        public OccupationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<List<OccupationModel>> GetAll()
        {
            var ratings = await _unitOfWork.RatingRepository.GetAllAsync();
            var occupations = await _unitOfWork.OccupationRepository.GetAllAsync();

            var occupationModelList = this.PrepareOccupationModelList(occupations, ratings);

            return occupationModelList;
        }

        //For this type of Mapping automapper library is used as standard practice
        private List<OccupationModel> PrepareOccupationModelList(IEnumerable<Occupation> occupations, IEnumerable<Rating> ratings)
        {
            var occupationModelList = new List<OccupationModel>();
            foreach (var occupation in occupations)
            {
                var occupationModel = new OccupationModel();

                occupationModel.Id = occupation.Id;
                occupationModel.OccupationTitle = occupation.OccupationTitle;
                occupationModel.Factor =  this.GetFactorByRatingId(occupation.RatingId, ratings);
                occupationModelList.Add(occupationModel);
            }
            return occupationModelList;
        }

        private decimal GetFactorByRatingId(int ratingId, IEnumerable<Rating> ratings)
        {
            var factor = ratings.Where(r => r.Id == ratingId).FirstOrDefault()?.Factor??0;
            return factor;
        }

        //public async Task<decimal> GetOccupationRatingFactorByRatingId(int id, IEnumerable<Rating> ratings)
        //{
        //    var rating = await _unitOfWork.RatingRepository.GetAsync(r => r.Id == id);

        //    return rating?.Factor ?? 0;
        //}
            
    }
}
