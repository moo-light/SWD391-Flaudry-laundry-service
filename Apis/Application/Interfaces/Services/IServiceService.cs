using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IServiceService
    {
        Task<bool> AddAsync(Service service);
        Task<IEnumerable<Service>> GetAllAsync();
        Task<Service?> GetByIdAsync(Guid entityId);
        bool Remove(Guid entityId);
        bool Update(Service entity);
    }
}