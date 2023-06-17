using Application.ViewModels;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IStoreRepository : IGenericRepository<Store>
    {
        IEnumerable<Store> GetFilter(BaseFilterringModel entity);
    }
}