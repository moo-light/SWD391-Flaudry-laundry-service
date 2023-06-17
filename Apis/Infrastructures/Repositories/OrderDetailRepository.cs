using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Infrastructures.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {

        public OrderDetailRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
        }

        public  IEnumerable<OrderDetail> GetFilter(BaseFilterringModel entity)
        {
            throw new NotImplementedException();
        }

        //public override async Task<IEnumerable<OrderDetail>> GetFilterAsync(BaseFilterringModel entity)
        //{
        //    throw new NotImplementedException();

        //    //IQueryable<OrderDetail> result;

        //    //Expression<Func<OrderDetail, bool>> batchId = x => entity.BatchId.EmptyOrEquals(x.BatchId);
        //    //Expression<Func<OrderDetail, bool>> buildingId = x => entity.BuildingId.EmptyOrEquals(x.BuildingId);
        //    //Expression<Func<OrderDetail, bool>> packageId = x => entity.PackageId.EmptyOrEquals(x.PackageId);
        //    //Expression<Func<OrderDetail, bool>> paymentId = x => entity.PaymentId.EmptyOrEquals(x.PaymentId);
        //    //Expression<Func<OrderDetail, bool>> storeId = x => entity.StoreId.EmptyOrEquals(x.StoreId);
        //    //Expression<Func<OrderDetail, bool>> userId = x => entity.UserId.EmptyOrEquals(x.UserId);
        //    //Expression<Func<OrderDetail, bool>> deliveringStatus = x => entity.DeliveringStatus.EmptyOrContainedIn(x.DeliveringStatus);
        //    //Expression<Func<OrderDetail, bool>> totalPrice = x => entity.UserId.EmptyOrEquals(x.UserId);

        //    //var predicates = ExpressionUtils.CreateListOfExpression(userId,buildingId,packageId,paymentId,storeId,userId,deliveringStatus,totalPrice);

        //    //result = predicates.Aggregate(_dbSet.AsQueryable(), (a, b) => a.Where(b));

        //    //return result.AsEnumerable();

        //}

    }
}
