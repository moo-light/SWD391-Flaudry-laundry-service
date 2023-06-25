using Application.Commons;
using Application.ViewModels.FilterModels;
using Domain.Entities;
using System.Formats.Tar;

namespace Application.Interfaces.Services
{
    public interface IStoreService
    {
        Task<bool> AddAsync(Store store);
        Task<Pagination<Store>> GetAllAsync(int pageIndex,int PageSize);
        Task<Store?> GetByIdAsync(Guid entityId);
        Task<int> GetCountAsync();
        Task<IEnumerable<Store>> GetFilterAsync(StoreFilteringModel entity);
        bool Remove(Guid entityId);
        bool Update(Store entity);
        Task<Pagination<Store>> GetCustomerListPagi(int pageIndex, int pageSize);

    }
}