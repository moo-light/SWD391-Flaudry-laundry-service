using Application.Commons;
using Application.ViewModels.Drivers;
using Application.ViewModels.FilterModels;
using Application.ViewModels.StoreManagers;
using Application.ViewModels.UserViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IStoreManagementService
    {
        public Task<bool> RegisterAsync(StoreManagerRegisterDTO driver);
        public Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO userObject);
        Task<bool> AddAsync(StoreManagerRequestDTO user);
        Task<bool> RemoveAsync(Guid entityId);
        Task<bool> Update(Guid id, StoreManagerRequestUpdateDTO entity);
        Task<Driver?> GetByIdAsync(Guid entityId);
        Task<IEnumerable<StoreManagerResponseDTO>> GetAllAsync();
        Task<int> GetCountAsync();
        Task<bool> CheckEmail(StoreManagerRegisterDTO registerObject);
        Task<IEnumerable<Driver>> GetFilterAsync(StoreFilteringModel driver);
        Task<Pagination<Driver>> GetCustomerListPagi(int pageIndex, int pageSize);
        Task<Pagination<DriverResponseDTO>> GetFilterAsync(StoreFilteringModel customer, int pageIndex, int pageSize);
    }
}
