using Application.Commons;
using Application.ViewModels;
using Application.ViewModels.Customer;
using Application.ViewModels.FilterModels;
using Application.ViewModels.UserViewModels;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface ICustomerService
{
    public Task<bool> CheckEmail(CustomerRegisterDTO userObject);
    public Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO userObject);
    public Task<bool> RegisterAsync(CustomerRegisterDTO userObject);
    Task<bool> AddAsync(CustomerRequestDTO user);
    Task<bool> UpdateAsync(Guid id, CustomerRequestDTO entity);
    Task<CustomerResponseDTO?> GetByIdAsync(Guid entityId);
    Task<bool> RemoveAsync(Guid entityId);
    Task<IEnumerable<CustomerResponseDTO>> GetAllAsync();
    Task<int> GetCountAsync();
    Task<IEnumerable<Customer>> GetFilterAsync(CustomerFilteringModel entity);
    UserLoginDTOResponse LoginAdmin(UserLoginDTO loginObject);
    Task<Pagination<Customer>> GetCustomerListPagi(int pageIndex, int pageSize);
}
