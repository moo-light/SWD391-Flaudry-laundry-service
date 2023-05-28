using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IBatchService
    {
        Task<bool> AddAsync(Batch batch);
        Task<IEnumerable<Batch>> GetAllAsync();
        Task<Batch?> GetByIdAsync(Guid entityId);
        bool Remove(Guid entityId);
        bool Update(Batch entity);
    }
}
