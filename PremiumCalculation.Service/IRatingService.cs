using PremiumCalculation.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PremiumCalculation.Service
{
    public interface IRatingService
    {
        Task<IEnumerable<Rating>> GetAll();
    }
}