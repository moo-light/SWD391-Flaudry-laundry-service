using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
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

        public PaymentRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
        }

        public  IEnumerable<Payment> GetFilter(PaymentFilteringModel entity)
        {
            entity ??= new(); 
            IEnumerable<Payment> result;
            Expression<Func<Payment, bool>> orderId = x => entity.OrderId.EmptyOrEquals(x.OrderId);
            Expression<Func<Payment, bool>> paymentMethod = x => entity.PaymentMethod.EmptyOrContainedIn(x.PaymentMethod);
            Expression<Func<Payment, bool>> amount = x => entity.Amount.EmptyOrContainedIn(x.Amount.ToString());
            Expression<Func<Payment, bool>> status = x => entity.Status.EmptyOrContainedIn(x.Status);
            Expression<Func<Payment, bool>> date = x => x.CreationDate.IsInDateTime(entity);

            var predicates = ExpressionUtils.CreateListOfExpression(status, paymentMethod, amount, status,date);

            result = predicates.Aggregate(_dbSet.AsEnumerable(), (a, b) => a.Where(b.Compile()));

            return result;
        }
    }
}
