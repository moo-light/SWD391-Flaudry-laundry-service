using Application.Commons;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Application.ViewModels.UserViewModels;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface ICustomerService
{
    public Task<bool> CheckEmail(CustomerRegisterDTO userObject);
    public Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO userObject);
    public Task<bool> RegisterAsync(CustomerRegisterDTO userObject);
    Task<bool> AddAsync(Customer user);
    bool Remove(Guid entityId);
    bool Update(Customer entity);
    Task<Customer?> GetByIdAsync(Guid entityId);
    Task<Pagination<CustomerFilteringModel>> GetAllAsync(int pageIndex = 0, int pageSize = 10);
    Task<int> GetCountAsync();
    Task<IEnumerable<Customer>> GetFilterAsync(CustomerFilteringModel entity);
    UserLoginDTOResponse LoginAdmin(UserLoginDTO loginObject);
    Task<Pagination<Customer>> GetCustomerListPagi(int pageIndex, int pageSize);
}
