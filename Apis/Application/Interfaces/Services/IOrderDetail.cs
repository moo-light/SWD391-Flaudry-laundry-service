using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IOrderDetail
    {
        Task<bool> AddAsync(OrderDetail orderDetail);
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task<OrderDetail?> GetByIdAsync(Guid entityId);
        Task<int> GetCountAsync();
        Task<IEnumerable<OrderDetail>> GetFilterAsync(BaseFilterringModel entity);
        bool Remove(Guid entityId);
        bool Update(OrderDetail entity);
    }
}
