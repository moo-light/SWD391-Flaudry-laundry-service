using Domain.Entitiess;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public interface IWebController<TEntity> where TEntity : BaseEntity
    {
        Task<IActionResult> AddAsync(TEntity entity);
        IActionResult Update(TEntity entity);
        Task<IActionResult> GetByIDAsync(Guid entityId);
        IActionResult DeleteById(Guid entityId);
        Task<IActionResult> GetAllAsync();
    }
}