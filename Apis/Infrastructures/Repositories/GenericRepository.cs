using Application.Interfaces;
using Application.Commons;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Repositories;
using Domain.Entitiess;
using System.Linq.Expressions;
using Domain.Entities;
using Application.ViewModels;

namespace Infrastructures.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbSet<TEntity> _dbSet;
        protected AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public GenericRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
            _timeService = timeService;
            _claimsService = claimsService;
        }
        public async Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes) 
            => await includes
           .Aggregate(_dbSet.AsQueryable(),
               (entity, property) => entity.Include(property))
           .Where(x => x.IsDeleted == false).Take(200)
           .ToListAsync();
        public async Task<int> GetCountAsync(params Expression<Func<TEntity, object>>[] includes) =>
            await includes
           .Aggregate(_dbSet.AsQueryable(),
               (entity, property) => entity.Include(property))
           .Where(x => x.IsDeleted == false)
           .CountAsync();
        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            var result = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            // todo should throw exception when not found
            return result;
        }
        public async Task<bool> AddAsync(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreationDate = _timeService.GetCurrentTime();
            entity.CreatedBy = _claimsService.GetCurrentUserId;
            await _dbSet.AddAsync(entity);
            return true;
        }

        public bool SoftRemove(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeleteBy = _claimsService.GetCurrentUserId;
            _dbSet.Update(entity);
            return true;
        }
        public bool SoftRemoveByID(Guid entityId)
        {
            TEntity? entity = GetByIdAsync(entityId).Result;
            if (entity == null) return false;
            return SoftRemove(entity);
        }
        public bool Update(TEntity entity)
        {
            entity.ModificationDate = _timeService.GetCurrentTime();
            entity.ModificationBy = _claimsService.GetCurrentUserId;
            _dbSet.Update(entity);
            return true;
        }
        public async Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreationDate = _timeService.GetCurrentTime();
                entity.CreatedBy = _claimsService.GetCurrentUserId;
            }
            await _dbSet.AddRangeAsync(entities);
            return true;
        }

        public bool SoftRemoveRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.DeletionDate = _timeService.GetCurrentTime();
                entity.DeleteBy = _claimsService.GetCurrentUserId;
            }
            _dbSet.UpdateRange(entities);
            return true;
        }

        public async Task<Pagination<TEntity>> ToPagination(int pageIndex = 0, int pageSize = 10)
        {
            //var itemCount = await _dbSet.CountAsync();
            //var items = await _dbSet.OrderByDescending(x => x.CreationDate)
            //                        .Skip(pageIndex * pageSize)
            //                        .Take(pageSize)
            //                        .AsNoTracking()
            //                        .ToListAsync();
            
            //var result = new Pagination<TEntity>()
            //{
            //    PageIndex = pageIndex,
            //    PageSize = pageSize,
            //    TotalItemsCount = itemCount,
            //    Items = items,
            //};

            return ToPagination(_dbSet,pageIndex,pageSize);
        }
        public Pagination<TEntity> ToPagination(IEnumerable<TEntity> list, int pageIndex = 0, int pageSize = 10)
        {
            //var customerFilteringModels = new Pagination<Customer>
            //{
            //    PageIndex = customers.PageIndex,
            //    PageSize = customers.PageSize,
            //    TotalItemsCount = customers.TotalItemsCount,
            //    Items = customers.Items.Select(c => new Customer
            //    {
            //        FullName = c.FullName,
            //        Email = c.Email,
            //        PhoneNumber = c.PhoneNumber,
            //        Address = c.Address
            //    }).ToList()
            //};
            var result = new Pagination<TEntity>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Items = list.Skip(pageIndex * pageSize).Take(pageSize).ToList(),
                TotalItemsCount = list.Count()
            };

            return result;
        }
        public bool UpdateRange(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreationDate = _timeService.GetCurrentTime();
                entity.CreatedBy = _claimsService.GetCurrentUserId;
            }
            _dbSet.UpdateRange(entities);
            return true;    
        }

      
    }
}
