using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        IEnumerable<Service> GetFilter(ServiceFilteringModel entity);
    }
}