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
        public IEnumerable<Session> GetFilter(BaseFilterringModel entity)
        {

            Expression<Func<Session, bool>> dateTime = x => x.StartTime.IsInDateTime(entity.FromDate.Value.Date,entity.ToDate.Value.Date); 
            var predicates = ExpressionUtils.CreateListOfExpression(dateTime);

            var result = predicates.Aggregate(_dbSet.AsEnumerable(), (a, b) => a.Where(b.Compile()));

            return result;
        }

     
    }
}
