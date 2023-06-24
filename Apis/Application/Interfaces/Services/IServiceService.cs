using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IServiceService
    {
        Task<bool> AddAsync(Service service);
        Task<IEnumerable<Service>> GetAllAsync();
        Task<Service?> GetByIdAsync(Guid entityId);
        Task<int> GetCountAsync();
        Task<IEnumerable<Service>> GetFilterAsync(ServiceFilteringModel entity);
        bool Remove(Guid entityId);
        bool Update(Service entity);
    }
}