using Application.Commons;
using Application.ViewModels.FilterModels;
using Application.ViewModels.Sessions;
using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ISessionService
    {
        Task<bool> AddAsync(SessionRequestDTO timeSlot);
        Task<Pagination<SessionResponseDTO>> GetAllAsync(int pageIndex , int pageSize );
        Task<Session?> GetByIdAsync(Guid entityId);
        Task<int> GetCount();
        Task<Pagination<SessionResponseDTO>> GetFilterAsync(SessionFilteringModel entity, int pageIndex, int pageSize);
        Task<Pagination<Session>> GetCustomerListPagi(int pageIndex, int pageSize);
        Task<bool> UpdateAsync(Guid id, SessionRequestDTO sessionRequest);
        Task<bool> RemoveAsync(Guid entityId);
    }
}