using Application.ViewModels;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ITimeSlotService
    {
        Task<bool> AddAsync(TimeSlot timeSlot);
        Task<IEnumerable<TimeSlot>> GetAllAsync();
        Task<TimeSlot?> GetByIdAsync(Guid entityId);
        Task<int> GetCount();
        Task<IEnumerable<TimeSlot>> GetFilter(BaseFilterringModel entity);
        bool Remove(Guid entityId);
        bool Update(TimeSlot entity);
    }
}