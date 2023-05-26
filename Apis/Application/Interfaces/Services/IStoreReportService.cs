using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IStoreReportService
{
    Task<bool> AddAsync(StoreReport storeReport);
    Task<IEnumerable<StoreReport>> GetAllAsync();
    Task<StoreReport?> GetByIdAsync(Guid entityId);
    bool Remove(Guid entityId);
    bool Update(StoreReport entity);
}