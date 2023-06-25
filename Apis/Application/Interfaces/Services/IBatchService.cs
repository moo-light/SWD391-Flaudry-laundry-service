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
    public interface IBatchService
    {
        Task<bool> AddAsync(Batch batch);
        Task<IEnumerable<Batch>> GetAllAsync();
        Task<Batch?> GetByIdAsync(Guid entityId);
        Task<int> GetCountAsync();
        Task<IEnumerable<Batch>> GetFilterAsync(BatchFilteringModel entity);
        bool Remove(Guid entityId);
        bool Update(Batch entity);
        Task<Pagination<Batch>> GetBatchListPagi(int pageIndex, int pageSize);

    }
}
