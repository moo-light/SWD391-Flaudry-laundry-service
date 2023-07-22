using Application.Commons;
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
        public Task<bool> CheckEmail(StoreManagerRegisterDTO userObject);
        public Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO userObject);
        public Task<bool> RegisterAsync(StoreManagerRegisterDTO userObject);
        Task<bool> AddAsync(StoreManagerRequestDTO user);
        Task<bool> RemoveAsync(Guid entityId);
        Task<bool> UpdateAsync(Guid id, StoreManagerRequestUpdateDTO entity);
        Task<StoreManager?> GetByIdAsync(Guid entityId);
        Task<IEnumerable<StoreManagerResponseDTO>> GetAllAsync();
        Task<int> GetCountAsync();
        Task<Pagination<StoreManagerResponseDTO>> GetFilterAsync(StoreManagerFilteringModel customer, int pageIndex, int pageSize);
        UserLoginDTOResponse LoginAdmin(UserLoginDTO loginObject);
        Task<Pagination<StoreManagerResponseDTO>> GetStoreManagerListPagi(int pageIndex, int pageSize);
        AdminToken RefreshToken(string refreshToken);
    }
}
