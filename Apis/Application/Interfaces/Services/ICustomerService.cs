using Application.ViewModels;
using Application.ViewModels.Customer;
using Application.ViewModels.FilterModels;
using Application.ViewModels.UserViewModels;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface ICustomerService
{
    public Task RegisterAsync(CustomerRegisterDTO userObject);
    Task<bool> AddAsync(CustomerRequestDTO user);
    bool Remove(Guid entityId);
    Task<bool> UpdateAsync(Guid id, CustomerRequestDTO entity);
    Task<CustomerResponseDTO?> GetByIdAsync(Guid entityId);
    Task<IEnumerable<CustomerResponseDTO>> GetAllAsync();
    Task<int> GetCountAsync();
    Task<IEnumerable<CustomerResponseDTO>> GetFilterAsync(CustomerFilteringModel entity);
    UserLoginDTOResponse LoginAdmin(UserLoginDTO loginObject);
}
