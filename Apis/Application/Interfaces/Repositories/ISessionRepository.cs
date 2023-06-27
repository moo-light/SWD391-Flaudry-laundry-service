using Application.ViewModels.FilterModels;
using Application.ViewModels;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ISessionRepository : IGenericRepository<Session>
    {
        IEnumerable<Session> GetFilter(SessionFilteringModel entity);
    }
}