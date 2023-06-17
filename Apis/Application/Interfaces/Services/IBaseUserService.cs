using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IBaseUserService
    {
        Task<bool> AddAsync(BaseUser batch);
        Task<IEnumerable<BaseUser>> GetAllAsync();
        Task<BaseUser?> GetByIdAsync(Guid entityId);
        Task<int> GetCountAsync();
        Task<IEnumerable<BaseUser>> GetFilterAsync(BaseFilterringModel entity);
        bool Remove(Guid entityId);
        bool Update(BaseUser entity);
    }
}
