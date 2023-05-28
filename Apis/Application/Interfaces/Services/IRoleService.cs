using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IRoleService
    {
        Task<bool> AddAsync(Role entity);
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(Guid entityId);
        bool Remove(Guid entityId);
        bool Update(Role entity);
    }
}
