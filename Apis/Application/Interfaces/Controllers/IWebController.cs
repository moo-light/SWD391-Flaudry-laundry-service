using Domain.Entitiess;

namespace WebAPI.Controllers
{
    public interface IWebController<TEntity> where TEntity:BaseEntity
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task GetByID(Guid entityId);
        Task DeleteById(Guid entityId);
        Task GetAll(Guid entityId,bool isDeleted);
    }
}