using Application.ViewModels;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ITimeSlotService
    {
        Task<bool> AddAsync(Session timeSlot);
        Task<IEnumerable<Session>> GetAllAsync();
        Task<Session?> GetByIdAsync(Guid entityId);
        Task<int> GetCount();
        Task<IEnumerable<Session>> GetFilter(BaseFilterringModel entity);
        bool Remove(Guid entityId);
        bool Update(Session entity);
    }
}