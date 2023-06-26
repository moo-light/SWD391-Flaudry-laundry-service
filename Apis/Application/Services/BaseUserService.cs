using Application.Commons;
using Application.ViewModels.FilterModels;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Utils;
using Application.ViewModels;
using Application.ViewModels.UserViewModels;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class BaseUserService : IBaseUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppConfiguration _configuration;
        private readonly ICurrentTime _currentTime;

        public BaseUserService(IUnitOfWork unitOfWork,AppConfiguration configuration ,ICurrentTime currentTime)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _currentTime = currentTime;
        }

        public async Task<Pagination<BaseUser>> GetAllAsync(int pageIndex,int pageSize)
        {
            var baseUsers = await _unitOfWork.UserRepository.ToPagination(pageIndex,pageSize);
            return baseUsers;
        }

        public async Task<BaseUser?> GetByIdAsync(Guid entityId) => await _unitOfWork.UserRepository.GetByIdAsync(entityId);
        public async Task<bool> AddAsync(BaseUser store)
        {
            await _unitOfWork.UserRepository.AddAsync(store);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.UserRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(BaseUser entity)
        {
            _unitOfWork.UserRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.UserRepository.GetCountAsync();
        }

        public  async Task<Pagination<BaseUser>> GetFilterAsync(UserFilteringModel entity, int pageIndex, int pageSize)
        {
            var baseUsers = _unitOfWork.UserRepository.GetFilter(entity);
            var pagination = _unitOfWork.UserRepository.ToPagination(baseUsers, pageIndex, pageSize);
            return pagination;
        }

        public async Task<UserLoginDTOResponse> LoginAsync(UserLoginDTO userObject)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmailAndPasswordHash(userObject.Email, userObject.Password);
            return new UserLoginDTOResponse
            {
                UserId = user.Id,
                JWT = user.GenerateJsonWebToken(_configuration.JWTSecretKey, _currentTime.GetCurrentTime())
            };
        }
    }
}
