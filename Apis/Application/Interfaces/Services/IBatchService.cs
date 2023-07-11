using Application.Commons;
using Application.ViewModels.FilterModels;
using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Batchs;
using Application.ViewModels.Buildings;

namespace Application.Interfaces.Services
{
    public interface IBatchService
    {
        Task<bool> AddAsync(BatchRequestDTO_V2 batchDTO, Guid? driverId);
        Task<bool> Update(Guid id, BatchRequestDTO_V2 batchDTO);
        Task<IEnumerable<BatchResponseDTO>> GetAllAsync();
        Task<Batch?> GetByIdAsync(Guid entityId);
        Task<int> GetCountAsync();
        Task<IEnumerable<Batch>> GetFilterAsync(BatchFilteringModel driver);
        bool Remove(Guid entityId);
        Task<Pagination<BatchResponseDTO>> GetBatchListPagi(int pageIndex, int pageSize);
        Task<Pagination<BatchResponseDTO>> GetFilterAsync(BatchFilteringModel batch, int pageIndex, int pageSize);
    }
}
