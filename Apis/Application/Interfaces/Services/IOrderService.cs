using Application.Commons;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IOrderService
{
    Task<bool> AddAsync(LaundryOrder order);
    Task<IEnumerable<LaundryOrder>> GetAllAsync();
    Task<LaundryOrder?> GetByIdAsync(Guid entityId);
    Task<int> GetCountAsync();
    Task<IEnumerable<LaundryOrder>> GetFilterAsync(LaundryOrderFilteringModel entity);
    bool Remove(Guid entityId);
    bool Update(LaundryOrder entity);
    Task<Pagination<LaundryOrder>> GetCustomerListPagi(int pageIndex, int pageSize);

}