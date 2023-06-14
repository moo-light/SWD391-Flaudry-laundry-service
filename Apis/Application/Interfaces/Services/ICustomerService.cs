using Application.ViewModels;
using Application.ViewModels.UserViewModels;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface ICustomerService
{
    public Task RegisterAsync(UserRegisterDTO userObject);
    public Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO userObject);
    Task<bool> AddAsync(Customer user);
    bool Remove(Guid entityId);
    bool Update(Customer entity);
    Task<BaseUser?> GetByIdAsync(Guid entityId);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<int> GetCountAsync();
    Task<IEnumerable<Customer>> GetFilterAsync(UserFilteringModel entity);
}
