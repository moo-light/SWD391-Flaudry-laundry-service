using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IOrderService
{
    Task<bool> AddAsync(Order order);
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(Guid entityId);
    bool Remove(Guid entityId);
    bool Update(Order entity);
}