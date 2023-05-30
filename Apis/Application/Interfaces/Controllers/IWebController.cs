using Domain.Entities;
using Domain.Entitiess;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public interface IWebController<TEntity> where TEntity : BaseEntity
    {
        Task<IActionResult> AddAsync(TEntity entity);
        IActionResult DeleteById(Guid id);
        Task<IActionResult> GetByIDAsync(Guid id);
        //Task<IActionResult> GetCount();
        //Task<IActionResult> GetListWithFilter(TEntity entity);
        IActionResult Update(TEntity entity);
    }
}