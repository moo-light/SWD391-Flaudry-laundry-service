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
        bool Remove(Guid entityId);
        bool Update(Payment entity);
    }
}
