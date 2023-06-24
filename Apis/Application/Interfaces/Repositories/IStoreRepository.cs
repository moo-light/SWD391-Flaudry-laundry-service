using Application.ViewModels;
using Application.ViewModels.FilterModels;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IStoreRepository : IGenericRepository<Store>
    {
        IEnumerable<Store> GetFilter(StoreFilteringModel entity);
    }
}