using Application.ViewModels.UserViewModels;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<BaseUser>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<BaseUser> GetUserByUserNameAndPasswordHash(string username, string passwordHash);

        Task<bool> CheckEmailExisted(string username);
    }
}
