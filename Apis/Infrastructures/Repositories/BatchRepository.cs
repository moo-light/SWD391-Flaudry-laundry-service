using Application.ViewModels.FilterModels;
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
using Microsoft.EntityFrameworkCore;
using Domain.Entitiess;
using System.IO;
using Application.Constants;
using Domain.Enums;

namespace Infrastructures.Repositories
{
    public class BatchRepository : GenericRepository<Batch>, IBatchRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICurrentTime _timeService;

        public BatchRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _appDbContext = context;
            _timeService = timeService;
        }

        public IEnumerable<Batch> GetFilter(BatchFilteringModel? entity)
        {
            entity ??= new();
            Expression<Func<Batch, bool>> driverId = x => entity.DriverId.EmptyOrEquals(x.DriverId);
            Expression<Func<Batch, bool>> type = x => entity.Type.EmptyOrContainedIn(x.Type);
            Expression<Func<Batch, bool>> status = x => entity.Status.EmptyOrContainedIn(x.Status);
            Expression<Func<Batch, bool>> dateFilter = x => x.CreationDate.IsInDateTime(entity.FromDate, entity.ToDate);

            var predicates = ExpressionUtils.CreateListOfExpression(driverId, status, type, dateFilter);
            var includes = new Expression<Func<Batch, dynamic>>[]
            {
                x => x.Driver,
                x => x.OrderInBatches, // include Order that bai r
                x => x.BatchOfBuildings
            };
            var seed = includes.Aggregate(_dbSet.AsNoTracking(), (set, include) => set.Include(include));
            var result = predicates.Aggregate(seed.AsEnumerable(), (a, b) => a.Where(b.Compile()));

            return result;
        }

        public Batch GetNewestBatch()
        {
            var batch = _dbContext.Batchs.Include(x => x.OrderInBatches).AsNoTracking().OrderByDescending(x => x.CreationDate).ThenByDescending(x => x.ModificationDate).FirstOrDefault();
            if (batch.OrderInBatches.Count >= BatchConstant.BatchSize)
            {
                var currentTime = _timeService.GetCurrentTime();
                DateTime fromTime = currentTime;
                DateTime toTime = currentTime;
                if (currentTime.Hour >= 17 || currentTime.Hour < 5)
                {   //17 + 14 = 31 (7:00 am)
                    //18 + 14 - 1 = 31
                    //24 + 14 - 7 = 31
                    if (currentTime.Hour >= 17) fromTime.AddHours(24 - currentTime.Hour + 13);
                    else
                    //1 
                    if (currentTime.Hour < 5) fromTime.AddHours(13 - currentTime.Hour);
                }
                else if (fromTime.Hour >= 11)
                {
                    //
                    fromTime.AddHours(24 + 7 - currentTime.Hour );
                }
                else if (fromTime.Hour >= 5)
                {
                    fromTime.AddHours(19 - currentTime.Hour);
                }
                toTime = fromTime.AddHours(2);


                batch = new Batch()
                {
                    Type = nameof(BatchType.Pickup),
                    Status = nameof(BatchStatus.Pending),
                    FromTime = fromTime,
                    ToTime = toTime
                };
                _dbContext.Add(batch);
            }
            return batch;
        }
    }
}
