using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
using Domain.Entities;
using System.Linq.Expressions;

namespace Infrastructures.Repositories
{
    public class TimeSlotRepository : GenericRepository<Session>, ITimeSlotRepository
    {
        private readonly AppDbContext _dbContext;

        public TimeSlotRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }
        public override async Task<IQueryable<Session>> GetFilterAsync(BaseFilterringModel entity)
        {
            IQueryable<Session> result = null;

            Expression<Func<Session, bool>> dateTime = x => x.Date.IsInDateTime(entity.FromDate,entity.ToDate); 
            var predicates = ExpressionUtils.CreateListOfExpression(dateTime);

            result = predicates.Aggregate(_dbSet.AsQueryable(), (a, b) => a.Where(b));

            return result;
        }

     
    }
}
