using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.ViewModels;
using Domain.Entities;

namespace Infrastructures.Repositories
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        private readonly AppDbContext _dbContext;

    public StoreRepository(AppDbContext dbContext,
        ICurrentTime timeService,
        IClaimsService claimsService)
        : base(dbContext,
              timeService,
              claimsService)
    {
        _dbContext = dbContext;
    }

        public override Task<IQueryable<Store>> GetFilterAsync(BaseFilterringModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
