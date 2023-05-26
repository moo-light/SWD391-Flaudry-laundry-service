using Application.ViewModels.UserViewModels;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task RegisterAsync(UserRegisterDTO userObject);
        public Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO userObject);
        Task<bool> AddAsync(User user);
        bool Remove(Guid entityId);
        bool Update(User entity);
        Task<User?> GetByIdAsync(Guid entityId);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
