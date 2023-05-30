using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IDriverReportService
    {
        Task<bool> AddAsync(DriverReport entity);
        Task<IEnumerable<DriverReport>> GetAllAsync();
        Task<DriverReport?> GetByIdAsync(Guid entityId);
        Task<int> GetCountAsync();
        Task<IEnumerable<DriverReport>> GetFilter(DriverReport entity);
        bool Remove(Guid entityId);
        bool Update(DriverReport entity);
    }
}
