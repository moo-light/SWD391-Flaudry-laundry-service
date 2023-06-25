using Application.Commons;
using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<bool> AddAsync(Payment entity);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(Guid entityId);
        Task<int> GetCountAsync();
        Task<IEnumerable<Payment>> GetFilterAsync(BaseFilterringModel entity);
        bool Remove(Guid entityId);
        bool Update(Payment entity);
        Task<Pagination<Payment>> GetCustomerListPagi(int pageIndex, int pageSize);

    }
}
