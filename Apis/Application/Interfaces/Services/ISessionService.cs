using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ISessionService
    {
        Task<bool> AddAsync(Session timeSlot);
        Task<IEnumerable<Session>> GetAllAsync();
        Task<Session?> GetByIdAsync(Guid entityId);
        Task<int> GetCount();
        Task<IEnumerable<Session>> GetFilterAsync(SessionFilteringModel entity);
        bool Remove(Guid entityId);
        bool Update(Session entity);
    }
}