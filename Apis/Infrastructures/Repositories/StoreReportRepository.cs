using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructures.Repositories
{
    public class StoreReportRepository : GenericRepository<StoreReport>, IStoreReportRepository
    {
        private readonly AppDbContext _dbContext;

    public StoreReportRepository(AppDbContext dbContext,
        ICurrentTime timeService,
        IClaimsService claimsService)
        : base(dbContext,
              timeService,
              claimsService)
    {
        _dbContext = dbContext;
    }
        public override Task<IEnumerable<StoreReport>> GetFilterAsync(StoreReport entity)
        {
            throw new NotImplementedException();
        }

}
}
