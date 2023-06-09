using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
using Domain.Entities;
using System.Linq.Expressions;

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

        public override async Task<IQueryable<Store>> GetFilterAsync(BaseFilterringModel entity)
        {
            IQueryable<Store> result = null;

            Expression<Func<Store, bool>> address = x => entity.Search.EmptyOrContainedIn(x.Address);
            Expression<Func<Store, bool>> name = x => entity.Search.EmptyOrContainedIn(x.Name);
            Expression<Func<Store, bool>> ownerId = x => entity.Id.EmptyOrEquals(x.OwnerId);

            var predicates = ExpressionUtils.CreateListOfExpression(address, name,ownerId);

            result = predicates.Aggregate(_dbSet.AsQueryable(), (a, b) => a.Where(b));

            return result;
        }
    }
}
