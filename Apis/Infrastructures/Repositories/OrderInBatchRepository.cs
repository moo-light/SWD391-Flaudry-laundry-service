using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Application.ViewModels;
using Domain.Entities;
using Infrastructures;
using Infrastructures.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Application.Interfaces.Repositories;

public class OrderInBatchRepository : GenericRepository<OrderInBatch>, IOrderInBatchRepository
{

    public OrderInBatchRepository(AppDbContext dbContext,
        ICurrentTime timeService,
        IClaimsService claimsService)
        : base(dbContext,
              timeService,
              claimsService)
    {
    }

    public  IEnumerable<OrderInBatch> GetFilter(BaseFilterringModel entity)
    {
        throw new NotImplementedException();
    }

    //public override async Task<IEnumerable<Order>> GetFilterAsync(BaseFilterringModel entity)
    //{
    //    throw new NotImplementedException();

    //    //IQueryable<Order> result;

    //    //Expression<Func<Order, bool>> batchId = x => entity.BatchId.EmptyOrEquals(x.BatchId);
    //    //Expression<Func<Order, bool>> buildingId = x => entity.BuildingId.EmptyOrEquals(x.BuildingId);
    //    //Expression<Func<Order, bool>> packageId = x => entity.PackageId.EmptyOrEquals(x.PackageId);
    //    //Expression<Func<Order, bool>> paymentId = x => entity.PaymentId.EmptyOrEquals(x.PaymentId);
    //    //Expression<Func<Order, bool>> storeId = x => entity.StoreId.EmptyOrEquals(x.StoreId);
    //    //Expression<Func<Order, bool>> userId = x => entity.UserId.EmptyOrEquals(x.UserId);
    //    //Expression<Func<Order, bool>> deliveringStatus = x => entity.DeliveringStatus.EmptyOrContainedIn(x.DeliveringStatus);
    //    //Expression<Func<Order, bool>> totalPrice = x => entity.UserId.EmptyOrEquals(x.UserId);

    //    //var predicates = ExpressionUtils.CreateListOfExpression(userId,buildingId,packageId,paymentId,storeId,userId,deliveringStatus,totalPrice);

    //    //result = predicates.Aggregate(_dbSet.AsQueryable(), (a, b) => a.Where(b));

    //    //return result.AsEnumerable();

    //}

}
