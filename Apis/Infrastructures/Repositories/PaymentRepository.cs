using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly AppDbContext _appDbContext;

        public PaymentRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _appDbContext = context;
        }

        //public override async Task<IEnumerable<Payment>> GetFilterAsync(Payment entity)
        //{
        //    IQueryable<Payment> result;

        //    Expression<Func<Payment, bool>> status = x => entity.Status.EmptyOrContainedIn(x.Status);
        //    Expression<Func<Payment, bool>> packageId = x => entity.PackageId.EmptyOrEquals(x.PackageId);

        //    var predicates = ExpressionUtils.CreateListOfExpression(status,packageId);

        //    result = predicates.Aggregate(_dbSet.AsQueryable(), (a, b) => a.Where(b));

        //    return result.AsEnumerable();
        //}

        public  IEnumerable<Payment> GetFilter(BaseFilterringModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
