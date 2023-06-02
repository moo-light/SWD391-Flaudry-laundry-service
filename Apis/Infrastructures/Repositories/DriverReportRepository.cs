using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
using Domain.Entities;
using Domain.Enums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class DriverReportRepository : GenericRepository<DriverReport>, IDriverReportRepository
    {
        private readonly AppDbContext _appDbContext;
        public DriverReportRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _appDbContext = context;
        }

        public override Task<IQueryable<DriverReport>> GetFilterAsync(BaseFilterringModel entity)
        {
            //IQueryable<DriverReport> result = null;

            //Expression<Func<DriverReport, bool>> userId = x => entity.UserId.HasValue == false || x.UserId == entity.UserId;
            //Expression<Func<DriverReport, bool>> reason = x => entity.Reason.IsNullOrEmpty() || x.Reason.Contains(entity.Reason);
            //Expression<Func<DriverReport, bool>> status = x => (entity.Status.IsNullOrEmpty()) || x.Status.Contains(entity.Status) ;

            //var predicates = ExpressionUtils.CreateListOfExpression(userId,reason,status);

            //result = predicates.Aggregate(_dbSet.AsQueryable(), (a, b) => a.Where(b));

            //return result.AsEnumerable();
            throw new NotImplementedException();
        }

    }
}
