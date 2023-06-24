using Application.Commons;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IBuildingService
    {
        Task<bool> AddAsync(Building building);
        Task<Pagination<Building>> GetAllAsync();
        Task<Building?> GetByIdAsync(Guid entityId);
        Task<int> GetCountAsync();
        Task<Pagination<Building>> GetFilterAsync(BuildingFilteringModel entity);
        bool Remove(Guid entityId);
        bool Update(Building entity);
    }
}
