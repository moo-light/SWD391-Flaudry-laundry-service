﻿using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Utils;
using Domain.Entities;
using System.Linq.Expressions;

namespace Infrastructures.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _dbContext;

    public OrderRepository(AppDbContext dbContext,
        ICurrentTime timeService,
        IClaimsService claimsService)
        : base(dbContext,
              timeService,
              claimsService)
    {
        _dbContext = dbContext;
    }

        public override async Task<IEnumerable<Order>?> GetFilterAsync(Order entity)
        {
            IQueryable<Order> result;

            Expression<Func<Order, bool>> batchId = x => entity.BatchId.EmptyOrEquals(x.BatchId);
            Expression<Func<Order, bool>> buildingId = x => entity.BuildingId.EmptyOrEquals(x.BuildingId);
            Expression<Func<Order, bool>> packageId = x => entity.PackageId.EmptyOrEquals(x.PackageId);
            Expression<Func<Order, bool>> paymentId = x => entity.PaymentId.EmptyOrEquals(x.PaymentId);
            Expression<Func<Order, bool>> storeId = x => entity.StoreId.EmptyOrEquals(x.StoreId);
            Expression<Func<Order, bool>> userId = x => entity.UserId.EmptyOrEquals(x.UserId);
            Expression<Func<Order, bool>> deliveringStatus = x => entity.DeliveringStatus.EmptyOrContainedIn(x.DeliveringStatus);
            Expression<Func<Order, bool>> totalPrice = x => entity.UserId.EmptyOrEquals(x.UserId);

            var predicates = ExpressionUtils.CreateListOfExpression(userId,buildingId,packageId,paymentId,storeId,userId,deliveringStatus,totalPrice);

            result = predicates.Aggregate(_dbSet.AsQueryable(), (a, b) => a.Where(b));

            return result.AsEnumerable();
        }
    }
}
