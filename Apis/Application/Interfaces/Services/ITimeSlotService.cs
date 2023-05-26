using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ITimeSlotService
    {
        Task<bool> AddAsync(TimeSlot timeSlot);
        Task<IEnumerable<TimeSlot>> GetAllAsync();
        Task<TimeSlot?> GetByIdAsync(Guid entityId);
        bool Remove(Guid entityId);
        bool Update(TimeSlot entity);
    }
}