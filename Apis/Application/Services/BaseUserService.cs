using Application.Interfaces;
using Application.Interfaces.Services;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;

namespace Application.Services
{
    public class BaseUserService : IBaseUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BaseUser>> GetAllAsync() => await _unitOfWork.UserRepository.GetAllAsync();
        public async Task<BaseUser?> GetByIdAsync(Guid entityId) => await _unitOfWork.UserRepository.GetByIdAsync(entityId);
        public async Task<bool> AddAsync(BaseUser store)
        {
            await _unitOfWork.UserRepository.AddAsync(store);
            return await _unitOfWork.SaveChangeAsync() > 0;
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

        public  async Task<IEnumerable<BaseUser>> GetFilterAsync(UserFilteringModel entity)
        {
            return  _unitOfWork.UserRepository.GetFilter(entity);
        }
    }
}
