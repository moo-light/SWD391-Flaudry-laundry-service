using Application.ViewModels;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IOrderService
{
    Task<bool> AddAsync(LaundryOrder order);
    Task<IEnumerable<LaundryOrder>> GetAllAsync();
    Task<LaundryOrder?> GetByIdAsync(Guid entityId);
    Task<int> GetCountAsync();
    Task<IEnumerable<LaundryOrder>> GetFilterAsync(BaseFilterringModel entity);
    bool Remove(Guid entityId);
    bool Update(LaundryOrder entity);
}