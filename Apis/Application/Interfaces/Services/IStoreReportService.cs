using Application.ViewModels;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IStoreReportService
{
    Task<bool> AddAsync(StoreReport storeReport);
    Task<IEnumerable<StoreReport>> GetAllAsync();
    Task<StoreReport?> GetByIdAsync(Guid entityId);
    Task<int> GetCountAsync();
    Task<IEnumerable<StoreReport>> GetFilter(BaseFilterringModel entity);
    bool Remove(Guid entityId);
    bool Update(StoreReport entity);
}