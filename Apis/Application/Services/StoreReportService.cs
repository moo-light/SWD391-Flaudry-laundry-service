using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class StoreReportService : IStoreReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StoreReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<StoreReport>> GetAllAsync() => await _unitOfWork.StoreReportRepository.GetAllAsync();
        public async Task<StoreReport?> GetByIdAsync(Guid entityId) => await _unitOfWork.StoreReportRepository.GetByIdAsync(entityId);
        public async Task<bool> AddAsync(StoreReport storeReport)
        {
            await _unitOfWork.StoreReportRepository.AddAsync(storeReport);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.StoreReportRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(StoreReport entity)
        {
            _unitOfWork.StoreReportRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }


    }
}
