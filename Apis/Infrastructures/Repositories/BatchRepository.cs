using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class BatchRepository : GenericRepository<Batch>, IBatchRepository
    {
        private readonly AppDbContext _appDbContext;
        public BatchRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _appDbContext = context;
        }

        public IEnumerable<Batch> GetFilter(BatchFilteringModel? entity)
        {
            entity ??= new();
            Expression<Func<Batch, bool>> driverId = x => entity.DriverId.EmptyOrEquals(x.DriverId);
            Expression<Func<Batch, bool>> type = x => entity.Type.EmptyOrContainedIn(x.Type);
            Expression<Func<Batch, bool>> status = x => entity.Status.EmptyOrContainedIn(x.Status);
            Expression<Func<Batch, bool>> dateFilter = x => x.CreationDate.IsInDateTime(entity.FromDate, entity.ToDate);

            var predicates = ExpressionUtils.CreateListOfExpression(driverId, status, type, dateFilter);

            var result = predicates.Aggregate(_dbSet.AsEnumerable(), (a, b) => a.Where(b.Compile()));

            return result;  
        }
    }
}
