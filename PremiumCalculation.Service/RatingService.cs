﻿using PremiumCalculation.Domain;
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



        public async Task<IEnumerable<Rating>> GetAll()
            => await _unitOfWork.RatingRepository.GetAllAsync();

        public async Task<decimal> GetOccupationRatingFactorByRatingId(int id)
        {
            var rating = await _unitOfWork.RatingRepository.GetAsync(r => r.Id == id);

            return rating?.Factor ?? 0;
        }
            
    }
}
