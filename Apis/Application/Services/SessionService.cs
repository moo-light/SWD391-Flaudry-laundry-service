using Application.Commons;
using Application.Interfaces;
using Application.Interfaces.Services;
using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;

namespace Application.Services
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SessionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Session>> GetAllAsync() => await _unitOfWork.SessionRepository.GetAllAsync();
        public async Task<Session?> GetByIdAsync(Guid entityId) => await _unitOfWork.SessionRepository.GetByIdAsync(entityId);
        public async Task<bool> AddAsync(Session timeSlot)
        {
            await _unitOfWork.SessionRepository.AddAsync(timeSlot);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.SessionRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(Session entity)
        {
            _unitOfWork.SessionRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }

        public async Task<IEnumerable<Session>> GetFilterAsync(SessionFilteringModel entity)
        {
            return  _unitOfWork.SessionRepository.GetFilter(entity);
        }

        public async Task<int> GetCount()
        {
            return await _unitOfWork.SessionRepository.GetCountAsync();
        }

        public Task<Pagination<Session>> GetCustomerListPagi(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
