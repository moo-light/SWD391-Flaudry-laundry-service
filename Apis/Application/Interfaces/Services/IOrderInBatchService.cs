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
    public interface IOrderInBatchService
    {
        Task<bool> AddAsync(OrderInBatch entity);
        Task<IEnumerable<OrderInBatch>> GetAllAsync();
        Task<OrderInBatch?> GetByIdAsync(Guid entityId);
        Task<int> GetCountAsync();
        Task<IEnumerable<OrderInBatch>> GetFilterAsync(OrderInBatchFilteringModel entity);
        bool Remove(Guid entityId);
        bool Update(OrderInBatch entity);
        Task<Pagination<OrderInBatch>> GetCustomerListPagi(int pageIndex, int pageSize);

    }
}
