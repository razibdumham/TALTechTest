using PremiumCalculation.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculation.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public PremiumCalculationDBContext _dbContext { get; set; }
        public OccupationRepository _occupationRepository { get; set; }

        public UnitOfWork(PremiumCalculationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public IOccupationRepository OccupationRepository
        {
            get { return _occupationRepository = _occupationRepository ?? new OccupationRepository(_dbContext); }
        }

        public void Commit()
            => _dbContext.SaveChanges();

        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();

        public void Rollback()
            => _dbContext.Dispose();

        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
