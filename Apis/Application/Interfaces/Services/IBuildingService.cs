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
        Task<IEnumerable<Building>> GetAllAsync();
        Task<Building?> GetByIdAsync(Guid entityId);
        bool Remove(Guid entityId);
        bool Update(Building entity);
    }
}
