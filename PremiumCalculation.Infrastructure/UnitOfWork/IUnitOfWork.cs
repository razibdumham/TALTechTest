using PremiumCalculation.Infrastructure.Repository;
using System.Threading.Tasks;

namespace PremiumCalculation.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        PremiumCalculationDBContext _dbContext { get; set; }
        OccupationRepository _occupationRepository { get; set; }
        IOccupationRepository OccupationRepository { get; }
        RatingRepository _ratingRepository { get; set; }
        IRatingRepository RatingRepository { get; }

        void Commit();
        Task CommitAsync();
        void Rollback();
        Task RollbackAsync();
    }
}