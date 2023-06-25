using Application.Commons;
using Application.ViewModels;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IServiceService
    {
        Task<bool> AddAsync(Service service);
        Task<IEnumerable<Service>> GetAllAsync();
        Task<Service?> GetByIdAsync(Guid entityId);
        Task<int> GetCountAsync();
        Task<IEnumerable<Service>> GetFilterAsync(BaseFilterringModel entity);
        bool Remove(Guid entityId);
        bool Update(Service entity);
        Task<Pagination<Service>> GetCustomerListPagi(int pageIndex, int pageSize);

    }
}