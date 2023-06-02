using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
using Domain.Entities;
using Domain.Enums;
using System.Linq.Expressions;

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
        public override async Task<IQueryable<StoreReport>> GetFilterAsync(BaseFilterringModel entity)
        {
            IQueryable<StoreReport> result = null;

            Expression<Func<StoreReport, bool>> reason = x => entity.Search.EmptyOrContainedIn(x.ReasonReport);
            Expression<Func<StoreReport, bool>> status = x => x.Status.IsInEnumNames(entity.Status,typeof(ReportStatus));
            var predicates = ExpressionUtils.CreateListOfExpression(reason, status);

            result = predicates.Aggregate(_dbSet.AsQueryable(), (a, b) => a.Where(b));

            return result;
        }

}
}
