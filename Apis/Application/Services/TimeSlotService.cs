using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TimeSlotService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TimeSlot>> GetAllAsync() => await _unitOfWork.TimeSlotRepository.GetAllAsync();
        public async Task<TimeSlot?> GetByIdAsync(Guid entityId) => await _unitOfWork.TimeSlotRepository.GetByIdAsync(entityId);
        public async Task<bool> AddAsync(TimeSlot timeSlot)
        {
            await _unitOfWork.TimeSlotRepository.AddAsync(timeSlot);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public bool Remove(Guid entityId)
        {
            _unitOfWork.TimeSlotRepository.SoftRemoveByID(entityId);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Update(TimeSlot entity)
        {
            _unitOfWork.TimeSlotRepository.Update(entity);
            return _unitOfWork.SaveChange() > 0;
        }


    }
}
