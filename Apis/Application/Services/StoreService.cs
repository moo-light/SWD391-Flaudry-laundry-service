using Application.Interfaces;
using Application.Interfaces.Services;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;

namespace Application.Services
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StoreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Store>> GetAllAsync() => await _unitOfWork.StoreRepository.GetAllAsync();
        public async Task<Store?> GetByIdAsync(Guid entityId) => await _unitOfWork.StoreRepository.GetByIdAsync(entityId);
        public async Task<bool> AddAsync(Store store)
        {
            await _unitOfWork.StoreRepository.AddAsync(store);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.StoreRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(Store entity)
        {
            _unitOfWork.StoreRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.StoreRepository.GetCountAsync();
        }

        public async Task<IEnumerable<Store>> GetFilterAsync(StoreFilteringModel entity)
        {
            return _unitOfWork.StoreRepository.GetFilter(entity);
        }
    }
}
