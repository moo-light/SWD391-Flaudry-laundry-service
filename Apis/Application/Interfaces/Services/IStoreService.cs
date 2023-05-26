using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IStoreService
    {
        Task<bool> AddAsync(Store store);
        Task<IEnumerable<Store>> GetAllAsync();
        Task<Store?> GetByIdAsync(Guid entityId);
        bool Remove(Guid entityId);
        bool Update(Store entity);
    }
}