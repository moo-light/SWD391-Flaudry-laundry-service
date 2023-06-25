using Application.Commons;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Application.ViewModels.UserViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces.Services;

public interface IDriverService
{
    public Task<bool> RegisterAsync(DriverRegisterDTO userObject);
    public Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO userObject);
    Task<bool> AddAsync(Driver user);
    bool Remove(Guid entityId);
    bool Update(Driver entity);
    Task<Driver?> GetByIdAsync(Guid entityId);
    Task<IEnumerable<Driver>> GetAllAsync();
    Task<int> GetCountAsync();
    Task<bool> CheckEmail(DriverRegisterDTO registerObject);
    Task<IEnumerable<Driver>> GetFilterAsync(DriverFilteringModel driver);
    Task<Pagination<Driver>> GetCustomerListPagi(int pageIndex, int pageSize);
}
