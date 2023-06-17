using Application.ViewModels;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ISessionService
    {
        Task<bool> AddAsync(Session timeSlot);
        Task<IEnumerable<Session>> GetAllAsync();
        Task<Session?> GetByIdAsync(Guid entityId);
        Task<int> GetCount();
        Task<IEnumerable<Session>> GetFilterAsync(BaseFilterringModel entity);
        bool Remove(Guid entityId);
        bool Update(Session entity);
    }
}