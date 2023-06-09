using Application.ViewModels;
using Application.ViewModels.UserViewModels;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IUserService
{
    public Task RegisterAsync(UserRegisterDTO userObject);
    public Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO userObject);
    Task<bool> AddAsync(BaseUser user);
    bool Remove(Guid entityId);
    bool Update(BaseUser entity);
    Task<BaseUser?> GetByIdAsync(Guid entityId);
    Task<IEnumerable<BaseUser>> GetAllAsync();
    Task<int> GetCountAsync();
    Task<IEnumerable<BaseUser>> GetFilterAsync(UserFilteringModel entity);
}
