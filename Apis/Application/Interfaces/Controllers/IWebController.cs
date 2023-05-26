using Domain.Entities;
using Domain.Entitiess;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public interface IWebController<TEntity> where TEntity : BaseEntity
    {
        Task<IActionResult> AddAsync(TEntity entity);
        IActionResult DeleteById(Guid entityId);
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> GetByIDAsync(Guid entityId);
        IActionResult Update(TEntity entity);
    }
}