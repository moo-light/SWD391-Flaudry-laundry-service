using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
using Domain.Entities;
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
        public override  IQueryable<Session> GetFilter(BaseFilterringModel entity)
        {
            IQueryable<Session> result = null;

            Expression<Func<Session, bool>> dateTime = x => x.StartTime.IsInDateTime(entity.FromDate.Value.Date,entity.ToDate.Value.Date); 
            var predicates = ExpressionUtils.CreateListOfExpression(dateTime);

            result = predicates.Aggregate(_dbSet.AsQueryable(), (a, b) => a.Where(b));

            return result;
        }

     
    }
}
