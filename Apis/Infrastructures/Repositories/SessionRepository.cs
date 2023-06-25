using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructures.Repositories
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        private readonly AppDbContext _dbContext;

        public SessionRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Session> GetFilter(SessionFilteringModel entity)
        {
            entity ??= new();
            IEnumerable<Session> result;
            Expression<Func<Session, bool>> batchId = x => entity.BatchId.EmptyOrEquals(x.BatchId);
            Expression<Func<Session, bool>> buildingId = x => entity.BuildingId.EmptyOrEquals(x.BuildingId);
            Expression<Func<Session, bool>> date = x => x.CreationDate.IsInDateTime(entity);

            var predicates = ExpressionUtils.CreateListOfExpression(batchId, buildingId, date);

            result = predicates.Aggregate(_dbSet.AsEnumerable(), (a, b) => a.Where(b.Compile()));

            return result;
        }

     
    }
}
