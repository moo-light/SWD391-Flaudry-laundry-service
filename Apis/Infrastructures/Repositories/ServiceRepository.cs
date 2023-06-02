using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.ViewModels;
using Domain.Entities;

namespace Infrastructures.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        private readonly AppDbContext _dbContext;

    public ServiceRepository(AppDbContext dbContext,
        ICurrentTime timeService,
        IClaimsService claimsService)
        : base(dbContext,
              timeService,
              claimsService)
    {
        _dbContext = dbContext;
    }

        public override Task<IQueryable<Service>> GetFilterAsync(BaseFilterringModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
