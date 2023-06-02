using Application.ViewModels;
using Application.ViewModels.UserViewModels;
using Domain.Entities;
using Domain.Entitiess;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public interface IWebController<TEntity> where TEntity : BaseEntity
    {
        Task<IActionResult> Add(TEntity entity);
        IActionResult DeleteById(Guid id);
        Task<IActionResult> GetByIDAsync(Guid id);
        Task<IActionResult> GetCount();
        //Task<IActionResult> GetListWithFilter(BaseFilterringModel entity);
        IActionResult Update(TEntity entity);
    }
}