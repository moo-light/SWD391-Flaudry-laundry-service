﻿using Application.Commons;
using Domain.Entitiess;

namespace Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync(params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<bool> AddAsync(TEntity entity);
        bool Update(TEntity entity);
        bool UpdateRange(List<TEntity> entities);
        bool SoftRemove(TEntity entity);
        bool SoftRemoveByID(Guid entityId);

        Task<bool> AddRangeAsync(List<TEntity> entities);
        bool SoftRemoveRange(List<TEntity> entities);

        Task<Pagination<TEntity>> ToPagination(int pageNumber = 0, int pageSize = 10);
    }
}
