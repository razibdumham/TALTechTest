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
        private readonly IUnitOfWork _unitOfWork;

        public OccupationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<List<OccupationModel>> GetAll()
        {
            var occupations = await _unitOfWork.OccupationRepository.GetAllAsync();

            var occupationModelList = this.PrepareOccupationModelList(occupations);

            return occupationModelList;
        }

        //For this type of Mapping automapper library is used as standard practice
        private List<OccupationModel> PrepareOccupationModelList(IEnumerable<Occupation> occupations)
        {
            var occupationModelList = new List<OccupationModel>();
            foreach (var occupation in occupations)
            {
                var occupationModel = new OccupationModel();

                occupationModel.Id = occupation.Id;
                occupationModel.OccupationTitle = occupation.OccupationTitle;
                occupationModel.RatingId = occupation.RatingId;
                occupationModelList.Add(occupationModel);
            }
            return occupationModelList;
        }

            
    }
}
