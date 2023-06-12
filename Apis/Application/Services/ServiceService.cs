using Application.Interfaces;
using Application.Interfaces.Services;
using Application.ViewModels;
using Domain.Entities;

namespace Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Service>> GetAllAsync() => await _unitOfWork.ServiceRepository.GetAllAsync();
        public async Task<Service?> GetByIdAsync(Guid entityId) => await _unitOfWork.ServiceRepository.GetByIdAsync(entityId);
        public async Task<bool> AddAsync(Service service)
        {
            await _unitOfWork.ServiceRepository.AddAsync(service);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.ServiceRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(Service entity)
        {
            _unitOfWork.ServiceRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.ServiceRepository.GetCountAsync();
        }

        public async Task<IEnumerable<Service>> GetFilterAsync(BaseFilterringModel entity)
        {
            return  _unitOfWork.ServiceRepository.GetFilter(entity);

        }
    }
}
